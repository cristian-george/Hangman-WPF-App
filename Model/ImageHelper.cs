namespace Hangman.Model
{
    internal class ImageHelper
    {
        public static string GetAvatar(int id)
        {
            string imagePath = "..\\Images\\UserImages\\user" + id.ToString() + ".png";
            return imagePath;
        }
    }
}
