using intelpro;
using IntelPro.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelPro
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireAllWorld")]

    public class AuthController : ControllerBase, IDisposable
    {

        private readonly UserLogic logic;
        private readonly IJwtHelper jwthelper;

        public AuthController( UserLogic logic, IJwtHelper jwthelper)
        {
            this.jwthelper = jwthelper;
            this.logic = logic;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserModel user)
        {
            if (logic.IsUserExisting(user.User_name))
                return BadRequest("UserName is all ready taken");

            logic.AddUser(user);

            //user.Jwt_token = jwtHelper.GetToken(user.User_name, user.Role);

            return Created("API/users/" + user.id, user);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Creditionals creditionals)
        {
            try
            {
                UserModel user = logic.GetUserbyCreditionals(creditionals);

                if (user == null)
                    return Unauthorized("Incorrect Username or Password");

                //var token = jwthelper.GetToken(user.User_name);
                //logic.UpdateTokenToUserIfLogin(user);

                user.Jwt_token = jwthelper.GetToken(user.User_name);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }
        [Authorize]
        [HttpPost]
        [Route("login/Role/{name}")]
        public IActionResult AdminLogin(string name, UserModel NewUser)
        {
            try
            {
                UserModel user = logic.UserIfloginToupdate_Token(name);

                if (user == null)
                    return Unauthorized("Incorrect Username or Password");
    
                else if(user != null && user.Role == "Admin")
                {
                    UserModel AddUser = logic.AddUser(NewUser);
                    return Created("/API/Auth" + AddUser.id, AddUser);
                }

                return BadRequest("You are not admin");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }


        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                List<UserModel> modelData = logic.GetAllData();
                return Ok(modelData);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("Refresh login/{Username}")]
        public IActionResult UpdateloginIfTokenExpire(string Username)
        {
            try
            {
                UserModel user = logic.UserIfloginToupdate_Token(Username);

                    if (user == null)
                    return Unauthorized();

                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }



        public void Dispose()
        {
            logic.Dispose();
        }
    }
}