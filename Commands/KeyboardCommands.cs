using Hangman.ViewModel;
using System.Windows.Input;

namespace Hangman.Commands
{
    internal class KeyboardCommands : BaseViewModel
    {
        private readonly GameViewModel gameViewModel;

        public KeyboardCommands(object dataContext)
        {
            gameViewModel = dataContext as GameViewModel;
        }

        private ICommand m_pressKey;
        public ICommand PressKey
        {
            get
            {
                if (m_pressKey == null)
                    m_pressKey = new RelayCommand(IsKeyPressed);
                return m_pressKey;
            }
        }

        public void IsKeyPressed(object parameter)
        {
            char key = (char)parameter;
            gameViewModel.Buttons[key].IsEnabled = false;
            gameViewModel.IsCharPresent(key);
        }
    }
}
