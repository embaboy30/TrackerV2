using Tracker.Data.Model;
using Tracker.Data.ViewModel;

namespace Tracker.IRepository
{
    public interface ITodoRepository
    {
        public List<Todo> GetTodos();
        public int AddTodo(TodoDto model);
    }
}
