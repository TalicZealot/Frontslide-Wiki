using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using System;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    [Authorize]
    public class SubmissionsController : Controller
    {
        private readonly IPageService pageService;
        private readonly IContentSubmissionService contentSubmissionService;

        public SubmissionsController(IPageService pageService, IContentSubmissionService contentSubmissionService)
        {
            Guard.WhenArgument(pageService, "pageService").IsNull().Throw();
            Guard.WhenArgument(contentSubmissionService, "contentSubmissionService").IsNull().Throw();

            this.pageService = pageService;
            this.contentSubmissionService = contentSubmissionService;
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
                return this.RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Submissions()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Publish()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Publish(NewPageViewModel model)
        {
            return View();
        }
    }
}