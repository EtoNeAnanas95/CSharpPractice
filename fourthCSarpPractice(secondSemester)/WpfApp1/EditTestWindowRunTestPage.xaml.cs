using System.Windows;
using System.Windows.Controls;
namespace WpfApp1;

public partial class EditTestWindowRunTestPage : Page
{
    private List<Test> _listTests;
    private short _currentQuestion = 0;
    private short _rightAnswers = 0;
    
    public EditTestWindowRunTestPage()
    {
        InitializeComponent();
        
        _listTests = Json.Deserialize<List<Test>>("Tests.json");
        if (_listTests == null!) _listTests = new List<Test>();

        SwitchAttributesContent();
    }

    private void SwitchAttributesContent()
    {
        NameTextBlock.Text = _listTests[_currentQuestion].Name;
        DescriptionTextBlock.Text = _listTests[_currentQuestion].Description;
        _1AnswerButton.Content = _listTests[_currentQuestion].FirstAnswer;
        _2AnswerButton.Content = _listTests[_currentQuestion].SecondAnswer;
        _3AnswerButton.Content = _listTests[_currentQuestion].ThirdAnswer;
    }

    private void AnswerButton_OnClick(object sender, RoutedEventArgs e)
    {
        Button currentButton = (Button)sender;

        if (Convert.ToInt32(currentButton.Name[1].ToString())-1 == (int)_listTests[_currentQuestion].RightAnswer)
        {
            _rightAnswers++;
            AnswerResultTextBlock.Text = "ТЫ НЕВЕРЕОЯТНО ХАРОШ!!";
        }
        else AnswerResultTextBlock.Text = "ТЫ НЕВЕРЕОЯТНО ЛОХ(((";
        
        Thread.Sleep(1000);
        _currentQuestion++;
        
        if (_currentQuestion < _listTests.Count) SwitchAttributesContent();
        else
        {
            NameTextBlock.Text = $"Ну это типа всё, ты крч ответил правльно на {_rightAnswers} из {_listTests.Count}";
            DescriptionTextBlock.Text = String.Empty;
            AnswersGrid.Children.Clear();
        }
    }
}