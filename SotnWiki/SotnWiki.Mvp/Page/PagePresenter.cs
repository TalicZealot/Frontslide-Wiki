using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using SotnWiki.TextManipulation.Contracts;
using WebFormsMvp;

namespace SotnWiki.Mvp.Page
{
    public class PagePresenter : Presenter<IPageView>
    {
        private readonly IPageService pageService;
        private readonly IMarkupConverter markupConverter;

        public PagePresenter(IPageView view, IPageService pageService, IMarkupConverter markupConverter)
            : base(view)
        {
            this.markupConverter = markupConverter;
            this.pageService = pageService;
            this.View.OnPageGetContent += this.View_OnPageGetContent;
        }

        private void View_OnPageGetContent(object sender, PageEventArgs args)
        {
            var page = this.pageService.GetPageByTitle(args.Title.Replace('-', ' '));
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
