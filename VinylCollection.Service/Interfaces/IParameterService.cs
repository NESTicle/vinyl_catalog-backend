using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Data.Models.Parameters;

namespace VinylCollection.Service.Interfaces
{
    public interface IParameterService
    {
        /// <summary>
        /// Get a List of Countries
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();
    }
}
