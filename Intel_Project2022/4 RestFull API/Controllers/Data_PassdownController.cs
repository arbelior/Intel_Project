using IntelPro;
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
    public class Data_PassdownController : ControllerBase, IDisposable
    {
        private readonly DataLogic logic     = new DataLogic();
        private readonly UserLogic Userlogic = new UserLogic();
        

        public Data_PassdownController(DataLogic logic, UserLogic userlogic)
        {
            this.logic     = logic;
            this.Userlogic = userlogic;
        }

        [HttpGet]
        [Route("/Aps")]
        public IActionResult GetAllTaskResume()
        {
            try
            {
                List<Return_To_taskList> DataResume = logic.GetAllTasks();
                return Ok(DataResume);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }


        [HttpPost]
        [Route("/Aps")]

        public IActionResult AddTaskToDataResume(Return_To_taskList NewResData)
        {
            try
            {
                Return_To_taskList AddData_Res = logic.AddTaskToResume(NewResData);
                return Created("/Aps/" + AddData_Res.id, AddData_Res);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet("GetAllData")]
        public IActionResult GetAllData()
        {
            try
            {
                 List<DataModel> modelData = logic.GetAllData();
                return Ok(modelData);
            }
            catch (Exception ex)
            {
              return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetoneTask(int id)
        {
            try
            {
                DataModel modelData = logic.GetoneData(id);
                if (modelData == null)
                {
                    return NotFound($"id {id} is not Found");
                }

                return Ok(modelData);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("Aps/{id}")]
        public IActionResult Getlonely_Task(int id)
        {
            try
            {
                Return_To_taskList TaskModel = logic.GetoneDataTask(id);
                if (TaskModel == null)
                {
                    return NotFound($"id {id} is not Found");
                }

                return Ok(TaskModel);

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddTask(DataModel Task)
        {
            try
            {
                DataModel addedTask = logic.AddTask(Task);
                return Created("API / " +
                    "Data_Passdown" + addedTask.id, addedTask);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));

            }
        }

        //[AllowAnonymous]
        [HttpDelete]
        [Route("DeleteTask/{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                DataLogic logic = new DataLogic();
                 DataModel deleteItem = logic.GetoneData(id);
                
                    if (deleteItem != null)
                    {
                        logic.To_delete(id);
                        return NoContent();
                    }          

              return NotFound();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpDelete]
        [Route("Task/{id}")]

        public IActionResult DeleteItemResume(int id)
        {
            try
            {
                Return_To_taskList deleted_Item = logic.GetoneDataTask(id);
                if (deleted_Item != null)
                {
                    logic.TodeleteItemResume(id);
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
