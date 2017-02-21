using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using WebFormsMvp;

namespace SotnWiki.Mvp.Edit
{
    public class EditPresenter : Presenter<IEditView>
    {
        private readonly IPageService pageService;
        private readonly IContentSubmissionService contentSubmissionService;

        public EditPresenter(IEditView view, IPageService pageService, IContentSubmissionService contentSubmissionService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();
            Guard.WhenArgument(contentSubmissionService, nameof(IContentSubmissionService)).IsNull().Throw();

            this.pageService = pageService;
            this.contentSubmissionService = contentSubmissionService;
            this.View.OnPageGetContent += View_OnPageGetContent;
            this.View.OnSubmitPageEdit += View_OnSubmitPageEdit;
        }

        private void View_OnSubmitPageEdit(object sender, CustomEventArgs.EditPageEventArgs args)
        {
            this.contentSubmissionService.SubmitEdit(args.Content, args.Title);
            string title = args.Title.ToLower().Replace(' ', '-');
            Response.Redirect(string.Format("~/page?title={0}", title));
        }

        private void View_OnPageGetContent(object sender, CustomEventArgs.PageEventArgs args)
        {
            var page = this.pageService.GetPageByTitle(args.Title.Replace('-', ' '));
            if (page == null)
            {
                Response.StatusCode = 404;
                Response.Status = "404 not found";
                Response.End();
            }

            this.View.Model.Content = page.Content;
            this.View.Model.Title = page.Title;
        }
    }
}
