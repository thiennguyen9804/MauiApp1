using System.Collections.ObjectModel;
using MauiApp1.Models;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public ObservableCollection<TodoItem> TodoItems { get; set; } = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
        
    }


    private void Button_OnClicked(object? sender, EventArgs e)
    {
        var todoTitle = TodoEntry.Text;
        if (string.IsNullOrWhiteSpace(todoTitle)) return;
        TodoItems.Add(new TodoItem { Title = todoTitle, IsCompleted = false});
        TodoEntry.Text = "";

    }
}