using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using System.Linq;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPageService pageService;

        public SearchController(IPageService pageService)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();

            this.pageService = pageService;
        }

        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var results = this.pageService.FindPages(model.searchPhrase);
                model.Results = results.ToList();

                return View(model);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}