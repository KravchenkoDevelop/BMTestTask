using Microsoft.AspNetCore.Mvc;
using Test.BLL;
using Test.DM;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpPost("task")]
        public partial async Task<IActionResult> CreateTaskAsync()
        {
            try
            {
                var result = await _taskService.CreateNewTaskAsync();

                _logger.LogInformation($"Created new task. Task Guid = {result}");

                return new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status202Accepted
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} catched exception: \t\n message{ex.Message} \t\n stacktrace {ex.StackTrace}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("task/{id}")]
        public partial async Task<IActionResult> GetTaskAsync(Guid id)
        {
            var result = new TaskModel();
            try
            {
                result = await _taskService.GetTaskByIdAsync(id);

                switch (result.Id)
                {
                    case var r when result.Id == id:
                        _logger.LogInformation($"Returned task with guid {id}");
                        return Ok(new { result.Id, result.Status });
                        break;

                    case var r when result.Id == new Guid():
                        _logger.LogInformation($"Requested task with guid {id} not found");
                        return NotFound();
                        break;

                    default:
                        return BadRequest();
                        break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{DateTime.Now} catched exception: \t\n message{ex.Message} \t\n stacktrace {ex.StackTrace}");
                return BadRequest(ex.Message);
            }
        }
    }
}
