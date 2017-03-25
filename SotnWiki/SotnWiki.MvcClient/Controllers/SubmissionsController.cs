using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using System;
using System.Linq;
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
                if (model.Publish && (this.HttpContext.User.IsInRole("Admin") || this.HttpContext.User.IsInRole("Editor")))
                {
                    this.pageService.CreatePage((int)Enum.Parse(typeof(SotnWiki.Models.CharacterIdEnum), model.Character),
                    model.Type, model.Title, model.Content, model.Publish);
                    return this.RedirectToAction("Page", "Home", new { title = model.Title.Replace(' ', '_') });
                }

                this.pageService.CreatePage((int)Enum.Parse(typeof(SotnWiki.Models.CharacterIdEnum), model.Character),
                    model.Type, model.Title, model.Content, false);
                return this.RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Submissions()
        {
            var submissions = this.pageService.GetSubmissions();
            var model = new SubmissionsViewModel();
            model.Results = submissions.ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Publish(string title)
        {
            var transformedTitle = title.Replace('_', ' ').Replace('-', ' ');
            var submission = this.pageService.GetSubmissionByTitle(transformedTitle);
            if (submission == null)
            {
                return HttpNotFound();
            }

            var model = new EditViewModel()
            {
                Content = submission.Content,
                Title = submission.Title
            };
            ModelState.Clear();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Editor, Admin")]
        public ActionResult Publish(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.pageService.PublishPage(model.Content, model.Title);
                return this.RedirectToAction("Page", "Home", new { title = model.Title.Replace(' ', '_') });
            }

            return View(model);
        }
    }
}