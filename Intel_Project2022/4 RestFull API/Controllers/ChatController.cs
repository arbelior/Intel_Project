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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireAllWorld")]

    public class ChatController : ControllerBase, IDisposable
    {
        private readonly DataLogic logic = new DataLogic();
        private readonly UserLogic Userlogic = new UserLogic();

        [AllowAnonymous]
        [HttpGet]
        [Route("/Message _box")]
        public IActionResult GetAllMessages()
        {
            try
            {
              List  <MessageModel> MessageData = logic.GetAllMessages();
                return Ok(MessageData);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpPost]
        public IActionResult AddTaskToDataResume(MessageModel NewResData)
        {
            try
            {
                MessageModel AddMessage = logic.AddNewMessage(NewResData);
                return Created("API / " + "Chat" + AddMessage.Id, AddMessage);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }


        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                DataLogic logic = new DataLogic();
                MessageModel deleteUser = logic.GetOneMessage(id);

                if (deleteUser != null)
                {
                    logic.deleteMessage(id);
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
