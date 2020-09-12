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

        string GenerateJwt(User user);
    }
}
