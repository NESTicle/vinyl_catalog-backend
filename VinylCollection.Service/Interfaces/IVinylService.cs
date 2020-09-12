using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Data.Models.Vinyls;
using VinylCollection.Domain.Helper;

namespace VinylCollection.Service.Interfaces
{
    public interface IVinylService
    {
        /// <summary>
        /// Get a List of Vinyl with Pagination
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <param name="search">Query search parameter</param>
        /// <returns></returns>
        List<Vinyl> GetVinyls(QueryParamsHelper queryParameters, string search);

        /// <summary>
        /// Get a Vinyl filtered by Id
        /// </summary>
        /// <param name="id">Id Parameter</param>
        /// <returns></returns>
        Vinyl GetVinylById(int id);

        /// <summary>
        /// Save or Update a Vinyl
        /// </summary>
        /// <param name="vinyl">Entity Vinyl</param>
        /// <returns></returns>
        int SaveVinyl(Vinyl vinyl);
    }
}
