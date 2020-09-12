using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VinylCollection.Data.Models.Base;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Domain.Helper;
using VinylCollection.Service.Interfaces;

namespace VinylCollection.Service.Implementations
{
    public class CommunityService : ICommunityService
    {
        private readonly VinylDbContext _context;

        public CommunityService(VinylDbContext context)
        {
            _context = context;
        }

        public List<Community> GetCommunities(QueryParamsHelper queryParams, out long totalCount)
        {
            try
            {
                var communities = _context.Community
                    .Where(x => x.Deleted == false)
                    .Include(x => x.User)
                    .AsNoTracking();

                totalCount = communities.Count();

                var communityList = communities
                    .Skip(queryParams.PageCount * (queryParams.Page - 1))
                    .Take(queryParams.PageCount)
                    .ToList();

                return communityList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Community GetCommunityById(int id)
        {
            try
            {
                return _context.Community.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Community GetCommunityByURL(string url)
        {
            try
            {
                return _context.Community.FirstOrDefault(x => x.URL.ToLower().Equals(url.ToLower()));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SaveCommunity(Community model)
        {
            try
            {
                if(model.Id <= 0)
                {
                    model.Id_User = 3;
                    _context.Community.Add(model);
                }
                else
                {
                    var entity = GetCommunityById(model.Id);

                    entity.Name = model.Name;
                    entity.URL = model.URL;
                    entity.Description = model.Description;
                    entity.NSFW = model.NSFW;
                    entity.PublishRule = model.PublishRule;
                    entity.CommentRule = model.CommentRule;
                }

                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
