using DocumentSystem.Application.Interfaces;
using DocumentSystem.Core.Contract;
using DocumentSystem.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace DocumentSystem.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<DocumentEntity> GetDocuments()
        {
            var documentRepo = _unitOfWork.GetRepository<DocumentEntity>();

            var documents = documentRepo.AsQueryable().ToList();

            return documents;
        }

        public async Task<DocumentEntity> GetDocumentByIdAsync(string documentId)
        {
            var documentRepo = _unitOfWork.GetRepository<DocumentEntity>();

            var document = await documentRepo
                .AsQueryable()
                .FirstOrDefaultAsync(d => d.Id == documentId);

            return document;
        }

        public async Task<DocumentEntity> CreateDocumentAsync(DocumentEntity document)
        {
            var documentRepo = _unitOfWork.GetRepository<DocumentEntity>();

            documentRepo.Create(document);

            await _unitOfWork.SaveChangesAsync();

            return document;
        }

        public async Task<bool> DeleteDocumentAsync(string documentId)
        {
            var documentRepo = _unitOfWork.GetRepository<DocumentEntity>();

            var document = await documentRepo
                .AsQueryable()
                .FirstOrDefaultAsync(d => d.Id == documentId);

            if (document == null)
                return false;

            documentRepo.Delete(document);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
