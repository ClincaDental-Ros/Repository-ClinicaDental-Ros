using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace API.Clients
{
    public abstract class BaseApiClient
    {
 
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

   
        private readonly HttpClient? _ownHttpClient;
        private readonly IAuthService? _ownAuthService;

        // Usado por WindowsForms
        protected BaseApiClient()
        {
        }

        // Usado por el contenedor de DI de Blazor
        protected BaseApiClient(HttpClient httpClient, IAuthService authService)
        {
            _ownHttpClient = httpClient;
            _ownAuthService = authService;
        }

        public static event Action? OnUnauthorized;

        protected Task<HttpClient> GetConfiguredClientAsync()
        {
            // Blazor usa su cliente y sesión propios; WindowsForms, los compartidos
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

 
        private static async Task VerificarRespuestaAsync(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                OnUnauthorized?.Invoke();
                throw new UnauthorizedAccessException("Sesión expirada o no autorizada.");
            }

            if (response.IsSuccessStatusCode)
                return;

            var cuerpo = await response.Content.ReadAsStringAsync();
            string mensaje = response.StatusCode == System.Net.HttpStatusCode.Forbidden
                ? "No tiene permisos para realizar esta acción."
                : $"Error HTTP {(int)response.StatusCode}";

            try
            {
                using var doc = JsonDocument.Parse(cuerpo);
                if (doc.RootElement.ValueKind == JsonValueKind.Object &&
                    doc.RootElement.TryGetProperty("message", out var msg) &&
                    msg.ValueKind == JsonValueKind.String)
                {
                    mensaje = msg.GetString()!;
                }
            }
            catch (JsonException)
            {
                if (!string.IsNullOrWhiteSpace(cuerpo)) mensaje += $": {cuerpo}";
            }

            throw new HttpRequestException(mensaje, null, response.StatusCode);
        }

        protected async Task<T?> GetAsync<T>(string endpoint)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.GetAsync(endpoint);

            await VerificarRespuestaAsync(response);

            return await response.Content.ReadFromJsonAsync<T>(_jsonOptions);
        }

        protected async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data, _jsonOptions);

            await VerificarRespuestaAsync(response);

            if (response.Content.Headers.ContentLength == 0)
                return default;

            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }

        protected async Task<bool> PostAsync<TRequest>(string endpoint, TRequest data)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PostAsJsonAsync(endpoint, data, _jsonOptions);

            await VerificarRespuestaAsync(response);

            return true;
        }

        protected async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.PutAsJsonAsync(endpoint, data, _jsonOptions);

            await VerificarRespuestaAsync(response);

            return await response.Content.ReadFromJsonAsync<TResponse>(_jsonOptions);
        }

        protected async Task<bool> DeleteAsync(string endpoint)
        {
            var client = await GetConfiguredClientAsync();
            var response = await client.DeleteAsync(endpoint);

            await VerificarRespuestaAsync(response);

            return true;
        }
    }
}
