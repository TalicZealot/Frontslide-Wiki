using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.Mvp.PendingEdits;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SotnWiki.WebFormsClient
{
    [PresenterBinding(typeof(PendingEditsPresenter))]
    public partial class PendingEdits : MvpPage<PendingEditsViewModel>, IPendingEditsView
    {
        public event EventHandler<Mvp.CustomEventArgs.PageEventArgs> OnGetPendingEdits;

        public IQueryable<SotnWiki.Models.PageContentSubmission> ResultsListView_GetData()
        {
            this.OnGetPendingEdits?.Invoke(this, new PageEventArgs(Request.QueryString["title"]));
            return this.Model.Results;
        }
    }
}