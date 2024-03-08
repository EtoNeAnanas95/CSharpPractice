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
                    //Style = CreateWatermarkStyle()
                };
                textBox1.SelectionChanged += TextBox1_SelectionChanged;
                Separator separator1 = new Separator() { Margin = new Thickness(5, 20, 5, 0) };
                Grid.SetRow(textBox1, 3);
                Grid.SetRow(separator1, 3);
                MainSpace.Children.Add(textBox1);
                MainSpace.Children.Add(separator1);
            }
        }
        
        private void RunTestButton_Click(object sender, RoutedEventArgs e)
        {
            RunTestWindow runTestWindow = new RunTestWindow();
            runTestWindow.Show();
            Close();
        }
        
        // private Style CreateWatermarkStyle()
        // { 
        //     Style style = new Style(typeof(TextBox)); 
        //     Trigger trigger = new Trigger()
        //     {
        //         Property = TextBox.TextProperty,
        //         Value = ""
        //     };
        //     trigger.Setters.Add(new Setter(TextBox.ForegroundProperty, Brushes.Gray));
        //     trigger.Setters.Add(new Setter(TextBox.TextProperty, "Введите кодовое слово для админа!"));
        //     
        //     style.Triggers.Add(trigger);
        //     
        //     return style;
        // }

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