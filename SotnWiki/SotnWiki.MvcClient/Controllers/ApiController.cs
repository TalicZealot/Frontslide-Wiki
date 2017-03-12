using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    public class ApiController : Controller
    {
        private readonly IRunService runService;

        public ApiController(IRunService runService)
        {
            Guard.WhenArgument(runService, nameof(IRunService)).IsNull().Throw();

            this.runService = runService;
        }

        public ActionResult CvSpeedrunsAlucardAny()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 10)).OrderBy(x => x.Time).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }
    }
}