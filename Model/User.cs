using Hangman.ViewModel;

namespace Hangman.Model
{
    internal class User : BaseViewModel
    {
        public string Username { get; set; }
        public string ImagePath { get; set; }

        public User(string username, string imagePath = "")
        {
            Username = username;
            ImagePath = imagePath;
        }
    }
}
