using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Search;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {
        public event EventHandler<SearchEventArgs> OnPageGetContent;

        public IQueryable<SotnWiki.Models.Page> ResultsListView_GetData()
        {
            this.OnPageGetContent?.Invoke(this, new SearchEventArgs(Request.QueryString["q"]));
            return this.Model.Results;
        }
    }
}