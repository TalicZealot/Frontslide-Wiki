using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SotnWiki.Auth;
using SotnWiki.Auth.Contracts;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ISignInService signInService;
        private readonly IUserService userService;
        private readonly IAuthenticationManager authenticationManager;

        public AccountController(ISignInService signInService, IUserService userService, IAuthenticationManager authenticationManager)
        {
            Guard.WhenArgument(signInService, "signInService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(authenticationManager, "authenticationManager").IsNull().Throw();

            this.authenticationManager = authenticationManager;
            this.signInService = signInService;
            this.userService = userService;
        }

        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            //gee thanks for this stupid static method Microsoft DansGame
            var loginInfo = await this.authenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await this.signInService.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    //create new account
                    var info = await this.authenticationManager.GetExternalLoginInfoAsync();
                    if (info == null)
                    {
                        return View("ExternalLoginFailure");
                    }
                    var user = new ApplicationUser { UserName = info.DefaultUserName, Email = info.DefaultUserName };
                    var createUserResult = await this.userService.CreateAsync(user);
                    if (createUserResult.Succeeded)
                    {
                        createUserResult = await this.userService.AddLoginAsync(user.Id, info.Login);
                        if (createUserResult.Succeeded)
                        {
                            await this.signInService.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                            return RedirectToLocal(returnUrl);
                        }
                    }
                    AddErrors(createUserResult);
                    return View("ExternalLoginFailure");
            }
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ExcludeFromCodeCoverage]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.userService != null)
                {
                    this.userService.Dispose();
                }

                if (this.signInService != null)
                {
                    this.signInService.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        [ExcludeFromCodeCoverage]
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [ExcludeFromCodeCoverage]
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [ExcludeFromCodeCoverage]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}