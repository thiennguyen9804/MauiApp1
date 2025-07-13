using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1.Core;
using MauiApp1.Models;
using MauiApp1.Services;

namespace MauiApp1.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ITodoService _todoService;
    public MainViewModel(ITodoService todoService)
    {
        AddTodoCommand = new AsyncCommand(AddTodoAsync);

        _todoService = todoService;
    }
    public ObservableCollection<TodoItem> TodoItems { get; } = new();
    private string _title = String.Empty;

    public string Title
    {
        get => _title;
        set
        {
            if (_title == value) return;
            _title = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public async Task AddTodoAsync()
    {
        if (string.IsNullOrWhiteSpace(Title)) return;

        var newItem = await _todoService.AddTodoAsync(Title);
        Title = string.Empty;
        TodoItems.Add(newItem);
    }


    public async Task LoadTodoItemsAsync()
    {
        var todoItems = await _todoService.GetTodoListAsync();
        TodoItems.Clear();
        foreach (var item in todoItems)
        {
            TodoItems.Add(item);
        }
    }
    
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public ICommand AddTodoCommand { get; }
}