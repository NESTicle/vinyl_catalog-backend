using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace VinylCollection.Domain.Helper
{
    public static class JwtHelper
    {
        public static byte[] GetHashKeyJwt()
        {
            return Encoding.ASCII.GetBytes("GnwOTaibVuMtMtStqrnx9AmhhZOwpQIKw7PxsspqkAluqWAcH0dweU03ojJf01fsLcyiaiATYXIHdCNr");
        }

        public static string GetTokenFromJWT(string jwt)
        {
            return jwt.Replace("Bearer ", "");
        }

        public static string GetUniqueName(string jwt)
        {
            try
            {
                if (string.IsNullOrEmpty(jwt))
                    throw new Exception("Please provide a jwt token");

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(GetTokenFromJWT(jwt));

                if (jwtToken == null)
                    throw new Exception("Jwt token has not been readed");

                return jwtToken.Payload["unique_name"].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
