using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Twitter;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(SotnWiki.Auth.Startup))]
namespace SotnWiki.Auth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Default"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            {
                ConsumerKey = "FPW5V1xmVqigu1Vig9BgoB499",
                ConsumerSecret = "UMJIatA0j8rK99GCIU4FWF65l1Jp5xDMtFYHUlhVhgfiIaguHX",
                BackchannelCertificateValidator = new Microsoft.Owin.Security.CertificateSubjectKeyIdentifierValidator(new[]
    {
        "A5EF0B11CEC04103A34A659048B21CE0572D7D47",
        "0D445C165344C1827E1D20AB25F40163D8BE79A5",
        "7FD365A7C2DDECBBF03009F34339FA02AF333133",
        "39A55D933676616E73A761DFA16A7E59CDE66FAD",
        "‎add53f6680fe66e383cbac3e60922e3b4c412bed",
        "4eb6d578499b1ccf5f581ead56be3d9b6744a5e5",
        "5168FF90AF0207753CCCD9656462A212B859723B",
        "B13EC36903F8BF4701D498261A0802EF63642BC3" 
    })
            });
        }
    }
}
