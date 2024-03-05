using diary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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

        private List<Note> notes = new List<Note>();

        public MainWindow()
        {
            InitializeComponent();
            Date.Text = DateTime.Today.ToString();
            if (Function.Deserialize<List<Note>>("notes.json") != null) notes = Function.Deserialize<List<Note>>("notes.json");

            Notes.ItemsSource = FindNotes(DateOnly.FromDateTime(DateTime.Today));
        }

        private List<Note> FindNotes(DateOnly day)
        {
            if (notes == null) return new List<Note>();
            else return notes.Where(note => note.datetime == day).ToList();
        }

        private void Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker datepicker = sender as DatePicker;
            if (datepicker.SelectedDate != null) Notes.ItemsSource = FindNotes(DateOnly.FromDateTime((DateTime)datepicker.SelectedDate));
        }

        private void Notes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox.SelectedItem != null)
            {
                Note currentNote = (Note)listBox.SelectedItem;
                WriteName.Text = currentNote.name;
                WriteDescription.Text = currentNote.description;
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (WriteName.Text != string.Empty)
            {
                DateOnly.TryParse(Date.Text, out DateOnly day);
                Note note = new Note(day, WriteName.Text, WriteDescription.Text);
                notes.Add(note);
                Notes.ItemsSource = FindNotes(day);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Notes.SelectedItem != null)
            {
                DateOnly.TryParse(Date.Text, out DateOnly day);
                Note removeNote = (Note)Notes.SelectedItem;
                notes.Remove(removeNote);
                Notes.ItemsSource = FindNotes(day);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (WriteName.Text != null && Notes.SelectedItem != null)
            {
                Note currentNote = (Note)Notes.SelectedItem;
                Note savedNote = new Note(currentNote.datetime, WriteName.Text, WriteDescription.Text);
                notes[notes.FindIndex(note => note.name == currentNote.name)] = savedNote;
                Notes.ItemsSource = FindNotes(currentNote.datetime);
            }
        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Function.Serialize(notes, "notes.json");
        }
    }
}