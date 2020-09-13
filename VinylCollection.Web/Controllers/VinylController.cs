using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinylCollection.Data.Models.Vinyls;
using VinylCollection.Domain.Helper;
using VinylCollection.Service.Interfaces;
using VinylCollection.Web.Helper;

namespace VinylCollection.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinylController : ControllerBase
    {
        private readonly IVinylService _vinylService;

        public VinylController(IVinylService vinylService)
        {
            _vinylService = vinylService;
        }

        [HttpGet]
        [Route(nameof(GetVinyls))]
        public JsonResult GetVinyls([FromQuery] string search)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                result.Data = _vinylService.GetVinyls(new QueryParamsHelper(), search);
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpPost]
        [Route(nameof(SaveVinyl))]
        public JsonResult SaveVinyl([FromBody] Vinyl model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                if (model == null)
                    throw new Exception("There is an error ocurred trying to save a vinyl");

                result.Data = _vinylService.SaveVinyl(model);
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
