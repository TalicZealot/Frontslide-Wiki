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

        public ActionResult AlucardAnyNSC()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 0)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlucardAllBosses()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 1)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlucardACE()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 2)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AlucardLowPercentWolf()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 3)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RichterAny()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 4)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RichterAllBosses()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 5)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MariaAny()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 6)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MariaAllBosses()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 7)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MariaAnyEmu()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 8)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MariaAllBossesEmu()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 9)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvSpeedrunsAlucardAny()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 10)).OrderBy(x => x.Time)
                .Select(x => new {Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString()}).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvSpeedrunsAlucardAllBosses()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 11)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvSpeedrunsAlucardACE()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 12)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsAlucardLowPercentWolf()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 13)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsRichterAny()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 14)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsRichterAllBosses()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 15)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsMariaAny()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 16)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsMariaAllBosses()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 17)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsMariaAnyEmu()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 18)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CvsMariaAllBossesEmu()
        {
            var alucardAny = this.runService.GetRunsInCategory(Enum.GetName(typeof(Category), 19)).OrderBy(x => x.Time)
                .Select(x => new { Runner = x.Runner, Time = x.Time, Url = x.Url, Platform = x.Platform.ToString() }).ToList();

            return Json(alucardAny, JsonRequestBehavior.AllowGet);
        }
    }
}