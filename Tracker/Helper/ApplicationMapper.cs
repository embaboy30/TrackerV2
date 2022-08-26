using AutoMapper;
using Tracker.Data.Model;
using Tracker.Data.ViewModel;

namespace Tracker.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}
