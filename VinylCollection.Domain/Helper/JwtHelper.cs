using System;
using System.Collections.Generic;
using System.Text;

namespace VinylCollection.Domain.Helper
{
    public static class JwtHelper
    {
        public static byte[] GetHashKeyJwt()
        {
            return Encoding.ASCII.GetBytes("1JjMjU2YThhZjRjYmFkMTM5ZjA2MGEI5OGVTIxMTk5MjzNTAzjQ1YjE2NmY2NMGY4YWNhZwlMzZiOGJhZ==");
        }
    }
}
