using Hangman.Model;
using System.Collections.ObjectModel;

namespace Hangman.ViewModel
{
    internal class StatsViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public StatsViewModel()
        {
            Users = new ObservableCollection<User>();
            ReadStats();
        }

        void ReadStats()
        {
            foreach (string line in System.IO.File.ReadAllLines("../../Data/stats.txt"))
            {
                string[] words = line.Split(' ');
                User user = new User()
                {
                    Username = words[0],
                    GamesPlayed = int.Parse(words[1]),
                    GamesWon = int.Parse(words[2])
                };

                Users.Add(user);
            }
        }
    }
}
