using DocumentSystem.Core.Model;

namespace DocumentSystem.Application.Interfaces
{
    public interface IDocumentService
    {
        List<DocumentEntity> GetDocuments();
        Task<DocumentEntity> GetDocumentByIdAsync(string documentId);
        Task<DocumentEntity> CreateDocumentAsync(DocumentEntity document);
        Task<bool> DeleteDocumentAsync(string documentId);
    }
}
