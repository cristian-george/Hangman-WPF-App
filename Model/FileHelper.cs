using System.Collections.ObjectModel;
using System.IO;

namespace Hangman.Model
{
    internal class FileHelper
    {
        public static Collection<User> Users;

        public static void CreateFile(User user)
        {
            string fileName = "../../Data/Users/" + user.Username + ".txt";
            StreamWriter streamWriter = File.CreateText(fileName);
            streamWriter.WriteLine(user.Username);
            streamWriter.WriteLine(user.GamesPlayed);
            streamWriter.WriteLine(user.GamesWon);
            streamWriter.Dispose();
        }

        public static Collection<User> GetUsers()
        {
            string[] files = Directory.GetFiles("../../Data/Users");

            foreach (string file in files)
            {
                StreamReader streamReader = new StreamReader(file);
                string username = streamReader.ReadLine();
                int gamesPlayed = int.Parse(streamReader.ReadLine());
                int gamesWon = int.Parse(streamReader.ReadLine());

                Users = new Collection<User>();
                Users.Add(new User()
                {
                    Username = username,
                    GamesPlayed = gamesPlayed,
                    GamesWon = gamesWon
                });
            }

            return Users;
        }
    }
}
