using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasksSystem.Models;
using TasksSystem.Repos.Interfaces;

namespace TasksSystem.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase {
        private readonly ITaskRepos _taskRepos;

        public TaskController(ITaskRepos taskRepos) {
            _taskRepos=taskRepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.Task>>> GetAllTasks() {
            List<Models.Task> tasks = await _taskRepos.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetById(int id) {
            Models.Task task = await _taskRepos.GetById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> Add([FromBody] Models.Task taskModel) {
            Models.Task task = await _taskRepos.Add(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Models.Task>> Update([FromBody] Models.Task taskModel, int id) {
            taskModel.Id = id;
            Models.Task task = await _taskRepos.Update(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> Delete(int id) {
            bool deleted = await _taskRepos.Delete(id);
            return Ok(deleted);
        }

    }
}
