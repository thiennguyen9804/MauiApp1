using System.Net.Http.Json;
using MauiApp1.Models;

namespace MauiApp1.Services;

public class TodoApiService(HttpClient http) : ITodoApiService
{
    public async Task<List<TodoItem>> GetTodoListAsync()
    {
        var response = await http.GetAsync("todos");
        response.EnsureSuccessStatusCode();
        var items = await response.Content.ReadFromJsonAsync<List<TodoItem>>();
        return items ?? new();
    }

    public async Task AddTodoAsync(string title)
    {
        var newTodo = new TodoItem { Title = title, IsCompleted = false };
        await http.PostAsJsonAsync("todos", newTodo);
    }

    public async Task UpdateTodoAsync(TodoItem updateTodo)
    {
        await http.PutAsJsonAsync($"todos/{updateTodo.Id}", updateTodo);
    }
}