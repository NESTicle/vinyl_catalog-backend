using System;
using System.Collections.Generic;
using System.Text;

namespace VinylCollection.Domain.ViewModels.Base
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
