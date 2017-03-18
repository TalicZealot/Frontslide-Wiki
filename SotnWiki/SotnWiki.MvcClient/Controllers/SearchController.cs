using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using SotnWiki.TextManipulation.Contracts;
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
        public ActionResult Search(string searchPhrase)
        {
            var results = this.pageService.FindPages(searchPhrase);
            var model = new SearchViewModel();
            model.Results = results.ToList();
            model.searchPhrase = searchPhrase;

            return View(model);
        }
    }
}