using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Domain.ViewModels.Base;

namespace VinylCollection.Domain.ViewModels.Security
{
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
