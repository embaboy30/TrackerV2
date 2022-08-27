using Microsoft.AspNetCore.Mvc;
using Tracker.Data.Model;
using Tracker.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET api/<NoteController>/5
        [HttpGet("{todoId}")]
        public IActionResult Get(int todoId)
        {
            var result = _noteRepository.GetTodoNotesById(todoId);
            return Ok(result);
        }

        // POST api/<NoteController>
        [HttpPost]
        public IActionResult Post([FromBody] Note model, int todoId)
        {
            var result = _noteRepository.AddNote(model, todoId);
            return Ok(result);
        }

        // PUT api/<NoteController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Note value)
        {
            var result = _noteRepository.UpdateNote(value);
            return Ok(result);
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _noteRepository.DeleteNote(id);
            return Ok(result);
        }
    }
}
