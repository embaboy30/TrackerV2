using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tracker.Data;
using Tracker.Data.Model;
using Tracker.IRepository;

namespace Tracker.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly TrackerDbContext _trackerDbContext;
        private readonly IMapper _mapper;
        public NoteRepository(TrackerDbContext trackerDbContext,
            IMapper mapper
            )
        {
            _trackerDbContext = trackerDbContext;
            _mapper = mapper;

        }
        public List<Note> GetTodoNotesById(int todoId)
        {
            var result = _trackerDbContext.Todo.Include(x => x.Notes).FirstOrDefault(x => x.Id == todoId);
            return result != null ? result.Notes.ToList() : new List<Note>();
        }
        public int AddNote(Note model, int todoId)
        {
            var todo = _trackerDbContext.Todo.Include(x => x.Notes).FirstOrDefault(x => x.Id == todoId);
            if (todo == null) return 0;
            todo.Notes.Add(model);
            _trackerDbContext.Todo.Update(todo);
            _trackerDbContext.SaveChanges();
            return model.Id;
        }
        public int UpdateNote(Note model)
        {
            var note = _trackerDbContext.Note.Find(model.Id);
            if (note == null) return 0;
            note.Description = model.Description;
            note.Title = model.Title;
            note.Date = model.Date;
            _trackerDbContext.Note.Update(note);
            return _trackerDbContext.SaveChanges();
        }
        public int DeleteNote(int id)
        {
            _trackerDbContext.Note.Remove(new Note() { Id = id });
            return _trackerDbContext.SaveChanges();
        }
    }
}
