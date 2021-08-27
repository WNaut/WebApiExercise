using System.Net;

namespace Core.Contracts
{
    /// <summary>
    /// Represents a generic operation result.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOperationResult<T>
    {
        string Message { get; }
        bool Success { get; }
        HttpStatusCode StatusCode { get; }
        T Entity { get; }
    }
}
