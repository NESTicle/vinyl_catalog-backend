using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinylCollection.Domain.Helper;
using VinylCollection.Service.Interfaces;
using VinylCollection.Web.Helper;

namespace VinylCollection.Web.Controllers.Parameters
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IParameterService _parameterService;

        public CountriesController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        [Route(nameof(GetCountries))]
        public JsonResult GetCountries([FromQuery] string search)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                result.Data = _parameterService.GetCountries();
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
