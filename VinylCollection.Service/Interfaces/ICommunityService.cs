using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Domain.Helper;

namespace VinylCollection.Service.Interfaces
{
    public interface ICommunityService
    {
        /// <summary>
        /// Get all the communities paginated
        /// </summary>
        /// <param name="queryParams">Parameters used for pagination</param>
        /// <param name="totalCount">Total count for communities</param>
        /// <returns></returns>
        List<Community> GetCommunities(QueryParamsHelper queryParams, out long totalCount);

        /// <summary>
        /// Get a Community filtered by Id
        /// </summary>
        /// <param name="id">Community Id</param>
        /// <returns></returns>
        Community GetCommunityById(int id);

        /// <summary>
        /// Get a Community filtered by URL
        /// </summary>
        /// <param name="url">URL of the Community</param>
        /// <returns></returns>
        Community GetCommunityByURL(string url);

        /// <summary>
        /// Save or Update a Community
        /// </summary>
        /// <param name="community">Community Entity</param>
        /// <returns></returns>
        int SaveCommunity(Community community);
    }
}
