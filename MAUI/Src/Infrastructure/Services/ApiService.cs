using Appliaction.Interfaces.IServices;
using Infrastructure.Config;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Services
{
    public class ApiService : IApiService
    {
        private readonly RestClient _client;

        public ApiService(RestClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Sends a GET request to the specified resource with optional query parameters.
        /// </summary>
        public async Task<TResponse?> GetAsync<TResponse>(string resource, object? queryParams = null)
        {
            var request = new RestRequest(resource, Method.Get);

            if (queryParams is not null)
                request.AddObject(queryParams);

            var response = await _client.ExecuteAsync<TResponse>(request);
            return response.IsSuccessful ? response.Data : default;
        }

        /// <summary>
        /// Sends a POST request with a body and optional query parameters.
        /// </summary>
        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string resource, TRequest body, object? queryParams = null)
        {
            var request = new RestRequest(resource, Method.Post);

            if (queryParams is not null)
                request.AddObject(queryParams);

            var jsonBody = JsonConvert.SerializeObject(body, JsonSettings.Default);
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = await _client.ExecuteAsync<TResponse>(request);
            return response.IsSuccessful ? response.Data : default;
        }

        /// <summary>
        /// Sends a PUT request with a body and optional query parameters.
        /// </summary>
        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string resource, TRequest body, object? queryParams = null)
        {
            var request = new RestRequest(resource, Method.Put);

            if (queryParams is not null)
                request.AddObject(queryParams);

            var jsonBody = JsonConvert.SerializeObject(body, JsonSettings.Default);
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = await _client.ExecuteAsync<TResponse>(request);
            return response.IsSuccessful ? response.Data : default;
        }

        /// <summary>
        /// Sends a PATCH request with a body and optional query parameters.
        /// </summary>
        public async Task<TResponse?> PatchAsync<TRequest, TResponse>(string resource, TRequest body, object? queryParams = null)
        {
            var request = new RestRequest(resource, Method.Patch);

            if (queryParams is not null)
                request.AddObject(queryParams);

            var jsonBody = JsonConvert.SerializeObject(body, JsonSettings.Default);
            request.AddStringBody(jsonBody, DataFormat.Json);

            var response = await _client.ExecuteAsync<TResponse>(request);
            return response.IsSuccessful ? response.Data : default;
        }

        /// <summary>
        /// Sends a DELETE request with optional query parameters.
        /// </summary>
        public async Task<bool> DeleteAsync(string resource, object? queryParams = null)
        {
            var request = new RestRequest(resource, Method.Delete);

            if (queryParams is not null)
                request.AddObject(queryParams);

            var response = await _client.ExecuteAsync(request);
            return response.IsSuccessful;
        }
    }
}
