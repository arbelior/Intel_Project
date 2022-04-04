using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireAllWorld")]
    public class ContactsController : ControllerBase, IDisposable
    {
        private readonly DataLogic logic = new DataLogic();
        private readonly UserLogic Userlogic = new UserLogic();

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUser()
        {
            try
            {
                List<UserContactModel> UserModel = logic.GetAllUsers();
                return Ok(UserModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }



        [HttpGet("ShowIfUserType/{Username}")]
        public IActionResult GetUsertype(string Username)
        {
            try
            {
                UserContactModel UserModel = logic.Get_If_Usertype(Username);
                return Ok(UserModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }



        [HttpPost]
        [Route("/AddUser")]
        public IActionResult AddTask(UserContactModel User)
        {
            try
            {
                UserContactModel addUser = logic.AddUser(User);
                return Created("/AddUser/" + addUser.id, addUser);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }
        
        [HttpPut]  
        [Route("Update_If_UserType")]
        public IActionResult UpdateIfUserTypeNow(UserContactModel obj)
        {
            try
            {
                UserContactModel updateIfType = logic.Update_If_Type(obj);
                if (updateIfType == null)
                    return NotFound();

                return Ok(updateIfType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpPut]
        [Route("Update_If_UserNotType")]
        public IActionResult UpdateIfUserNot_TypeNow(UserContactModel obj)
        {
            try
            {
                UserContactModel updateIfNotType = logic.Update_If_Not_Type(obj);
                if (updateIfNotType == null)
                    return NotFound();

                return Ok(updateIfNotType);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }


        [HttpDelete]
        [Route("DeleteUser/{name}")]
        public IActionResult DeleteUser(string name)
        {
            try
            {
                DataLogic logic = new DataLogic();
                UserContactModel deleteUser = logic.GetoneUser(name);

                if (deleteUser != null)
                {
                    logic.TodeleteUser(name);
                    return NoContent();
                }
                
                return NotFound();

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
