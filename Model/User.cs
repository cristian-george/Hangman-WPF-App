using Hangman.ViewModel;
using System;

namespace Hangman.Model
{
    internal class User : BaseViewModel
    {
        public string Username { get; set; }
        public string ImagePath { get; set; }

        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

        public User() { }

        public User(string username, string imagePath = "")
        {
            Username = username;
            ImagePath = imagePath;
        }
    }
}
