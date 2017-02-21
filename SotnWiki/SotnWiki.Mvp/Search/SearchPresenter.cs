using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Page;
using System.Linq;
using WebFormsMvp;

namespace SotnWiki.Mvp.Search
{
    public class SearchPresenter : Presenter<ISearchView>
    {
        private readonly IPageService pageService;

        public SearchPresenter(ISearchView view, IPageService pageService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();

            this.pageService = pageService;
            this.View.OnPageGetContent += View_OnPageGetContent;
        }

        private void View_OnPageGetContent(object sender, SearchEventArgs args)
        {
            var result = this.pageService.FindPages(args.SearchPhrase);
            if (result.Count() == 1)
            {
                string title = result.FirstOrDefault().Title.ToLower().Replace(' ', '-');
                Response.Redirect(string.Format("~/page?title={0}", title));
            }
            this.View.Model.Results = result.AsQueryable();
        }
    }
}
