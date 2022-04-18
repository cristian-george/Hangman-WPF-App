using Hangman.Commands;
using Hangman.Model;
using Hangman.View;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    internal class GameViewModel : BaseViewModel
    {
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

        #endregion

        #region Private members and constructor
        private Game game;

        private int level;
        private int wrongChoices;
        private string originalWord;

        public GameViewModel()
        {
            level = 1;
            HangmanImage = "..\\Images\\HangmanImages\\hang0.png";
            Category = "None";

            InitializeTimer();
        }
        #endregion

        #region Ui elements

        void EnableKeys()
        {
            DataProvider.Q.IsEnabled = true;
            DataProvider.W.IsEnabled = true;
            DataProvider.E.IsEnabled = true;
            DataProvider.R.IsEnabled = true;
            DataProvider.T.IsEnabled = true;
            DataProvider.Y.IsEnabled = true;
            DataProvider.U.IsEnabled = true;
            DataProvider.I.IsEnabled = true;
            DataProvider.O.IsEnabled = true;
            DataProvider.P.IsEnabled = true;
            DataProvider.A.IsEnabled = true;
            DataProvider.S.IsEnabled = true;
            DataProvider.D.IsEnabled = true;
            DataProvider.F.IsEnabled = true;
            DataProvider.G.IsEnabled = true;
            DataProvider.H.IsEnabled = true;
            DataProvider.J.IsEnabled = true;
            DataProvider.K.IsEnabled = true;
            DataProvider.L.IsEnabled = true;
            DataProvider.Z.IsEnabled = true;
            DataProvider.X.IsEnabled = true;
            DataProvider.C.IsEnabled = true;
            DataProvider.V.IsEnabled = true;
            DataProvider.B.IsEnabled = true;
            DataProvider.N.IsEnabled = true;
            DataProvider.M.IsEnabled = true;
        }
        void DisableKeys()
        {
            DataProvider.Q.IsEnabled = false;
            DataProvider.W.IsEnabled = false;
            DataProvider.E.IsEnabled = false;
            DataProvider.R.IsEnabled = false;
            DataProvider.T.IsEnabled = false;
            DataProvider.Y.IsEnabled = false;
            DataProvider.U.IsEnabled = false;
            DataProvider.I.IsEnabled = false;
            DataProvider.O.IsEnabled = false;
            DataProvider.P.IsEnabled = false;
            DataProvider.A.IsEnabled = false;
            DataProvider.S.IsEnabled = false;
            DataProvider.D.IsEnabled = false;
            DataProvider.F.IsEnabled = false;
            DataProvider.G.IsEnabled = false;
            DataProvider.H.IsEnabled = false;
            DataProvider.J.IsEnabled = false;
            DataProvider.K.IsEnabled = false;
            DataProvider.L.IsEnabled = false;
            DataProvider.Z.IsEnabled = false;
            DataProvider.X.IsEnabled = false;
            DataProvider.C.IsEnabled = false;
            DataProvider.V.IsEnabled = false;
            DataProvider.B.IsEnabled = false;
            DataProvider.N.IsEnabled = false;
            DataProvider.M.IsEnabled = false;
        }

        void ShowRectangles()
        {
            switch (wrongChoices)
            {
                case 1:
                    DataProvider.Rectangle1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    DataProvider.Rectangle2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    DataProvider.Rectangle3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    DataProvider.Rectangle4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    DataProvider.Rectangle5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    DataProvider.Rectangle6.Visibility = Visibility.Visible;
                    break;
                case 7:
                    DataProvider.Rectangle7.Visibility = Visibility.Visible;
                    break;

                default:
                    break;
            }
        }
        void HideRectangles()
        {
            DataProvider.Rectangle1.Visibility = Visibility.Hidden;
            DataProvider.Rectangle2.Visibility = Visibility.Hidden;
            DataProvider.Rectangle3.Visibility = Visibility.Hidden;
            DataProvider.Rectangle4.Visibility = Visibility.Hidden;
            DataProvider.Rectangle5.Visibility = Visibility.Hidden;
            DataProvider.Rectangle6.Visibility = Visibility.Hidden;
            DataProvider.Rectangle7.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Timer
        private System.Windows.Threading.DispatcherTimer timer;
        private void DispatcherTimer_Tick(object sender, System.EventArgs e)
        {
            ++ProgressBar;
            if (ProgressBar >= 30)
            {
                timer.Stop();
                ProgressBar = 30;

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

        void InitializeGame()
        {
            EnableKeys();
            HideRectangles();

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

            HideRectangles();
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

        void IsCharPresent(char key)
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
                ShowRectangles();

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

        #region Commands

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
            if (Category.Equals("None"))
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            InitializeGame();
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
                string[] lines = fileContent.Split(separators, System.StringSplitOptions.None);

                if (lines[0].Equals(user.Username))
                {
                    level = int.Parse(lines[1]);
                    wrongChoices = int.Parse(lines[2]);
                    ProgressBar = int.Parse(lines[3]);
                    Category = lines[4];
                    originalWord = lines[5];
                    UnderscoreWord = lines[6];

                    NotifyPropertyChanged("FullLevel");

                    timer.Start();
                    EnableKeys();

                    for (int i = 1; i <= wrongChoices; ++i)
                        ShowRectangles();
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
            SaveFileDialog saveFile = new SaveFileDialog
            {
                FileName = "game",
                Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (saveFile.ShowDialog() == true)
            {
                string filePath = saveFile.FileName;
                string fileContent = "";
                fileContent += user.Username + "\n";
                fileContent += level.ToString() + "\n";
                fileContent += wrongChoices.ToString() + "\n";
                fileContent += category.ToString() + "\n";
                fileContent += originalWord + "\n";
                fileContent += underscoreWord;

                File.WriteAllText(filePath, fileContent);
            }
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

        #region All categories
        private ICommand m_allCategories;
        public ICommand AllCategories
        {
            get
            {
                if (m_allCategories == null)
                    m_allCategories = new RelayCommand(SelectAllCategories);
                return m_allCategories;
            }
        }
        public void SelectAllCategories(object parameter)
        {
            Category = "All categories";
        }
        #endregion

        #region Animals
        private ICommand m_animals;
        public ICommand Animals
        {
            get
            {
                if (m_animals == null)
                    m_animals = new RelayCommand(SelectAnimals);
                return m_animals;
            }
        }
        public void SelectAnimals(object parameter)
        {
            Category = "Animals";
        }
        #endregion

        #region Plants
        private ICommand m_plants;
        public ICommand Plants
        {
            get
            {
                if (m_plants == null)
                    m_plants = new RelayCommand(SelectPlants);
                return m_plants;
            }
        }
        public void SelectPlants(object parameter)
        {
            Category = "Plants";
        }
        #endregion

        #region Countries
        private ICommand m_countries;
        public ICommand Countries
        {
            get
            {
                if (m_countries == null)
                    m_countries = new RelayCommand(SelectCountries);
                return m_countries;
            }
        }
        public void SelectCountries(object parameter)
        {
            Category = "Countries";
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

        #region Keys

        #region Q
        private ICommand m_pressQ;
        public ICommand PressQ
        {
            get
            {
                if (m_pressQ == null)
                    m_pressQ = new RelayCommand(IsPressedQ);
                return m_pressQ;
            }
        }

        public void IsPressedQ(object parameter)
        {
            DataProvider.Q.IsEnabled = false;
            IsCharPresent('Q');
        }
        #endregion

        #region W
        private ICommand m_pressW;
        public ICommand PressW
        {
            get
            {
                if (m_pressW == null)
                    m_pressW = new RelayCommand(IsPressedW);
                return m_pressW;
            }
        }

        public void IsPressedW(object parameter)
        {
            DataProvider.W.IsEnabled = false;
            IsCharPresent('W');
        }
        #endregion

        #region E
        private ICommand m_pressE;
        public ICommand PressE
        {
            get
            {
                if (m_pressE == null)
                    m_pressE = new RelayCommand(IsPressedE);
                return m_pressE;
            }
        }

        public void IsPressedE(object parameter)
        {
            DataProvider.E.IsEnabled = false;
            IsCharPresent('E');
        }
        #endregion

        #region R
        private ICommand m_pressR;
        public ICommand PressR
        {
            get
            {
                if (m_pressR == null)
                    m_pressR = new RelayCommand(R_isPressed);
                return m_pressR;
            }
        }

        public void R_isPressed(object parameter)
        {
            DataProvider.R.IsEnabled = false;
            IsCharPresent('R');
        }
        #endregion

        #region T
        private ICommand m_pressT;
        public ICommand PressT
        {
            get
            {
                if (m_pressT == null)
                    m_pressT = new RelayCommand(T_isPressed);
                return m_pressT;
            }
        }

        public void T_isPressed(object parameter)
        {
            DataProvider.T.IsEnabled = false;
            IsCharPresent('T');
        }
        #endregion

        #region Y
        private ICommand m_pressY;
        public ICommand PressY
        {
            get
            {
                if (m_pressY == null)
                    m_pressY = new RelayCommand(Y_isPressed);
                return m_pressY;
            }
        }

        public void Y_isPressed(object parameter)
        {
            DataProvider.Y.IsEnabled = false;
            IsCharPresent('Y');
        }
        #endregion

        #region U
        private ICommand m_pressU;
        public ICommand PressU
        {
            get
            {
                if (m_pressU == null)
                    m_pressU = new RelayCommand(U_isPressed);
                return m_pressU;
            }
        }

        public void U_isPressed(object parameter)
        {
            DataProvider.U.IsEnabled = false;
            IsCharPresent('U');
        }
        #endregion

        #region I
        private ICommand m_pressI;
        public ICommand PressI
        {
            get
            {
                if (m_pressI == null)
                    m_pressI = new RelayCommand(I_isPressed);
                return m_pressI;
            }
        }

        public void I_isPressed(object parameter)
        {
            DataProvider.I.IsEnabled = false;
            IsCharPresent('I');
        }
        #endregion

        #region O
        private ICommand m_pressO;
        public ICommand PressO
        {
            get
            {
                if (m_pressO == null)
                    m_pressO = new RelayCommand(O_isPressed);
                return m_pressO;
            }
        }

        public void O_isPressed(object parameter)
        {
            DataProvider.O.IsEnabled = false;
            IsCharPresent('O');
        }
        #endregion

        #region P
        private ICommand m_pressP;
        public ICommand PressP
        {
            get
            {
                if (m_pressP == null)
                    m_pressP = new RelayCommand(P_isPressed);
                return m_pressP;
            }
        }

        public void P_isPressed(object parameter)
        {
            DataProvider.P.IsEnabled = false;
            IsCharPresent('P');
        }
        #endregion

        #region A
        private ICommand m_pressA;
        public ICommand PressA
        {
            get
            {
                if (m_pressA == null)
                    m_pressA = new RelayCommand(A_isPressed);
                return m_pressA;
            }
        }

        public void A_isPressed(object parameter)
        {
            DataProvider.A.IsEnabled = false;
            IsCharPresent('A');
        }
        #endregion

        #region S
        private ICommand m_pressS;
        public ICommand PressS
        {
            get
            {
                if (m_pressS == null)
                    m_pressS = new RelayCommand(S_isPressed);
                return m_pressS;
            }
        }

        public void S_isPressed(object parameter)
        {
            DataProvider.S.IsEnabled = false;
            IsCharPresent('S');
        }
        #endregion

        #region D
        private ICommand m_pressD;
        public ICommand PressD
        {
            get
            {
                if (m_pressD == null)
                    m_pressD = new RelayCommand(D_isPressed);
                return m_pressD;
            }
        }

        public void D_isPressed(object parameter)
        {
            DataProvider.D.IsEnabled = false;
            IsCharPresent('D');
        }
        #endregion

        #region F
        private ICommand m_pressF;
        public ICommand PressF
        {
            get
            {
                if (m_pressF == null)
                    m_pressF = new RelayCommand(F_isPressed);
                return m_pressF;
            }
        }

        public void F_isPressed(object parameter)
        {
            DataProvider.F.IsEnabled = false;
            IsCharPresent('F');
        }
        #endregion

        #region G
        private ICommand m_pressG;
        public ICommand PressG
        {
            get
            {
                if (m_pressG == null)
                    m_pressG = new RelayCommand(G_isPressed);
                return m_pressG;
            }
        }

        public void G_isPressed(object parameter)
        {
            DataProvider.G.IsEnabled = false;
            IsCharPresent('G');
        }
        #endregion

        #region H
        private ICommand m_pressH;
        public ICommand PressH
        {
            get
            {
                if (m_pressH == null)
                    m_pressH = new RelayCommand(H_isPressed);
                return m_pressH;
            }
        }

        public void H_isPressed(object parameter)
        {
            DataProvider.H.IsEnabled = false;
            IsCharPresent('H');
        }
        #endregion

        #region J
        private ICommand m_pressJ;
        public ICommand PressJ
        {
            get
            {
                if (m_pressJ == null)
                    m_pressJ = new RelayCommand(J_isPressed);
                return m_pressJ;
            }
        }

        public void J_isPressed(object parameter)
        {
            DataProvider.J.IsEnabled = false;
            IsCharPresent('J');
        }
        #endregion

        #region K
        private ICommand m_pressK;
        public ICommand PressK
        {
            get
            {
                if (m_pressK == null)
                    m_pressK = new RelayCommand(K_isPressed);
                return m_pressK;
            }
        }

        public void K_isPressed(object parameter)
        {
            DataProvider.K.IsEnabled = false;
            IsCharPresent('K');
        }
        #endregion

        #region L
        private ICommand m_pressL;
        public ICommand PressL
        {
            get
            {
                if (m_pressL == null)
                    m_pressL = new RelayCommand(L_isPressed);
                return m_pressL;
            }
        }

        public void L_isPressed(object parameter)
        {
            DataProvider.L.IsEnabled = false;
            IsCharPresent('L');
        }
        #endregion

        #region Z
        private ICommand m_pressZ;
        public ICommand PressZ
        {
            get
            {
                if (m_pressZ == null)
                    m_pressZ = new RelayCommand(Z_isPressed);
                return m_pressZ;
            }
        }

        public void Z_isPressed(object parameter)
        {
            DataProvider.Z.IsEnabled = false;
            IsCharPresent('Z');
        }
        #endregion

        #region X
        private ICommand m_pressX;
        public ICommand PressX
        {
            get
            {
                if (m_pressX == null)
                    m_pressX = new RelayCommand(X_isPressed);
                return m_pressX;
            }
        }

        public void X_isPressed(object parameter)
        {
            DataProvider.X.IsEnabled = false;
            IsCharPresent('X');
        }
        #endregion

        #region C
        private ICommand m_pressC;
        public ICommand PressC
        {
            get
            {
                if (m_pressC == null)
                    m_pressC = new RelayCommand(C_isPressed);
                return m_pressC;
            }
        }

        public void C_isPressed(object parameter)
        {
            DataProvider.C.IsEnabled = false;
            IsCharPresent('C');
        }
        #endregion

        #region V
        private ICommand m_pressV;
        public ICommand PressV
        {
            get
            {
                if (m_pressV == null)
                    m_pressV = new RelayCommand(V_isPressed);
                return m_pressV;
            }
        }

        public void V_isPressed(object parameter)
        {
            DataProvider.V.IsEnabled = false;
            IsCharPresent('V');
        }
        #endregion

        #region B
        private ICommand m_pressB;
        public ICommand PressB
        {
            get
            {
                if (m_pressB == null)
                    m_pressB = new RelayCommand(B_isPressed);
                return m_pressB;
            }
        }

        public void B_isPressed(object parameter)
        {
            DataProvider.B.IsEnabled = false;
            IsCharPresent('B');
        }
        #endregion

        #region N
        private ICommand m_pressN;
        public ICommand PressN
        {
            get
            {
                if (m_pressN == null)
                    m_pressN = new RelayCommand(IsPressedN);
                return m_pressN;
            }
        }

        public void IsPressedN(object parameter)
        {
            DataProvider.N.IsEnabled = false;
            IsCharPresent('N');
        }
        #endregion

        #region M
        private ICommand m_pressM;
        public ICommand PressM
        {
            get
            {
                if (m_pressM == null)
                    m_pressM = new RelayCommand(IsPressedM);
                return m_pressM;
            }
        }

        public void IsPressedM(object parameter)
        {
            DataProvider.M.IsEnabled = false;
            IsCharPresent('M');
        }
        #endregion

        #endregion

        #endregion
    }
}