using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using SotnWiki.TextManipulation.Contracts;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageService pageService;
        private readonly IMarkupConverter markupConverter;

        public HomeController(IPageService pageService, IMarkupConverter markupConverter)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(markupConverter, nameof(IMarkupConverter)).IsNull().Throw();

            this.markupConverter = markupConverter;
            this.pageService = pageService;
        }

        public ActionResult Index()
        {
            var page = this.pageService.GetPageByTitle("Main Page");
            if (page == null)
            {
                return HttpNotFound();
            }

            var model = new PageViewModel();
            model.PageHtml = this.markupConverter.ScriptToHtml(page.Content);
            model.Title = page.Title;
            return View(model);
        }

        public ActionResult Page(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            ViewBag.Message = "Your application description page.";
            var page = this.pageService.GetPageByTitle(name);
            if (page == null)
            {
                return HttpNotFound();
            }

            var model = new PageViewModel();
            model.PageHtml = this.markupConverter.ScriptToHtml(page.Content);
            model.Title = page.Title;
            return View(model);
        }
    }
}