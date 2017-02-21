using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.TextManipulation.Contracts;
using WebFormsMvp;

namespace SotnWiki.Mvp.Default
{
    public class DefaultPresenter : Presenter<IDefaultView>
    {
        private readonly IPageService pageService;
        private readonly IMarkupConverter markupConverter;

        public DefaultPresenter(IDefaultView view, IPageService pageService, IMarkupConverter markupConverter)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(markupConverter, nameof(IMarkupConverter)).IsNull().Throw();

            this.markupConverter = markupConverter;
            this.pageService = pageService;
            this.View.OnGetHomePage += View_OnGetHomePage;
        }

        private void View_OnGetHomePage(object sender, System.EventArgs e)
        {
            var page = this.pageService.GetPageByTitle("Main Page");
            if (page == null)
            {
                Response.StatusCode = 404;
                Response.Status = "404 not found";
                Response.End();
            }

            this.View.Model.PageHtml = this.markupConverter.ScriptToHtml(page.Content);
            this.View.Model.Title = page.Title;
        }
    }
}
