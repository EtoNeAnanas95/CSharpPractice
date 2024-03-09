using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void EditTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainSpace.RowDefinitions.Count == 3)
            {
                MainSpace.RowDefinitions.Add(new RowDefinition());
                TextBox textBox1 = new TextBox()
                {
                    Text = "Введите кодовое слово для админа!",
                    FontFamily = new FontFamily("Cascadia Code"),
                    Foreground = Brushes.Gray,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255)),
                };
                textBox1.SelectionChanged += TextBox1_SelectionChanged;
                textBox1.KeyDown += TextBox1_KeyDown;
                Grid.SetRow(textBox1, 3);
                MainSpace.Children.Add(textBox1);
            }
        }
        
        private void RunTestButton_Click(object sender, RoutedEventArgs e)
        {
            EditTestWindow runTestWindow = new EditTestWindow(false);
            runTestWindow.Show();
            Close();
        }

        private void TextBox1_KeyDown(object sender, RoutedEventArgs e) 
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "бульк")
            {
                EditTestWindow editTestWindow = new EditTestWindow(true);
                editTestWindow.Show();
                Close();
            }
        }

        private void TextBox1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите кодовое слово для админа!")
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = "";
            }
        }
    }
}