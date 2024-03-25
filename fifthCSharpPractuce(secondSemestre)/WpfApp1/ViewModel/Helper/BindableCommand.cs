﻿using System.Windows.Input;

namespace WpfApp1.ViewModel.Helper;

public class BindableCommand : ICommand
{
    private Action<object> _execute;
    private Func<object, bool> _canExecute;
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    public BindableCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}