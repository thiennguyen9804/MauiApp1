using MauiApp1.Models;

namespace MauiApp1.Services;

public interface ITodoApiService
{
    Task<List<TodoItem>> GetTodoListAsync();
    Task AddTodoAsync(string item);
    Task UpdateTodoAsync(TodoItem updateTodo);
}