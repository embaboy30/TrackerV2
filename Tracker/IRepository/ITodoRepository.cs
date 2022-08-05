using Tracker.Data.Model;

namespace Tracker.IRepository
{
    public interface ITodoRepository
    {
        public List<Todo> GetTodos();
        public int AddTodo(Todo model);
    }
}
