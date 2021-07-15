using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VinylCollection.Data.Models.Parameters;
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

        [HttpPost]
        [Route(nameof(AddCountry))]
        public JsonResult AddCountry([FromBody] Country model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                result.Data = _parameterService.AddCountry(model);
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpPut]
        [Route(nameof(UpdateCountry))]
        public JsonResult UpdateCountry([FromBody] Country model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                result.Data = _parameterService.UpdateCountry(model);
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpPost]
        [Route(nameof(AddMultipleCountries))]
        public JsonResult AddMultipleCountries([FromBody] List<Country> model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                result.Data = _parameterService.AddMultipleCountries(model);
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
