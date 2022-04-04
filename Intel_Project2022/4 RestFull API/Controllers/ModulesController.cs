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


    public class ModulesController : ControllerBase
    {
        [HttpGet]
        [Route("modules")]
        public IActionResult GetAllModules()
        {
            try
            {
                Object Module;

                using (DataLogic logic = new DataLogic())
                {
                    Module = logic.GetAllModules();
                }

                return Ok(Module);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        public IActionResult GetAllDataModules()
        {
            try
            {
                List<ModuleModel> Modules;

                using (DataLogic logic = new DataLogic())
                {
                    Modules = logic.GetAllModulesData();
                }

                return Ok(Modules);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("Tools/{module}")]
        public IActionResult GetDataToolPermod(string module)
        {
            try
            {
                Object Tools;

                using (DataLogic logic = new DataLogic())
                {
                    Tools = logic.GetToolDataPerModule(module);
                }

                if (Tools == null)
                {
                    return NotFound($"Modeule {module} is not Found");
                }

                return Ok(Tools);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }

        [HttpGet]
        [Route("tool/{tool}")]
        public IActionResult GetDataToolPertool(string tool)
        {
            try
            {

                List<ToolsPerTool> Toolist;

                using (DataLogic logic = new DataLogic())
                {
                    Toolist = logic.GetModuleDataPerTool(tool);
                }

                if (Toolist == null)
                {
                    return NotFound($"Modeule {tool} is not Found");
                }

                return Ok(Toolist);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelpers.GetExcepton(ex));
            }
        }
    }
}
