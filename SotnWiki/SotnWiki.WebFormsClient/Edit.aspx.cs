using SotnWiki.Mvp.Edit;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using SotnWiki.Mvp.CustomEventArgs;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(EditPresenter))]
    public partial class Edit : MvpPage<EditViewModel>, IEditView
    {
        public event EventHandler<PageEventArgs> OnPageGetContent;
        public event EventHandler<EditPageEventArgs> OnSubmitPageEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnPageGetContent?.Invoke(this, new PageEventArgs(Request.QueryString["title"]));
        }

        protected void submitPage_Click(object sender, EventArgs e)
        {
            this.OnSubmitPageEdit?.Invoke(this, new EditPageEventArgs(this.Model.Title, this.editPageText.Text, false));
        }
    }
}