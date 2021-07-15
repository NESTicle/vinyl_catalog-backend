﻿using System;
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

        List<Genre> GetGenres();

        /// <summary>
        /// Get All Subgenres
        /// </summary>
        /// <param name="id">Genre Id</param>
        /// <returns></returns>
        List<SubGenre> GetSubGenresByGenreId(int id);

        /// <summary>
        /// Add a new country
        /// </summary>
        /// <param name="country">Country entity</param>
        /// <returns></returns>
        int AddCountry(Country country);

        /// <summary>
        /// Update a country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        int UpdateCountry(Country country);

        /// <summary>
        /// Add multiple countries
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddMultipleCountries(List<Country> model);
    }
}
