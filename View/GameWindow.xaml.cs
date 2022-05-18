using Hangman.ViewModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Hangman.View
{
    public partial class GameWindow : Window
    {
        private readonly GameViewModel gameViewModel;

        public GameWindow()
        {
            InitializeComponent();

            gameViewModel = new GameViewModel();
            DataContext = gameViewModel;
            menu.DataContext = gameViewModel.menuCommands;
            keyboard.DataContext = gameViewModel.keyboardCommands;

            InitializeKeyboard();
        }

        public void InitializeKeyboard()
        {
            gameViewModel.Buttons = new Dictionary<char, Button>
            {
                { 'Q', Q }, { 'W', W }, { 'E', E }, { 'R', R }, { 'T', T }, { 'Y', Y }, { 'U', U }, { 'I', I }, { 'O', O }, { 'P', P },
                     { 'A', A }, { 'S', S }, { 'D', D }, { 'F', F }, { 'G', G }, { 'H', H }, { 'J', J }, { 'K', K }, { 'L', L },
                          { 'Z', Z }, { 'X', X }, { 'C', C }, { 'V', V }, { 'B', B }, { 'N', N }, { 'M', M }
            };

            foreach (var button in gameViewModel.Buttons)
            {
                button.Value.CommandParameter = button.Key;
                button.Value.IsEnabled = false;
            }
        }
    }
}
