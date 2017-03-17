using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using System;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    [Authorize]
    public class EditController : Controller
    {
        private readonly IPageService pageService;
        private readonly IContentSubmissionService contentSubmissionService;

        public EditController(IPageService pageService, IContentSubmissionService contentSubmissionService)
        {
            Guard.WhenArgument(pageService, "pageService").IsNull().Throw();
            Guard.WhenArgument(contentSubmissionService, "contentSubmissionService").IsNull().Throw();

            this.pageService = pageService;
            this.contentSubmissionService = contentSubmissionService;
        }

        [HttpGet]
        public ActionResult Edit(string name)
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Publish && (this.HttpContext.User.IsInRole("admin") || this.HttpContext.User.IsInRole("editor")))
                {
                    this.contentSubmissionService.SubmitAndPublishEdit(model.Content, model.Title);
                }
                else
                {
                    this.contentSubmissionService.SubmitEdit(model.Content, model.Title);
                }

                return this.RedirectToAction("Page", "Home", new { name = model.Title });
            }

            return new HttpStatusCodeResult(500);
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
        [ValidateAntiForgeryToken]
        public ActionResult NewPage(NewPageViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.pageService.CreatePage((int)Enum.Parse(typeof(SotnWiki.Models.CharacterIdEnum), model.Character),
                    model.Type, model.Title, model.Content, false);
                if (model.Publish && (this.HttpContext.User.IsInRole("admin") || this.HttpContext.User.IsInRole("editor")))
                {
                    return this.RedirectToAction("Page", "Home", new { name = model.Title });
                }
                return this.RedirectToAction("Page", "Home", "Index");
            }

            return new HttpStatusCodeResult(500);
        }
    }
}