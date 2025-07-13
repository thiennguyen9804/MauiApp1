using MauiApp1.Models;
using SQLite;

namespace MauiApp1.Services;

public class TodoItemDatabase : ITodoService
{
    private SQLiteAsyncConnection _database;

    private async Task Init()
    {
        if (_database != null)
            return;

        _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await _database.CreateTableAsync<TodoItem>();
    }

    public async Task<List<TodoItem>> GetTodoListAsync()
    {
        await Init();
        return await _database.Table<TodoItem>().ToListAsync();
    }

    public async Task<TodoItem> AddTodoAsync(string title)
    {
        await Init();

        var item = new TodoItem
        {
            Title = title,
            IsCompleted = false
        };

        await _database.InsertAsync(item);
        return item;

    }

    public async Task UpdateTodoAsync(TodoItem updateTodo)
    {
        await Init();
        await _database.UpdateAsync(updateTodo);
    }

    public async Task DeleteTodoAsync(TodoItem item)
    {
        await Init();
        await _database.DeleteAsync(item);
    }
}