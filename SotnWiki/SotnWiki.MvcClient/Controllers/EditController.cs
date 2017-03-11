using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using SotnWiki.TextManipulation.Contracts;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    public class EditController : Controller
    {
        private readonly IPageService pageService;

        public EditController(IPageService pageService)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();

            this.pageService = pageService;
        }

        [HttpGet]
        public ActionResult Edit(string asd)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string aasd, string asfd)
        {
            return View();
        }

        public ActionResult Edits()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPage(string aasd)
        {
            return View();
        }
    }
}