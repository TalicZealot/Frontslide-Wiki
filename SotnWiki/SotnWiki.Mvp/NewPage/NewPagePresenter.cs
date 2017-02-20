﻿using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.CustomEventArgs;
using WebFormsMvp;

namespace SotnWiki.Mvp.NewPage
{
    public class NewPagePresenter : Presenter<INewPageView>
    {
        private readonly IPageService pageService;

        public NewPagePresenter(INewPageView view, IPageService pageService)
            : base(view)
        {
            this.pageService = pageService;
            this.View.OnSubmitNewPage += View_OnSubmitNewPage;
        }

        private void View_OnSubmitNewPage(object sender, PageSubmitEventArgs args)
        {
            this.pageService.CreatePage(args.Character, args.Type, args.Title, args.Content, false);
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
