using WebFormsMvp;

namespace SotnWiki.Mvp.Account.RegisterExternalLogin
{
    public class RegisterExternalLoginPresenter : Presenter<IRegisterExternalLoginView>
    {
        public RegisterExternalLoginPresenter(IRegisterExternalLoginView view)
            : base(view)
        {

        }
    }
}
