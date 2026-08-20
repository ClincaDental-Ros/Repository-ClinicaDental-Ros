using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
        private static string _baseUrl = "http://localhost:5263";
        private static readonly HttpClient _httpClient = new();
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
                _httpClient.BaseAddress = new Uri(_baseUrl);
            }
        }

        static BaseApiClient()
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public static event Action? OnUnauthorized;

        protected async Task<HttpClient> GetConfiguredClientAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (AuthServiceProvider.IsInitialized && AuthServiceProvider.Current.IsAuthenticated())
            {
                var token = AuthServiceProvider.Current.GetToken();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
            }

            return _httpClient;
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
