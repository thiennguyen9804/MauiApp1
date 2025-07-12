using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public MainViewModel()
    {
        AddTodoCommand = new Command(AddTodo);
    }
    public ObservableCollection<TodoItem> TodoItems { get; set; } = new();
    private string title;

    public string Title
    {
        get => title;
        set
        {
            if (title != value)
            {
                title = value;
                OnPropertyChanged();
            }
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    private void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(Title))
        {
            TodoItems.Add(new TodoItem {Title = Title, IsCompleted = false});
            Title = string.Empty;
            OnPropertyChanged();
        }
    }
    
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public ICommand AddTodoCommand { get; }
}