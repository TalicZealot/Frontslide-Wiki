using SotnWiki.Mvp.CustomEventArgs;
using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.PendingEdits
{
    public interface IPendingEditsView : IView<PendingEditsViewModel>
    {
        event EventHandler<PageEventArgs> OnGetPendingEdits;
    }
}
