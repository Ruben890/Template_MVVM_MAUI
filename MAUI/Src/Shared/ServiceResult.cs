using Shared.Enums;

namespace Shared
{
    public class ServiceResult<T>
    {
        public ServiceResultStatus Status { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; } = default(T?);

        private ServiceResult(ServiceResultStatus status, string? message, T? data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public static ServiceResult<T> Ok(T data, string? message = null)
            => new ServiceResult<T>(ServiceResultStatus.Success, message, data);

        public static ServiceResult<T> Warning(string message, T? data = default)
            => new ServiceResult<T>(ServiceResultStatus.Warning, message, data);

        public static ServiceResult<T> Fail(string message)
            => new ServiceResult<T>(ServiceResultStatus.Fail, message, default);
    }
}
