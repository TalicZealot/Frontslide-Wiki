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
        private readonly IMarkupConverter markupConverter;

        public SubmissionsPresenter(ISubmissionsView view, IPageService pageService, IMarkupConverter markupConverter)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(markupConverter, nameof(IMarkupConverter)).IsNull().Throw();

            this.markupConverter = markupConverter;
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
