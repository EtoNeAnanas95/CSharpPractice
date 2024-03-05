using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userPointer;
        private string botPointer;
        private string[] buttons = { "button1", "button2", "button3", "button4", "button5", "button6", "button7", "button8", "button9" };

        private void ChangePointer()
        {
            switch (userPointer)
            {
                case "O":
                    userPointer = "X";
                    botPointer = "O";
                    break;
                
                case "X":
                    userPointer = "O";
                    botPointer = "X";
                    break;
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            userPointer = "X";
            botPointer = "O";
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;

            // — Вы откуда?
            // — Из-под Питера.
            // — Сейчас все из-под Питера“. Конкретнее.
            // — Бишкек.
        }

        private bool IsNoStringStartingWithB()
        {
            foreach (string str in buttons)
            {
                if (str != null && str.StartsWith("b", StringComparison.OrdinalIgnoreCase)) return false;
            }
            return true;
        }


        private void BotStart()
        {
            if (IsNoStringStartingWithB())
            {
                MessageBox.Show("Чувак, ты бота переиграть не смог");
                return;
            }

            Random random = new Random();
            while (true)
            {
                string[] shuffledButtons = buttons.OrderBy(x => random.Next()).ToArray();
                if (shuffledButtons[0] == "O" || shuffledButtons[0] == "X") continue;
                else
                {
                    Button selectedButton = (Button)FindName(shuffledButtons[0]);
                    selectedButton.Content = botPointer;
                    selectedButton.IsEnabled = false;
                    DetectingUsedButton(selectedButton, botPointer);
                    bool check = CheckForWin();
                    if (check)
                    {
                        button1.IsEnabled = false;
                        button2.IsEnabled = false;
                        button3.IsEnabled = false;
                        button4.IsEnabled = false;
                        button5.IsEnabled = false;
                        button6.IsEnabled = false;
                        button7.IsEnabled = false;
                        button8.IsEnabled = false;
                        button9.IsEnabled = false;
                        MessageBox.Show("Чел тя бот попустил");
                    }
                    break;
                }
            }

        }

        private void PlayGame(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            pressedButton.Content = userPointer;
            pressedButton.IsEnabled = false;
            DetectingUsedButton(pressedButton, userPointer);
            bool check = CheckForWin();
            if (check)
            {
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                button4.IsEnabled = false;
                button5.IsEnabled = false;
                button6.IsEnabled = false;
                button7.IsEnabled = false;
                button8.IsEnabled = false;
                button9.IsEnabled = false;
                MessageBox.Show("Вы выиграли");
            }
            else BotStart();
        }

        private void DetectingUsedButton(Button pressedButton, string pointer)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (pressedButton.Name == buttons[i])
                {
                    buttons[i] = pointer;
                    break;
                }
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            ChangePointer();
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";

            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;

            string[] newButtons = { "button1", "button2", "button3", "button4", "button5", "button6", "button7", "button8", "button9" };
            buttons = newButtons;
        }

        private bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                int rowStartIndex = i * 3;
                if ((buttons[rowStartIndex] == buttons[rowStartIndex + 1] && buttons[rowStartIndex + 1] == buttons[rowStartIndex + 2]) ||
                    (buttons[i] == buttons[i + 3] && buttons[i + 3] == buttons[i + 6]))
                {
                    return true;
                }
            }

            if ((buttons[0] == buttons[4] && buttons[4] == buttons[8]) ||
                (buttons[2] == buttons[4] && buttons[4] == buttons[6]))
            {
                return true;
            }

            return false;
        }
    }
}
