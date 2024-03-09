using System.Windows;

namespace WpfApp1;

public partial class EditTestWindow : Window
{
    public EditTestWindow(bool IsEditable)
    {
        InitializeComponent();
        if (!IsEditable) EditButton.IsEnabled = false;
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void EditButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Content = new EditTestWindowEditTestPage();
    }

    private void RunButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainFrame.Content = new EditTestWindowRunTestPage();
    }
}