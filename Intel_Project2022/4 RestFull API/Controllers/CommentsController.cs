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


    public class CommentsController : ControllerBase, IDisposable
    {
        private readonly DataLogic  logic     = new DataLogic();
        private readonly FilesLogic FileLogic = new FilesLogic();

        [HttpPost]
        [Route("DetailesComment")]
        public IActionResult AddComment(CommentModel comment)
        {
            try
            {
                CommentModel AddComment = logic.AddNew_Comment(comment);
                FileLogic.GetFile(AddComment);
                FileLogic.SendMail(AddComment);
                return Created("/DetailesComment/" + AddComment.Id, AddComment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));

            }

        }

        [HttpGet]
        public IActionResult GetAllComments()
        {
            try
            {
                List<CommentModel> AllComments;

                using(DataLogic logic = new DataLogic())
                {
                    AllComments = logic.ShowAllComments();
                }

                return Ok(AllComments);
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
