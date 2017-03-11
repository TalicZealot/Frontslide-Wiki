using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.MvcClient.Models;
using SotnWiki.TextManipulation.Contracts;
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

        public ActionResult Search(string searchPhrase)
        {
            return View();
        }
    }
}