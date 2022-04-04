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

    public class TorqueController : ControllerBase, IDisposable
    {
        private readonly DataLogic logic = new DataLogic();
        private readonly UserLogic Userlogic = new UserLogic();   
        
        [HttpGet("GetAllTorques")]
        public IActionResult GetAllTorqueList()
        {
            try
            {
                List<Torque_ListModel> TorqueModel = logic.GetAllTorqueList();
                return Ok(TorqueModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("GetAllPerModule/{module}")]
        public IActionResult GetTorqueList_PerModule(string module)
        {
            try
            {
                List<Torque_ListModel> TorqueModel = logic.GetTorqueListPerModule(module);
                return Ok(TorqueModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpPut]
        [Route("UpdateTorque")]
        public IActionResult GetTone_Object(Torque_ListModel obj)
        {
            try
            {
                //Torque_ListModel TorqueModel = logic.Get_One_Object_Torque_Model(id);
                //if (TorqueModel == null)
                //    return NotFound();

                Torque_ListModel updateNewTorqueVal = logic.Update_NewTorque_To_DB(obj);
                if (updateNewTorqueVal == null)
                    return NotFound();

                return Ok(updateNewTorqueVal);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("GetShift")]
        public IActionResult GetShift()
        {
            try
            {
                string shift = logic.GetShift(DateTime.Now);
                return Ok(shift);
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
