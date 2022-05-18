using Hangman.Commands;
using Hangman.Model;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Hangman.ViewModel
{
    internal class GameViewModel : BaseViewModel
    {
        public MenuCommands menuCommands;
        public KeyboardCommands keyboardCommands;

        #region Properties

        private User user;
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyPropertyChanged("User");
            }
        }

        public string FullLevel
        {
            get
            {
                return "Level: " + level.ToString();
            }
        }


        private string hangmanImage;
        public string HangmanImage
        {
            get
            {
                return hangmanImage;
            }
            set
            {
                hangmanImage = value;
                NotifyPropertyChanged("HangmanImage");
            }
        }


        private string category;
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }


        private string underscoreWord;
        public string UnderscoreWord
        {
            get
            {
                return underscoreWord;
            }
            set
            {
                underscoreWord = value;
                NotifyPropertyChanged("UnderscoreWord");
            }
        }


        private int progressBar;
        public int ProgressBar
        {
            get
            {
                return progressBar;
            }
            set
            {
                progressBar = value;
                NotifyPropertyChanged("ProgressBar");
            }
        }


        private string gameState;
        public string GameState
        {
            get
            {
                return gameState;
            }
            set
            {
                gameState = value;
                NotifyPropertyChanged("GameState");
            }
        }

        public Dictionary<char, System.Windows.Controls.Button> Buttons { get; set; }

        #endregion

        #region Private members and constructor
        private Game game;

        private int level;
        private int wrongChoices;
        private string originalWord;

        public GameViewModel()
        {
            menuCommands = new MenuCommands(this);
            keyboardCommands = new KeyboardCommands(this);

            level = 1;
            HangmanImage = "..\\Images\\HangmanImages\\hang0.png";
            Category = "None";

            InitializeTimer();
        }
        #endregion

        #region Keyboard methods

        void EnableKeys()
        {
            foreach (var button in Buttons)
            {
                button.Value.IsEnabled = true;
            }
        }
        void DisableKeys()
        {
            foreach (var button in Buttons)
            {
                button.Value.IsEnabled = false;
            }
        }
        void HideKey(char key)
        {
            Buttons[key].IsEnabled = false;
        }

        #endregion

        #region Timer
        private System.Windows.Threading.DispatcherTimer timer;
        private void DispatcherTimer_Tick(object sender, System.EventArgs e)
        {
            ++ProgressBar;
            if (ProgressBar >= 60)
            {
                timer.Stop();
                ProgressBar = 60;

                GameState = "You have lost!";
                MessageBox.Show("The word was " + originalWord + "!");

                System.Threading.Thread.Sleep(2000);

                ResetGame();
                DisableKeys();
            }
        }

        void InitializeTimer()
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new System.EventHandler(DispatcherTimer_Tick);
            timer.Interval = new System.TimeSpan(0, 0, 1);
        }
        #endregion

        #region Game functionalities

        public void InitializeGame()
        {
            EnableKeys();
            game = new Game(Category);

            timer.Start();
            ProgressBar = 0;

            wrongChoices = 0;
            originalWord = game.originalWord;
            UnderscoreWord = game.underscoreWord;
            UnderscoreWord = FormatingWord();

            GameState = "";
            HangmanImage = "..\\Images\\HangmanImages\\hang0.png";
        }
        void ResetGame()
        {
            level = 1;
            NotifyPropertyChanged("FullLevel");

            ProgressBar = 0;

            originalWord = "";
            UnderscoreWord = "";
            GameState = "";
            Category = "None";

            HangmanImage = "..\\Images\\HangmanImages\\hang0.png";
        }

        public void LoadGame(string[] fileLines)
        {
            level = int.Parse(fileLines[1]);
            wrongChoices = int.Parse(fileLines[2]);
            ProgressBar = int.Parse(fileLines[3]);
            Category = fileLines[4];
            originalWord = fileLines[5];
            UnderscoreWord = fileLines[6];

            game = new Game
            {
                originalWord = originalWord,
                underscoreWord = underscoreWord
            };

            UnderscoreWord = FormatingWord();
            HangmanImage = "..\\Images\\HangmanImages\\hang" + wrongChoices.ToString() + ".png";
            NotifyPropertyChanged("FullLevel");

            EnableKeys();
            for (int c = 0; c < underscoreWord.Length; c++)
                if (char.IsLetter(underscoreWord[c]))
                    HideKey(underscoreWord[c]);

            timer.Start();
        }
        public void SaveGame()
        {
            if (originalWord == null || originalWord.Equals(""))
            {
                MessageBox.Show("The word is empty!");
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = "game",
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFile.ShowDialog() == true)
            {
                string filePath = saveFile.FileName;
                string fileContent = "";
                fileContent += user.Username + "\r\n";
                fileContent += level.ToString() + "\r\n";
                fileContent += wrongChoices.ToString() + "\r\n";
                fileContent += progressBar.ToString() + "\r\n";
                fileContent += category.ToString() + "\r\n";
                fileContent += originalWord + "\r\n";
                fileContent += game.underscoreWord;

                File.WriteAllText(filePath, fileContent);
            }
        }

        bool HasWon()
        {
            if (underscoreWord == originalWord)
            {
                timer.Stop();

                UnderscoreWord = FormatingWord();
                MessageBox.Show("You guessed the word!");

                if (level != 5)
                {
                    ++level;
                    NotifyPropertyChanged("FullLevel");
                    InitializeGame();
                }
                else if (level == 5 && wrongChoices < 7)
                {
                    GameState = "You have won!";
                    DisableKeys();
                }

                return true;
            }

            return false;
        }
        bool HasLost()
        {
            if (wrongChoices == 7)
            {
                timer.Stop();

                GameState = "You have lost!";
                MessageBox.Show("The word was " + originalWord + "!");

                System.Threading.Thread.Sleep(2000);

                ResetGame();
                DisableKeys();

                return true;
            }
            return false;
        }

        public void IsCharPresent(char key)
        {
            bool found = game.HangmanCheckLetter(key);

            if (found == true)
            {
                UnderscoreWord = game.underscoreWord;

                if (HasWon())
                    return;

                UnderscoreWord = FormatingWord();
            }
            else
            {
                ++wrongChoices;
                HangmanImage = "..\\Images\\HangmanImages\\hang" + wrongChoices.ToString() + ".png";

                if (HasLost())
                    return;
            }
        }
        private string FormatingWord()
        {
            string word = "";
            foreach (char letter in underscoreWord)
            {
                word += letter;
                word += " ";
            }

            word.Remove(word.Length - 1);
            return word;
        }

        #endregion
    }
}