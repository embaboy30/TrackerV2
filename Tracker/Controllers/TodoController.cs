using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tracker.Data.Model;
using Tracker.Data.ViewModel;
using Tracker.IRepository;

namespace Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;

        }
        [HttpGet("")]
        public IActionResult GetTodos()
        {
            var result = _todoRepository.GetTodos();
            return Ok(result);
        }
        [HttpGet("{month}")]
        public IActionResult GetTodosByMonth(int month)
        {
            var result = _todoRepository.GetTodosByMonth(month);
            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult AddTodo(TodoDto model)
        {
            var result = _todoRepository.AddTodo(model);
            return Ok(result);
        }

        [HttpPut("")]
        public IActionResult UpdateTodo(TodoDto model)
        {
            var result = _todoRepository.UpdateTodo(model);
            return Ok(result);
        }
        [HttpDelete("")]
        public IActionResult DeleteTodo(int id)
        {
            var result = _todoRepository.DeleteTodo(id);
            return Ok(result);
        }
    }
}
