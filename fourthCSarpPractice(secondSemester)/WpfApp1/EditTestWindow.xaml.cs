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
        if (CheckTestExist()) MainFrame.Content = new EditTestWindowRunTestPage();
        else MainFrame.Content = new EditTestWindowTestsNotFoundPage();
    }

    private bool CheckTestExist()
    {
        List<Test> listTests = Json.Deserialize<List<Test>>("Tests.json");
        if (listTests == null!) return false;
        else return true;
    }
}