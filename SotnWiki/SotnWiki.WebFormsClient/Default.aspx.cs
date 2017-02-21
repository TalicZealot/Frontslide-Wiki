using SotnWiki.Mvp.Default;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(DefaultPresenter))]
    public partial class _Default : MvpPage<DefaultViewModel>, IDefaultView
    {
        public event EventHandler OnGetHomePage;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnGetHomePage?.Invoke(this, null);
        }
    }
}