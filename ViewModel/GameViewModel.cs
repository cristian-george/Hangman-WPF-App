using Hangman.Commands;
using Hangman.Model;
using Hangman.View;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    internal class GameViewModel : BaseViewModel
    {
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
        { }
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
        { }
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
        { }
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
        { }
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
        { }
        #endregion

        #region Flowers
        private ICommand m_flowers;
        public ICommand Flowers
        {
            get
            {
                if (m_flowers == null)
                    m_flowers = new RelayCommand(SelectFlowers);
                return m_flowers;
            }
        }
        public void SelectFlowers(object parameter)
        { }
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
        { }
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
        }
        #endregion

        #endregion
    }
}
