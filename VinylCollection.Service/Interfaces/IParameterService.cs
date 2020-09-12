using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Data.Models.Parameters;

namespace VinylCollection.Service.Interfaces
{
    public interface IParameterService
    {
        List<Country> GetCountries();
    }
}
