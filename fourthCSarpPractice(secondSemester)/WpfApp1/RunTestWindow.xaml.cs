﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1;

public partial class RunTestWindow
{
    private bool _testsExists = false;
    public RunTestWindow()
    {
        InitializeComponent();
    }
    
    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
    
    private void RunButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (!_testsExists)
        {
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "уууууууууупс";
            textBlock1.Opacity = 0.3;
            textBlock1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7a574a"));
            textBlock1.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock1.VerticalAlignment = VerticalAlignment.Center;
            textBlock1.FontFamily = new FontFamily("Arial Black");
            textBlock1.FontSize = 86;
            textBlock1.FontWeight = FontWeights.Bold;
            Grid.SetRow(textBlock1, 1);
            MainSpace.Children.Add(textBlock1);
            
            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = "Пока что нет ни одного вопроса, на который можно было бы дать ответ.\nПодождите пока появятся вопросы";
            textBlock2.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock2.VerticalAlignment = VerticalAlignment.Center;
            textBlock2.TextAlignment = TextAlignment.Center;
            textBlock2.FontFamily = new FontFamily("Arial Black");
            textBlock2.Width = 450;
            textBlock2.FontSize = 16;
            textBlock2.TextWrapping = TextWrapping.Wrap;
            Grid.SetRow(textBlock2, 1);
            MainSpace.Children.Add(textBlock2);
        }
    }
}