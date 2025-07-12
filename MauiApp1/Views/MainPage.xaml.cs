using System.Collections.ObjectModel;
using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _mainViewModel = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = _mainViewModel;
        
    }
}