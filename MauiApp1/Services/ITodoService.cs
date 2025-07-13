using MauiApp1.Models;

namespace MauiApp1.Services;

public interface ITodoService
{
    Task<List<TodoItem>> GetTodoListAsync();
    Task<TodoItem> AddTodoAsync(string item);
    Task UpdateTodoAsync(TodoItem updateTodo);
}