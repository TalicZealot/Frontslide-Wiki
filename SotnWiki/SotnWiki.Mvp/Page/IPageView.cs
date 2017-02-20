using SotnWiki.Mvp.CustomEventArgs;
using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.Page
{
    public interface IPageView : IView<PageViewModel>
    {
        event EventHandler<PageEventArgs> OnPageGetContent;
    }
}
