using Hangman.Model;
using System.Windows;

namespace Hangman.View
{
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();

            InitializeKeyboard();
        }

        public void InitializeKeyboard()
        {
            #region Initialize keyboard
            DataProvider.Q = Q;
            DataProvider.W = W;
            DataProvider.E = E;
            DataProvider.R = R;
            DataProvider.T = T;
            DataProvider.Y = Y;
            DataProvider.U = U;
            DataProvider.I = I;
            DataProvider.O = O;
            DataProvider.P = P;

            DataProvider.A = A;
            DataProvider.S = S;
            DataProvider.D = D;
            DataProvider.F = F;
            DataProvider.G = G;
            DataProvider.H = H;
            DataProvider.J = J;
            DataProvider.K = K;
            DataProvider.L = L;

            DataProvider.Z = Z;
            DataProvider.X = X;
            DataProvider.C = C;
            DataProvider.V = V;
            DataProvider.B = B;
            DataProvider.N = N;
            DataProvider.M = M;
            #endregion
        }
    }
}
