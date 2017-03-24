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
        public ActionResult Edit(string title)
        {
            Guard.WhenArgument(title, "name").IsNullOrEmpty().Throw();

            var transformedTitle = title.Replace('_', ' ').Replace('-', ' ');
            var page = this.pageService.GetPageByTitle(transformedTitle);
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
                    return this.RedirectToAction("Page", "Home", new { title = model.Title });
                }
                else
                {
                    this.contentSubmissionService.SubmitEdit(model.Content, model.Title);
                    return this.RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Edits(string title)
        {
            var transformedTitle = title.Replace('_', ' ').Replace('-', ' ');
            var edits = this.contentSubmissionService.GetEdits(transformedTitle);
            var model = new EditsViewModel();
            model.Results = edits;

            return View(model);
        }

        [HttpGet]
        public ActionResult PublishEdit(string id)
        {
            var edit = this.contentSubmissionService.GetPageContentSubmissionById(Guid.Parse(id));
            var model = new EditViewModel()
            {
                Content = edit.Content,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PublishEdit(EditViewModel model)
        {
            return View(model);
        }
    }
}