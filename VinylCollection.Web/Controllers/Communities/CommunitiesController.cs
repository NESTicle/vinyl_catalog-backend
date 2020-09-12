using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Domain.Extensions;
using VinylCollection.Domain.Helper;
using VinylCollection.Domain.ViewModels.Communities;
using VinylCollection.Service.Interfaces;
using VinylCollection.Web.Helper;

namespace VinylCollection.Web.Controllers.Communities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : ControllerBase
    {
        private readonly ICommunityService _communityService;
        private readonly IMapper _mapper;

        public CommunitiesController(ICommunityService communityService, IMapper mapper)
        {
            _communityService = communityService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(nameof(GetCommunities))]
        public JsonResult GetCommunities([FromQuery] QueryParamsHelper queryParameters)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                var data = _communityService.GetCommunities(queryParameters, out long totalCount);
                var mapped = _mapper.Map<List<CommunityViewModel>>(data);

                var pagination = new
                {
                    totalCount,
                    pageSize = queryParameters.PageCount,
                    currentPage = queryParameters.Page,
                    totalPages = queryParameters.GetTotalPages(totalCount)
                };

                result.Data = new
                {
                    communities = mapped,
                    pagination
                };
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpPost]
        [Route(nameof(SaveCommunity))]
        public JsonResult SaveCommunity(CommunityViewModel model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                var community = _mapper.Map<Community>(model);
                result.Data = _communityService.SaveCommunity(community);
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpGet]
        [Route(nameof(GetCommunityByURL))]
        public JsonResult GetCommunityByURL([FromQuery] string url)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                if (string.IsNullOrEmpty(url))
                    throw new Exception("An error ocurred trying to get a community by url");

                var community = _mapper.Map<CommunityViewModel>(_communityService.GetCommunityByURL(url));
                result.Data = community;
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpGet]
        [Route(nameof(VerifyCommunityURL))]
        public JsonResult VerifyCommunityURL([FromQuery]string url)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                var community = _communityService.GetCommunityByURL(url);
                result.Data = community != null;
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }
    }
}
