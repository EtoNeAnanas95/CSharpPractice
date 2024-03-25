using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp1.ViewModel;

namespace WpfApp1.View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainViewModel mainViewModel = new MainViewModel();
        mainViewModel.RequestClose += (sender, args) => SetWeatherCity(); 
        MainFrame.Content = new WhatWeather();
        DataContext = mainViewModel;
    }

    public void SetWeatherCity()
    {
        MainFrame.Content = null;
        MessageBox.Show("jhfkjdskfsdnfhsjdkfisdhjbfshdjkfbkbj");
    }
}