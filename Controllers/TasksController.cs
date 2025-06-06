using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _service;

        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpPost]
        public IActionResult Create(TaskItem task) => Ok(_service.Add(task));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _service.Delete(id) ? Ok() : NotFound();

        [HttpPut("{id}/complete")]
        public IActionResult MarkComplete(int id) =>
            _service.MarkCompleted(id) ? Ok() : NotFound();
    }
}
