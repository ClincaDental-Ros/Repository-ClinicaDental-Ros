using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        // ---------- MODO VIEJO (WindowsForms): HttpClient compartido + AuthServiceProvider ----------
        private static string _baseUrl = "http://localhost:5263";
        private static readonly HttpClient _sharedHttpClient = new();
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static string BaseUrl
        {
            get => _baseUrl;
            set
            {
                _baseUrl = value.TrimEnd('/');
                _sharedHttpClient.BaseAddress = new Uri(_baseUrl);
            }
        }

        static BaseApiClient()
        {
            _sharedHttpClient.BaseAddress = new Uri(_baseUrl);
        }

        // ---------- MODO NUEVO (Blazor): un HttpClient y un IAuthService por usuario ----------
        private readonly HttpClient? _ownHttpClient;
        private readonly IAuthService? _ownAuthService;

        // Constructor viejo: lo sigue usando WindowsForms (new AuthApiClient())
        protected BaseApiClient()
        {
        }

        // Constructor nuevo: lo usa el contenedor de DI de Blazor
        protected BaseApiClient(HttpClient httpClient, IAuthService authService)
        {
            _ownHttpClient = httpClient;
            _ownAuthService = authService;
        }

        public static event Action? OnUnauthorized;

        protected Task<HttpClient> GetConfiguredClientAsync()
        {
            // Si vino por el constructor nuevo usa lo propio; si no, el comportamiento de siempre
            var client = _ownHttpClient ?? _sharedHttpClient;
            var auth = _ownAuthService ?? (AuthServiceProvider.IsInitialized ? AuthServiceProvider.Current : null);

            client.DefaultRequestHeaders.Authorization = null;

            if (auth != null && auth.IsAuthenticated())
            {
                var token = auth.GetToken();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            return Task.FromResult(client);
        }

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.GetAsync(endpoint);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                OnUnauthorized?.Invoke();
                throw new UnauthorizedAccessException("Sesión expirada o no autorizada.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error HTTP {(int)response.StatusCode}: {error}");
            }

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }

        protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data, _jsonOptions);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                OnUnauthorized?.Invoke();
                throw new UnauthorizedAccessException("Sesión expirada o no autorizada.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error HTTP {(int)response.StatusCode}: {error}");
            }

            if (response.Content.Headers.ContentLength == 0)
                return default;

            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }

        protected async Task<bool> PostAsync<TRequest>(string endpoint, TRequest data)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data, _jsonOptions);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                OnUnauthorized?.Invoke();
                throw new UnauthorizedAccessException("Sesión expirada o no autorizada.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error HTTP {(int)response.StatusCode}: {error}");
            }

            return response.IsSuccessStatusCode;
        }

        protected async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PutAsJsonAsync(endpoint, data, _jsonOptions);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                OnUnauthorized?.Invoke();
                throw new UnauthorizedAccessException("Sesión expirada o no autorizada.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error HTTP {(int)response.StatusCode}: {error}");
            }

            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }

        protected async Task<bool> DeleteAsync(string endpoint)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.DeleteAsync(endpoint);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                OnUnauthorized?.Invoke();
                throw new UnauthorizedAccessException("Sesión expirada o no autorizada.");
            }

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error HTTP {(int)response.StatusCode}: {error}");
            }

            return response.IsSuccessStatusCode;
        }
    }
}