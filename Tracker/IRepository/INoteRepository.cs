using Tracker.Data.Model;

namespace Tracker.IRepository
{
    public interface INoteRepository
    {
        List<Note> GetTodoNotesById(int todoId);
        int AddNote(Note model, int todoId);
        int UpdateNote(Note model);
        int DeleteNote(int id);
    }
}
