using DocumentSystem.Application.Interfaces;
using DocumentSystem.Core.Contract;
using DocumentSystem.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace DocumentSystem.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CompleteTaskAsync(string documentId)
        {
            var documentRepo = _unitOfWork.GetRepository<DocumentEntity>();

            var document = await documentRepo
                .AsQueryable()
                .FirstOrDefaultAsync(d => d.Id == documentId);

            if (document == null)
                return false;

            var activeTask = document.ActiveTask;

            if (activeTask != null)
                return false;

            var nextTask = document.Tasks
                .FirstOrDefault(t => t.PreviousTaskID == activeTask!.Id);

            if (nextTask != null) 
            {
                document.ActiveTask = nextTask;
            }
            else
            {
                document.Status = "В оперативном архиве";
                document.ActiveTask = null;
            }

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelDocumentAsync(string documentId)
        {
            var documentRepo = _unitOfWork.GetRepository<DocumentEntity>();

            var document = await documentRepo
                .AsQueryable()
                .FirstOrDefaultAsync(d => d.Id == documentId);

            if (document == null)
                return false;

            document.Status = "Отмена";
            document.ActiveTask = null;

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
