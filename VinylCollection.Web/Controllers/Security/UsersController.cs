using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinylCollection.Data.Models.Security;
using VinylCollection.Service.Interfaces;
using VinylCollection.Web.Helper;

namespace VinylCollection.Web.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route(nameof(RegisterAccount))]
        public JsonResult RegisterAccount([FromBody] User model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                if (model == null)
                    throw new Exception("There is an error ocurred trying to register an account");

                result.Data = _userService.RegisterAccount(model) > 0;
            }
            catch (Exception e)
            {
                result.Status = System.Net.HttpStatusCode.BadRequest;
                result.Errors.Add(e.Message);
            }

            return new JsonResult(result);
        }

        [HttpPost]
        [Route(nameof(LoginUser))]
        public JsonResult LoginUser([FromBody] User model)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                if (model == null)
                    throw new ArgumentNullException("It has not been possible to login into the club");

                User user = _userService.LoginUser(model);

                if (user == null)
                    throw new Exception("User credentials are incorrect, please correct them and try again");

                string token = _userService.GenerateJwt(user);

                result.Data = new
                {
                    UserInfo = new {
                        user.Name,
                        user.UserName
                    },
                    Token = token
                };
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
