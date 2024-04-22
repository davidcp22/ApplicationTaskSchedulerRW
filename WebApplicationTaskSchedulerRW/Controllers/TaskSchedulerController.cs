using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using TaskSchedulerBusinessRW.Interface;
using TaskSchedulerBusinessRW.Models;

namespace WebAPITaskSchedulerRW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskSchedulerController : ControllerBase
    {
        private readonly ITaskSchedulerService _taskSchedulerService;
        public TaskSchedulerController(ITaskSchedulerService taskSchedulerService)
        {
            _taskSchedulerService = taskSchedulerService;
        }


        [HttpPost(Name = "TaskScheduler")]
        public async Task<IActionResult> TaskSchedulerAsync(TaskSchedulerModel taskScheduler)
        {
            return Ok(await _taskSchedulerService.TaskSchedulerAsync(taskScheduler));
        }
    }
}
