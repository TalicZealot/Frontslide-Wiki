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
            ModelState.Clear();

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Publish && (this.HttpContext.User.IsInRole("Admin") || this.HttpContext.User.IsInRole("Editor")))
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
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult PublishEdit(string id)
        {
            Guid parsedId;
            var parseResult = Guid.TryParse(id, out parsedId);
            if (parseResult == false)
            {
                return HttpNotFound();
            }

            var edit = this.contentSubmissionService.GetPageContentSubmissionById(parsedId);
            if (edit == null)
            {
                return HttpNotFound();
            }

            var model = new EditViewModel()
            {
                Title = (string)RouteData.Values["title"],
                Id = edit.Id,
                Content = edit.Content,
                PageId = edit.PageId
            };
            ModelState.Clear();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult PublishEdit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.contentSubmissionService.PublishEdit(model.PageId, model.Content, model.Id);
                return this.RedirectToAction("Page", "Home", new { title = (string)RouteData.Values["title"] });
            }

            return View(model);
        }
    }
}