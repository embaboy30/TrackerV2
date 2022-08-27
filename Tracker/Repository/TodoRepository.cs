using AutoMapper;
using Tracker.Data;
using Tracker.Data.Model;
using Tracker.Data.ViewModel;
using Tracker.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Tracker.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TrackerDbContext _trackerDbContext;
        private readonly IMapper _mapper;
        public TodoRepository(TrackerDbContext trackerDbContext,
            IMapper mapper
            )
        {
            _trackerDbContext = trackerDbContext;
            _mapper = mapper;

        }
        public List<Todo> GetTodos()
        {
            var result = _trackerDbContext.Todo.Include(x => x.Notes).ToList();
            return result;
        }
        public int AddTodo(TodoDto model)
        {
            var data = _mapper.Map<Todo>(model);
            data.CreatedAt = DateTime.Now;
            data.Tag = model.Tag;
            data.CreatedBy = "admin"; // todo: use the current user
            _trackerDbContext.Todo.Add(data);
            _trackerDbContext.SaveChanges();

            return data.Id;
        }
        public int UpdateTodo(TodoDto model)
        {
            var todo = _trackerDbContext.Todo.Find(model.Id);
            if (todo == null) return 0;
            todo.Description = model.Description;
            todo.Title = model.Title;
            todo.GoalDate = model.GoalDate;
            todo.Tag = model.Tag;
            _trackerDbContext.Todo.Update(todo);
            return _trackerDbContext.SaveChanges();
        }
        public int DeleteTodo(int id)
        {
            _trackerDbContext.Todo.Remove(new Todo() { Id = id });
            return _trackerDbContext.SaveChanges();
        }
    }
}
