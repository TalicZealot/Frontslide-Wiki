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
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var transformedName = name.Replace('_', ' ').Replace('-', ' ');
            var page = this.pageService.GetPageByTitle(transformedName);
            if (page == null)
            {
                return HttpNotFound();
            }

            var model = new EditViewModel();
            model.Content = page.Content;
            model.Title = page.Title;
            return View(model);
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

            return View(model);
        }

        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Edits()
        {
            return View();
        }
    }
}