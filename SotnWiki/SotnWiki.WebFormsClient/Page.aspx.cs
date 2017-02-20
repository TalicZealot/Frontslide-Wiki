using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Page;
using System;
using System.Web.ModelBinding;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(PagePresenter))]
    public partial class Page : MvpPage<PageViewModel>, IPageView
    {
        public event EventHandler<PageEventArgs> OnPageGetContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnPageGetContent?.Invoke(this, new PageEventArgs(Request.QueryString["title"]));
        }
    }
}