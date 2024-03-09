using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1;

public partial class EditTestWindowEditTestPage : Page
{
    private List<Test> listTests;

    public EditTestWindowEditTestPage()
    {
        InitializeComponent();
        
        listTests = Json.Deserialize<List<Test>>("Tests.json");
        if (listTests == null) listTests = new List<Test>();
        
        MainGrid.ItemsSource = listTests;
    }
    private void MainGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
        Json.Serialize(listTests, "Tests.json");
    }


    private void EditTestWindowEditTestPage_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N)
        {
            listTests.Add(new Test("", "", "", "", ""));
            Json.Serialize(listTests, "Tests.json");
            MainGrid.ItemsSource = null;
            MainGrid.ItemsSource = listTests;
        }
        else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D)
        {
            listTests.RemoveAt(listTests.Count - 1);
            Json.Serialize(listTests, "Tests.json");
            MainGrid.ItemsSource = null;
            MainGrid.ItemsSource = listTests;
        }
    }
}