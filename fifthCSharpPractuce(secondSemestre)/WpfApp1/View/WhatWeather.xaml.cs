using System.Windows.Controls;
using WpfApp1.ViewModel;

namespace WpfApp1.View;

public partial class WhatWeather : Page
{
    public WhatWeather()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}