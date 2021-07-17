using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinylCollection.Data.Models.Security;
using VinylCollection.Domain.Helper;
using VinylCollection.Domain.Transversal;
using VinylCollection.Service.Interfaces;
using VinylCollection.Web.Helper;

namespace VinylCollection.Web.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private IAppPrincipal _appPrincipal { get; }

        public UsersController(IUserService userService, IAppPrincipal appPrincipal)
        {
            _userService = userService;
            _appPrincipal = appPrincipal;
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
                        id = EncodingHelper.EncodeBase64(user.Id.ToString()),
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

        [HttpPost]
        [Route(nameof(ChangeUserAvatar))]
        [TypeFilter(typeof(SecurityFilter), Arguments = new[] { "Jwt" })]
        public JsonResult ChangeUserAvatar(IFormCollection formCollection)
        {
            JSONObjectResult result = new JSONObjectResult
            {
                Status = System.Net.HttpStatusCode.OK
            };

            try
            {
                if (formCollection.Files == null)
                    throw new Exception("An avatar has not been imported");

                string userId = formCollection["userId"].ToString();
                int id = Convert.ToInt32(EncodingHelper.DecodeBase64(userId));

                var user = _appPrincipal.UserName;

                if (id != _appPrincipal.Id)
                    throw new Exception("An error occurred trying to change the avatar");


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
