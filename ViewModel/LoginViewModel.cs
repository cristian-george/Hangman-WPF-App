using Hangman.Commands;
using Hangman.Model;
using Hangman.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hangman.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public Collection<string> Images { get; set; }
        public User SelectedUser { get; set; }
        public string SelectedImage { get; set; }

        private static int m_SelectedImageIndex = 0;

        public LoginViewModel()
        {
            Users = new ObservableCollection<User>();
            Images = new Collection<string>();

            int avatars = 8;
            for (int id = 1; id <= avatars; ++id)
            {
                string imagePath = ImageHelper.GetAvatar(id);
                Images.Add(imagePath);
            }

            SelectedImage = Images[m_SelectedImageIndex];
        }


        #region Add user
        private ICommand m_addUser;
        public ICommand AddUserCommand
        {
            get
            {
                if (m_addUser == null)
                    m_addUser = new RelayCommand(AddUser);
                return m_addUser;
            }
        }

        public void AddUser(object parameter)
        {
            DialogBox dialogBox = new DialogBox();
            List<string> prop = new List<string>
                {
                    "Type a new username: "
                };

            dialogBox.CreateDialogBox(prop);
            dialogBox.ShowDialog();

            List<string> response = dialogBox.GetResponseTexts();
            if (response != null && response.Count != 0)
            {
                string username = response[0];
                Users.Add(new User(username));
            }
        }
        #endregion

        #region Delete user
        private ICommand m_deleteUser;
        public ICommand DeleteUserCommand
        {
            get
            {
                if (m_deleteUser == null)
                    m_deleteUser = new RelayCommand(DeleteUser);
                return m_deleteUser;
            }
        }

        public void DeleteUser(object parameter)
        {
            Users.Remove(SelectedUser);
        }
        #endregion

        #region Play
        private ICommand m_play;
        public ICommand PlayCommand
        {
            get
            {
                if (m_play == null)
                    m_play = new RelayCommand(Play);
                return m_play;
            }
        }

        public void Play(object parameter)
        {
            SelectedUser.ImagePath = SelectedImage;
            GameWindow gameWindow = new GameWindow();
            (gameWindow.DataContext as GameViewModel).User = SelectedUser;
            gameWindow.Show();

            System.Windows.Application.Current.Windows[0].Close();
        }
        #endregion

        #region Exit
        private ICommand m_exit;
        public ICommand ExitCommand
        {
            get
            {
                if (m_exit == null)
                    m_exit = new RelayCommand(Exit);
                return m_exit;
            }
        }

        public void Exit(object parameter)
        {
            System.Environment.Exit(0);
        }
        #endregion

        #region Previous image
        private ICommand m_previous;
        public ICommand PreviousCommand
        {
            get
            {
                if (m_previous == null)
                    m_previous = new RelayCommand(Previous);
                return m_previous;
            }
        }

        public void Previous(object parameter)
        {
            m_SelectedImageIndex = (m_SelectedImageIndex - 1 + Images.Count) % Images.Count;
            SelectedImage = Images[m_SelectedImageIndex];
            NotifyPropertyChanged("SelectedImage");
        }
        #endregion

        #region Next image
        private ICommand m_next;
        public ICommand NextCommand
        {
            get
            {
                if (m_next == null)
                    m_next = new RelayCommand(Next);
                return m_next;
            }
        }

        public void Next(object parameter)
        {
            m_SelectedImageIndex = (m_SelectedImageIndex + 1 + Images.Count) % Images.Count;
            SelectedImage = Images[m_SelectedImageIndex];
            NotifyPropertyChanged("SelectedImage");
        }
        #endregion
    }
}
