using SotnWiki.Mvp.CustomEventArgs;
using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.Publish
{
    public interface IPublishView : IView<PublishViewModel>
    {
        event EventHandler<PageEventArgs> OnPageGetContent;
        event EventHandler<PublishEventArgs> OnPublishPage;
        event EventHandler<PageEventArgs> OnDismissPage;
    }
}
