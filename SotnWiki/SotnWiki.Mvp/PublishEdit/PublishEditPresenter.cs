using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace SotnWiki.Mvp.PublishEdit
{
    public class PublishEditPresenter : Presenter<IPublishEditView>
    {
        private readonly IPageService pageService;
        private readonly IContentSubmissionService contentSubmissionService;

        public PublishEditPresenter(IPublishEditView view, IPageService pageService, IContentSubmissionService contentSubmissionService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(contentSubmissionService, nameof(IContentSubmissionService)).IsNull().Throw();

            this.pageService = pageService;
            this.contentSubmissionService = contentSubmissionService;
            this.View.OnPageGetContent += View_OnPageGetContent;
            this.View.OnSubmitPageEdit += View_OnSubmitPageEdit;
            this.View.OnDismissEdit += View_OnDismissEdit;
        }

        private void View_OnPageGetContent(object sender, IdEventArgs args)
        {
            var result = this.contentSubmissionService.GetPageContentSubmissionById(args.Id);
            this.View.Model.Title = args.Title;
            this.View.Model.Content = result.Content;
        }

        private void View_OnSubmitPageEdit(object sender, CustomEventArgs.PublishEditEventArgs args)
        {
            this.contentSubmissionService.PublishEdit(args.Title.Replace('-', ' '), args.Content, args.Id);
            string title = args.Title.ToLower().Replace(' ', '-');
            Response.Redirect(string.Format("~/page?title={0}", title));
        }

        private void View_OnDismissEdit(object sender, IdEventArgs args)
        {
            this.contentSubmissionService.DismissEdit(args.Id);
            string title = args.Title.Replace(' ', '-');
            Response.Redirect(string.Format("~/pendingedits?title={0}", title));
        }
    }
}
