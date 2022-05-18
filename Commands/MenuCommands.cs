using Hangman.View;
using Hangman.ViewModel;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Hangman.Commands
{
    internal class MenuCommands : BaseViewModel
    {
        private readonly GameViewModel gameViewModel;

        public MenuCommands(object dataContext)
        {
            gameViewModel = dataContext as GameViewModel;
        }

        #region New game
        private ICommand m_new;
        public ICommand New
        {
            get
            {
                if (m_new == null)
                    m_new = new RelayCommand(NewGame);
                return m_new;
            }
        }

        public void NewGame(object parameter)
        {
            if (gameViewModel.Category.Equals("None"))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            gameViewModel.InitializeGame();
        }
        #endregion

        #region Load game
        private ICommand m_load;
        public ICommand Load
        {
            get
            {
                if (m_load == null)
                    m_load = new RelayCommand(LoadGame);
                return m_load;
            }
        }
        public void LoadGame(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Select a file",
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (openFile.ShowDialog() == true)
            {
                string filePath = openFile.FileName;

                StreamReader streamReader = new StreamReader(File.OpenRead(filePath));
                string fileContent = streamReader.ReadToEnd();
                streamReader.Dispose();

                string[] separators = new string[] { "\r\n" };
                string[] fileLines = fileContent.Split(separators, System.StringSplitOptions.None);

                if (fileLines[0].Equals(gameViewModel.User.Username))
                {
                    gameViewModel.LoadGame(fileLines);
                }
                else
                {
                    MessageBox.Show("You cannot load other player's game!");
                }
            }
        }
        #endregion

        #region Save game
        private ICommand m_save;
        public ICommand Save
        {
            get
            {
                if (m_save == null)
                    m_save = new RelayCommand(SaveGame);
                return m_save;
            }
        }
        public void SaveGame(object parameter)
        {
            if (gameViewModel.Category.Equals("None"))
            {
                MessageBox.Show("Wrong category!");
                return;
            }

            gameViewModel.SaveGame();
        }
        #endregion

        #region Statistics
        private ICommand m_statistics;
        public ICommand Statistics
        {
            get
            {
                if (m_statistics == null)
                    m_statistics = new RelayCommand(VisualizeStatistics);
                return m_statistics;
            }
        }
        public void VisualizeStatistics(object parameter)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.ShowDialog();
        }
        #endregion

        #region Exit
        private ICommand m_exit;
        public ICommand Exit
        {
            get
            {
                if (m_exit == null)
                    m_exit = new RelayCommand(ExitGame);
                return m_exit;
            }
        }
        public void ExitGame(object parameter)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            App.Current.Windows[0].Close();
        }
        #endregion

        #region Select category
        private ICommand m_selectCategory;
        public ICommand SelectCategory
        {
            get
            {
                if (m_selectCategory == null)
                    m_selectCategory = new RelayCommand(SelectCategories);
                return m_selectCategory;
            }
        }

        public void SelectCategories(object parameter)
        {
            gameViewModel.Category = (string)parameter;
        }
        #endregion

        #region About
        private ICommand m_about;
        public ICommand About
        {
            get
            {
                if (m_about == null)
                    m_about = new RelayCommand(VisualizeAbout);
                return m_about;
            }
        }
        public void VisualizeAbout(object parameter)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
        #endregion
    }
}
