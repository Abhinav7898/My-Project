using CRUD.Dto;
using CRUD.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITasksBiz _biz;
        public TasksController(ITasksBiz biz)
        {
            _biz = biz;
        }

        [Authorize]
        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> AddTasks(Tasks tasks)
        {
            var task = await _biz.AddTasks(tasks);
            return CreatedAtAction(nameof(AddTasks), task);
        }

        [Authorize]
        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> UpdateTasks(Tasks tasks)
        {
            var task = await _biz.UpdateTasks(tasks);
            return Ok(task);
        }

        [Authorize]
        [HttpDelete]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> DeleteTasks(Tasks tasks)
        {
            var task = await _biz.DeleteTasks(tasks);
            return Ok(task);
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetTask(int userId)
        {
            var list = _biz.GetTask(userId);
            return Ok(list);
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetTasks(int userId, int taskId)
        {
            var list =  _biz.GetTasks(userId,taskId);
            return Ok(list);
        }

        [Authorize]
        [HttpGet]
        [Route("api/[controller]/[action]")]
        public async Task<IActionResult> GetTasksHistory(int userId)
        {
            var list = _biz.GetTasksHistory(userId);
            return Ok(list);
        }
    }
}
