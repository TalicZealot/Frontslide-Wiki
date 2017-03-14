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

        public ActionResult Category(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var alucardAny = this.runService.GetRunsInCategory(name).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }
    }
}