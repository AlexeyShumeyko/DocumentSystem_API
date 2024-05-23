namespace DocumentSystem.Application.Interfaces
{
    public interface ITaskService
    {
        Task<bool> CompleteTaskAsync(string documentId);
        Task<bool> CancelDocumentAsync(string documentId);

    }
}
