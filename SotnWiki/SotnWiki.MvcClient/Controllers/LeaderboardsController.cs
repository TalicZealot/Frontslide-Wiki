using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    public class LeaderboardsController : Controller
    {
        private readonly IRunService runService;

        public LeaderboardsController(IRunService runService)
        {
            Guard.WhenArgument(runService, nameof(IRunService)).IsNull().Throw();

            this.runService = runService;
        }

        public ActionResult CvSpeedrunsArchive()
        {
            return View();
        }

        public ActionResult Current()
        {
            return View();
        }
    }
}