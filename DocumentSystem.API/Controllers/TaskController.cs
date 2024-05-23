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
        public async Task<IActionResult> CompleteTask(int id)
        {
            var result = await _taskService.CompleteTaskAsync(id);

            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> CancelDocument(int id)
        {
            var result = await _taskService.CancelDocumentAsync(id);

            if (!result) 
                return NotFound();

            return Ok(result);
        }
    }
}
