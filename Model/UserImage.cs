using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Model
{
    internal class UserImage
    {
        public static string GetImage(int id)
        {
            string imagePath = "..\\Images\\UserImages\\user" + id.ToString() + ".png";
            return imagePath;
        }

        public static int GetId(string imagePath)
        {
            return imagePath[imagePath.Length - 5];
        }
    }
}
