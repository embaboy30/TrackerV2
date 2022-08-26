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
        //add
        [HttpPost("")]
        public IActionResult AddTodo(TodoDto model)
        {
            var result = _todoRepository.AddTodo(model);
            return Ok(result);
        }
    }
}
