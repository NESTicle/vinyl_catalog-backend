using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinylCollection.Service.Interfaces;
using VinylCollection.Web.Helper;

namespace VinylCollection.Web.Controllers.Parameters
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IParameterService _parameterService;

        public GenresController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        [Route(nameof(GetGenres))]
        public JsonResult GetGenres([FromQuery] bool getAll = false)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                if(getAll)
                {
                    result.Data = _parameterService.GetGenres();
                }
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpGet]
        [Route(nameof(GetSubGenresByGenreId))]
        public JsonResult GetSubGenresByGenreId([FromQuery]int id)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                result.Data = _parameterService.GetSubGenresByGenreId(id);
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
