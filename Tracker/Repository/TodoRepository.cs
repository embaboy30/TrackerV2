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
            _trackerDbContext.Todo.Add(data);
            _trackerDbContext.SaveChanges();

            return model.Id;
        }
    }
}
