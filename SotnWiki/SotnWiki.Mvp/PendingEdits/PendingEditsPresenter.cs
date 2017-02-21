using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using System.Linq;
using WebFormsMvp;

namespace SotnWiki.Mvp.PendingEdits
{
    public class PendingEditsPresenter : Presenter<IPendingEditsView>
    {
        private readonly IPageService pageService;
        private readonly IContentSubmissionService contentSubmissionService;

        public PendingEditsPresenter(IPendingEditsView view, IPageService pageService, IContentSubmissionService contentSubmissionService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(contentSubmissionService, nameof(IContentSubmissionService)).IsNull().Throw();

            this.contentSubmissionService = contentSubmissionService;
            this.pageService = pageService;
            this.View.OnGetPendingEdits += View_OnGetPendingEdits;
        }

        private void View_OnGetPendingEdits(object sender, CustomEventArgs.PageEventArgs args)
        {
            this.View.Model.Results = this.contentSubmissionService.GetSubmissions(args.Title.Replace('-', ' ')).AsQueryable();
        }
    }
}
