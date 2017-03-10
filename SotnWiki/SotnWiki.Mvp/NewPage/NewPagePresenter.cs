using Bytes2you.Validation;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using WebFormsMvp;
using System;
using SotnWiki.Models;

namespace SotnWiki.Mvp.NewPage
{
    public class NewPagePresenter : Presenter<INewPageView>
    {
        private readonly IPageService pageService;

        public NewPagePresenter(INewPageView view, IPageService pageService)
            : base(view)
        {
            Guard.WhenArgument(pageService, nameof(IPageService)).IsNull().Throw();

            this.pageService = pageService;
            this.View.OnSubmitNewPage += View_OnSubmitNewPage;
        }

        private void View_OnSubmitNewPage(object sender, PageSubmitEventArgs args)
        {
            this.pageService.CreatePage((int)Enum.Parse(typeof(CharacterIdEnum), args.Character), args.Type, args.Title, args.Content, false);
            if (args.Publish)
            {
                string title = args.Title.ToLower().Replace(' ', '-');
                Response.Redirect(string.Format("~/page?title={0}", title));
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}
