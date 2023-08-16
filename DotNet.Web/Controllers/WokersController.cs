using DotNet.Web.Data;
using DotNet.Web.Models;
using DotNet.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Web.Controllers
{
    // ControllerBase : 

    [Route("api/[controller]")]
    [ApiController]
    public class WokersController : ControllerBase
    {
        private readonly IWorkerMaster _iworkermaster;

        public WokersController(IWorkerMaster iworkermaster)
        {
            _iworkermaster = iworkermaster;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(WorkerAjaxinfo))]
        public async Task<IActionResult> GetAsync()
        {
            List<WorkerMaster> workers = await _iworkermaster.GetWorkerMastersAsync();
            return Ok();
        }
    }
}
