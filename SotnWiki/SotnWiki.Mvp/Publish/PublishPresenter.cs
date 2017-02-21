using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace SotnWiki.Mvp.Publish
{
    public class PublishPresenter : Presenter<IPublishView>
    {
        private readonly IPageService pageService;

        public PublishPresenter(IPublishView view, IPageService pageService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();

            this.pageService = pageService;
            this.View.OnPageGetContent += View_OnPageGetContent;
            this.View.OnPublishPage += View_OnPublishPage;
            this.View.OnDismissPage += View_OnDismissPage;
        }

        private void View_OnDismissPage(object sender, PageEventArgs args)
        {
            this.pageService.DismissSubmission(args.Title);
            Response.Redirect("~/submissions");
        }

        private void View_OnPageGetContent(object sender, PageEventArgs args)
        {
            var page = this.pageService.GetSubmissionByTitle(args.Title.Replace('-', ' '));
            if (page == null)
            {
                Response.StatusCode = 404;
                Response.Status = "404 not found";
                Response.End();
            }

            this.View.Model.Content = page.Content;
            this.View.Model.Title = page.Title;
        }

        private void View_OnPublishPage(object sender, PublishEventArgs args)
        {
            this.pageService.PublishPage(args.EditedContent, args.Title);
            string title = args.Title.ToLower().Replace(' ', '-');
            Response.Redirect(string.Format("~/page?title={0}", title));
        }
    }
}
