using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinylCollection.Domain.Helper;

namespace VinylCollection.Domain.Extensions
{
    public static class QueryParametersExtensions
    {
        public static bool HasPrevious(this QueryParamsHelper queryParameters)
        {
            return (queryParameters.Page > 1);
        }

        public static bool HasNext(this QueryParamsHelper queryParameters, int totalCount)
        {
            return (queryParameters.Page < (int)GetTotalPages(queryParameters, totalCount));
        }

        public static double GetTotalPages(this QueryParamsHelper queryParameters, long totalCount)
        {
            return Math.Ceiling(totalCount / (double)queryParameters.PageCount);
        }

        public static bool HasQuery(this QueryParamsHelper queryParameters)
        {
            return !string.IsNullOrEmpty(queryParameters.Query);
        }

        public static bool IsDescending(this QueryParamsHelper queryParameters)
        {
            if (!string.IsNullOrEmpty(queryParameters.OrderBy))
            {
                return queryParameters.OrderBy.Split(' ').Last().ToLowerInvariant().StartsWith("desc");
            }
            return false;
        }
    }
}
