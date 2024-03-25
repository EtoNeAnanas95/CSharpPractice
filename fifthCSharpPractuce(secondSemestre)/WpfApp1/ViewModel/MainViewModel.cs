using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.View;
using WpfApp1.ViewModel.Helper;

namespace WpfApp1.ViewModel;

public class MainViewModel : BindingHelper
{
    public event EventHandler RequestClose;
    public BindableCommand Command { get; set; }
    public MainViewModel()
    {
        //Command = new BindableCommand(_ => //какая функция);
        
    }
    
    public void Submit_textbox(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            MessageBox.Show("Please enter");
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}