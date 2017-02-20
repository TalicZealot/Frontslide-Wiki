using WebFormsMvp;

namespace SotnWiki.Mvp.Default
{
    public class DefaultPresenter : Presenter<IDefaultView>
    {
        public DefaultPresenter(IDefaultView view)
            : base(view)
        {

        }
    }
}
