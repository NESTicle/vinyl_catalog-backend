using System.Text;

namespace VinylCollection.Domain.Helper
{
    public static class EncodingHelper
    {
        public static string EncodeBase64(string text)
        {
            if (text == null)
                return null;

            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(textAsBytes);
        }

        public static string DecodeBase64(string encodedText)
        {
            if (encodedText == null)
                return null;

            byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(textAsBytes);
        }
    }
}
