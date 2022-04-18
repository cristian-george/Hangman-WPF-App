using System.Collections.ObjectModel;

namespace Hangman.Model
{
    internal class Game
    {
        public string originalWord;
        public string underscoreWord;

        public Game(string category)
        {
            Collection<string> words = GetWordsByCategory(category);
            originalWord = GetRandomWord(words);
            originalWord = originalWord.ToUpper();

            for (int i = 0; i < originalWord.Length; i++)
            {
                if (char.IsLetter(originalWord[i]))
                    underscoreWord += "_";
                else
                    underscoreWord += originalWord[i];
            }
        }

        private Collection<string> GetWordsByCategory(string category)
        {
            Collection<string> words = new Collection<string>();

            switch (category)
            {
                case "Animals":
                    foreach (string line in System.IO.File.ReadAllLines("../../Categories/animals.txt"))
                    {
                        words.Add(line);
                    }
                    break;

                case "Countries":
                    foreach (string line in System.IO.File.ReadAllLines("../../Categories/countries.txt"))
                    {
                        words.Add(line);
                    }
                    break;

                case "Plants":
                    foreach (string line in System.IO.File.ReadAllLines("../../Categories/plants.txt"))
                    {
                        words.Add(line);
                    }
                    break;

                case "All categories":
                    foreach (string line in System.IO.File.ReadAllLines("../../Categories/animals.txt"))
                    {
                        words.Add(line);
                    }
                    foreach (string line in System.IO.File.ReadAllLines("../../Categories/countries.txt"))
                    {
                        words.Add(line);
                    }
                    foreach (string line in System.IO.File.ReadAllLines("../../Categories/plants.txt"))
                    {
                        words.Add(line);
                    }
                    break;

                default:
                    break;
            }

            return words;
        }

        private string GetRandomWord(Collection<string> words)
        {
            System.Random random = new System.Random();
            int index = random.Next(0, words.Count);

            return words[index];
        }

        public bool HangmanCheckLetter(char keyPressed)
        {
            bool foundKey = false;
            System.Text.StringBuilder aux = new System.Text.StringBuilder(underscoreWord);

            for (int c = 0; c < originalWord.Length; ++c)
            {
                if (originalWord[c] == keyPressed)
                {
                    foundKey = true;
                    aux[c] = keyPressed;
                }
            }

            underscoreWord = aux.ToString();
            return foundKey;
        }
    }
}
