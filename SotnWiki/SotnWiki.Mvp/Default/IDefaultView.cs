using System;
using WebFormsMvp;

namespace SotnWiki.Mvp.Default
{
    public interface IDefaultView : IView<DefaultViewModel>
    {
        event EventHandler OnGetHomePage;
    }
}
