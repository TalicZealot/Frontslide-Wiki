using SotnWiki.Mvp.PublishEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SotnWiki.Mvp.CustomEventArgs;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(PublishEditPresenter))]
    public partial class PublishEdit : MvpPage<PublishEditViewModel>, IPublishEditView
    {
        public event EventHandler<IdEventArgs> OnPageGetContent;
        public event EventHandler<PublishEditEventArgs> OnSubmitPageEdit;
        public event EventHandler<IdEventArgs> OnDismissEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnPageGetContent?.Invoke(this, new IdEventArgs(new Guid(Request.QueryString["id"]), Request.QueryString["title"]));
        }

        protected void publishEdit_Click(object sender, EventArgs e)
        {
            this.OnSubmitPageEdit?.Invoke(this, new PublishEditEventArgs(this.Model.Title, editPageText.Text, new Guid(Request.QueryString["id"])));
        }

        protected void dismissEdit_Click(object sender, EventArgs e)
        {
            this.OnDismissEdit?.Invoke(this, new IdEventArgs(new Guid(Request.QueryString["id"]), Request.QueryString["title"]));
        }
    }
}