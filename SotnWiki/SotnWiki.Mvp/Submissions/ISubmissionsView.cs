using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.Submissions
{
    public interface ISubmissionsView : IView<SubmissionsViewModel>
    {
        event EventHandler OnGetSubmissions;
    }
}
