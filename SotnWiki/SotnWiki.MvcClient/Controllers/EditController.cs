using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using System;
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
        public ActionResult Edit(string name)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(NewPageModel model)
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
        public ActionResult NewPage(NewPageModel model)
        {
            if (ModelState.IsValid)
            {
                this.pageService.CreatePage((int)Enum.Parse(typeof(SotnWiki.Models.CharacterIdEnum), model.Character),
                    model.Type, model.Title, model.Content, false);
                return this.RedirectToAction("Page", "Home", new { name = model.Title });
            }

            return new HttpStatusCodeResult(500);
        }
    }
}