using DocumentSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocumentSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPut]
        public async Task<IActionResult> CompleteTask(string documentId)
        {
            var result = await _taskService.CompleteTaskAsync(documentId);

            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> CancelDocument(string documentId)
        {
            var result = await _taskService.CancelDocumentAsync(documentId);

            if (!result) 
                return NotFound();

            return Ok(result);
        }
    }
}
