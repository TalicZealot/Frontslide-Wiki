using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.TextManipulation.Contracts;
using System.Linq;
using WebFormsMvp;

namespace SotnWiki.Mvp.Submissions
{
    public class SubmissionsPresenter : Presenter<ISubmissionsView>
    {
        private readonly IPageService pageService;

        public SubmissionsPresenter(ISubmissionsView view, IPageService pageService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            this.pageService = pageService;
            this.View.OnGetSubmissions += View_OnGetSubmissions;
        }

        private void View_OnGetSubmissions(object sender, System.EventArgs e)
        {
            var result = this.pageService.GetSubmissions();
            this.View.Model.Results = result.AsQueryable();
        }
    }
}
