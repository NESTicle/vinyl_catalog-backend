using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Data.Models.Security;

namespace VinylCollection.Service.Interfaces
{
    public interface IUserService
    {
        int RegisterAccount(User model);

        User LoginUser(User user);

        /// <summary>
        /// Get an username filtered by userName
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        string GenerateJwt(User user);
    }
}
