using Tracker.Data;
using Tracker.Data.Model;
using Tracker.IRepository;

namespace Tracker.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TrackerDbContext _trackerDbContext;
        public TodoRepository(TrackerDbContext trackerDbContext)
        {
            _trackerDbContext = trackerDbContext;

        }
        public List<Todo> GetTodos()
        {
            var result = _trackerDbContext.Todo.ToList();
            return result;
        }
        public int AddTodo(Todo model)
        {
            var todo = new Todo()
            {
                Title = model.Title,
                Description = model.Description,
                Deadline = model.Deadline,
            };

            _trackerDbContext.Todo.Add(todo);
            _trackerDbContext.SaveChanges();

            return todo.Id;
        }
    }
}
