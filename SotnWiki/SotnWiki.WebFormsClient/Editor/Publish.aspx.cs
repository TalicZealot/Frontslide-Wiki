using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.Publish;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(PublishPresenter))]
    public partial class Publish : MvpPage<PublishViewModel>, IPublishView
    {
        public event EventHandler<Mvp.CustomEventArgs.PageEventArgs> OnPageGetContent;
        public event EventHandler<PublishEventArgs> OnPublishPage;
        public event EventHandler<PageEventArgs> OnDismissPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnPageGetContent?.Invoke(this, new PageEventArgs(Request.QueryString["title"]));
        }

        protected void publishPage_Click(object sender, EventArgs e)
        {
            this.OnPublishPage?.Invoke(this, new PublishEventArgs(this.Model.Title, this.Model.Content));
        }

        protected void dismissPage_Click(object sender, EventArgs e)
        {
            this.OnDismissPage?.Invoke(this, new PageEventArgs(Request.QueryString["title"]));
        }
    }
}