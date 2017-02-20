using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.NewPage;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(NewPagePresenter))]
    public partial class NewPage : MvpPage<NewPageViewModel>, INewPageView
    {
        public event EventHandler<PageSubmitEventArgs> OnSubmitNewPage;

        protected void submitPage_Click(object sender, EventArgs e)
        {
            this.OnSubmitNewPage?.Invoke(this, new PageSubmitEventArgs(this.DropDownCharacter.SelectedValue, this.DropDownType.SelectedValue, this.TextBoxPageTitle.Text, this.editPageText.Text, false));
        }

        protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}