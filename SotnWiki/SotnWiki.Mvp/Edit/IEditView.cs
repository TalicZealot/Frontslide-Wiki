using SotnWiki.Mvp.CustomEventArgs;
using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.Edit
{
    public interface IEditView : IView<EditViewModel>
    {
        event EventHandler<PageEventArgs> OnPageGetContent;
        event EventHandler<EditPageEventArgs> OnSubmitPageEdit;
    }
}
