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
        private readonly IPageService pageService;
        private readonly IRunService runService;

        public ApiController(IPageService pageService, IRunService runService)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(runService, nameof(IRunService)).IsNull().Throw();

            this.pageService = pageService;
            this.runService = runService;
        }

        public ActionResult Category(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var alucardAny = this.runService.GetRunsInCategory(name).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckTitleAvailability(string title)
        {
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var page = this.pageService.GetPageByTitle(title);
            bool available = page == null;

            return Json(available, JsonRequestBehavior.AllowGet);
        }
    }
}