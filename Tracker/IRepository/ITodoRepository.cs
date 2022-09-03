﻿using Tracker.Data.Model;
using Tracker.Data.ViewModel;

namespace Tracker.IRepository
{
    public interface ITodoRepository
    {
        List<Todo> GetTodos();
        List<Todo> GetTodosByMonth(int month);
        int AddTodo(TodoDto model);
        int UpdateTodo(TodoDto model);
        int DeleteTodo(int id);
    }
}
