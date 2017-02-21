using SotnWiki.Mvp.Submissions;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(SubmissionsPresenter))]
    public partial class Submissions : MvpPage<SubmissionsViewModel>, ISubmissionsView
    {
        public event EventHandler OnGetSubmissions;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnGetSubmissions?.Invoke(this, null);
        }

        public IQueryable<SotnWiki.Models.Page> ResultsListView_GetData()
        {
           return this.Model.Results;
        }
    }
}