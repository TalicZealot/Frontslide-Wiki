using SotnWiki.Mvp.Search;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using SotnWiki.Mvp.CustomEventArgs;
using System.Linq;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {
        public event EventHandler<SearchEventArgs> OnPageGetContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnPageGetContent?.Invoke(this, new SearchEventArgs(Request.QueryString["q"]));
        }

        public IQueryable<SotnWiki.Models.Page> ResultsListView_GetData()
        {
            return this.Model.Results;
        }
    }
}