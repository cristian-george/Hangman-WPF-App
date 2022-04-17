using System;
using System.Windows.Input;

namespace Hangman.Commands
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> commandTask;

        public RelayCommand(Action<object> workToDo)
        {
            commandTask = workToDo;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }
    }
}
