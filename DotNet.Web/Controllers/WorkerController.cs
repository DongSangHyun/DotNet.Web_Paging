using DotNet.Web.Data;
using DotNet.Web.Models;
using DotNet.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Web.Controllers
{
    public class WorkerController : Controller
    {
        private IWorkerMaster _Workermaster;
        private IConfiguration _Configuration;

        public WorkerController(IWorkerMaster iworkermaster,
                                IConfiguration configuration)
        {
            _Workermaster = iworkermaster;
            _Configuration = configuration;
        }

        [HttpGet("/{controller}/Index")]
        public async Task<IActionResult> IndexAsync()
        {
            var WorkerInfo = new WorkerInfo
            {
                workermasters = await _Workermaster.GetWorkerMastersAsync()
            };
            return View(WorkerInfo);
        }
    }
}
