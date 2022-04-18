using System;
using System.Windows.Input;

namespace Hangman.Commands
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> commandTask = null;
        private readonly Predicate<object> canExecuteTask = null;

        public RelayCommand(Action<object> workToDo)
        {
            commandTask = workToDo;
            canExecuteTask = null;
        }

        public RelayCommand(Action<object> workToDo, Predicate<object> canExecute)
        {
            if (workToDo == null)
                throw new ArgumentNullException("execute");

            commandTask = workToDo;
            canExecuteTask = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteTask == null || canExecuteTask(parameter);
        }

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }
    }
}
