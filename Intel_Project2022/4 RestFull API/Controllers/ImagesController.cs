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
    public class ImagesController : ControllerBase, IDisposable
    {
        private readonly DataLogic logic = new DataLogic();
        private readonly UserLogic Userlogic = new UserLogic();


        [HttpGet("GetImage/{Module}")]
        public IActionResult GetAllComments(string Module)
        {
            try
            {

               List<ImageModel> img = logic.GetImage_detailes(Module);

                    if(img == null)
                    return NotFound();
                
                return Ok(img);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpPut("UpdateTorque/{id}")]

        public IActionResult UpdateTorqueIfNeeded(int id,string torque)
        {
            try
            {

                ImageModel img = logic.UpdateImageData(id, torque);
                     
                    if (img == null)
                    return NotFound();

                return Ok(img);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpPut("UpdateTorqueIfNeed")]

        public IActionResult UpdateTorqueIfNeed(Torque_ListModel torque)
        {
            try
            {

                ImageModel img = logic.UpdateTorqueImg(torque);

                if (img == null)
                    return NotFound();

                return Ok(img);
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
