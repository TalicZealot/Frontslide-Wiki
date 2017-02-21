using SotnWiki.Mvp.CustomEventArgs;
using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.PublishEdit
{
    public interface IPublishEditView : IView<PublishEditViewModel>
    {
        event EventHandler<IdEventArgs> OnPageGetContent;
        event EventHandler<PublishEditEventArgs> OnSubmitPageEdit;
        event EventHandler<IdEventArgs> OnDismissEdit;
    }
}
