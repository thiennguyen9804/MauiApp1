

using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _mainViewModel;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        _mainViewModel = vm;
        BindingContext = vm;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _mainViewModel.LoadTodoItemsAsync();
    }
}