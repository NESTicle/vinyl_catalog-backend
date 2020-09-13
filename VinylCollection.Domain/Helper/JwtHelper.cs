using System.Text;

namespace VinylCollection.Domain.Helper
{
    public static class JwtHelper
    {
        public static byte[] GetHashKeyJwt()
        {
            return Encoding.ASCII.GetBytes("GnwOTaibVuMtMtStqrnx9AmhhZOwpQIKw7PxsspqkAluqWAcH0dweU03ojJf01fsLcyiaiATYXIHdCNr");
        }
    }
}
