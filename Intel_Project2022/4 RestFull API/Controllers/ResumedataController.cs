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
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("EntireAllWorld")]

    public class ResumedataController : ControllerBase, IDisposable
    {
        private readonly DataLogic logic = new DataLogic();

        public ResumedataController(DataLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult GetAllDataResume()
        {
            try
            {
                List<Return_To_taskList> TaskList = logic.GetAllTasks();
                return Ok(TaskList);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));

            }
        }

        [HttpPost]
        [Route("AddTask")]
        public IActionResult AddTask(Return_To_taskList Task)
        {
            try
            {
                Return_To_taskList addedTask = logic.AddTaskToResume(Task);
                return Created("API /  Resumedata" + addedTask.id, addedTask);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));

            }
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetoneTaskToResume(int id)
        {
            try
            {
                Return_To_taskList GetOneSpecifictTask = logic.GetoneDataTask(id);
                if (GetOneSpecifictTask == null)
                {
                    return NotFound($"id {id} is not Found");
                }

                return Ok(GetOneSpecifictTask);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }



        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteItem(int id)
        {
            try
            {
                Return_To_taskList deleteItem = logic.GetoneDataTask(id);
                if (deleteItem != null)
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
