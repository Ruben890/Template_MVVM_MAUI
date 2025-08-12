namespace Appliaction.Interfaces.IServices
{
    public interface IApiService
    {
        Task<bool> DeleteAsync(string resource, object? queryParams = null);
        Task<TResponse?> GetAsync<TResponse>(string resource, object? queryParams = null);
        Task<TResponse?> PatchAsync<TRequest, TResponse>(string resource, TRequest body, object? queryParams = null);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string resource, TRequest body, object? queryParams = null);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string resource, TRequest body, object? queryParams = null);
    }
}
