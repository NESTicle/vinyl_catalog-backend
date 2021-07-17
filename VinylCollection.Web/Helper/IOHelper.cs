using System.IO;

namespace VinylCollection.Web.Helper
{
    public static class IOHelper
    {
        public static void CreateDirectory(string path)
        {
            bool folderExists = Directory.Exists(path);

            if (!folderExists)
                Directory.CreateDirectory(path);
        }
    }
}
