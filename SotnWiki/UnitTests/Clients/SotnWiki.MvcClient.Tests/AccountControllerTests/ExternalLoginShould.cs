using NUnit.Framework;
using SotnWiki.MvcClient.Controllers;
using TestStack.FluentMVCTesting;
using Moq;
using System.Web.Mvc;

namespace SotnWiki.MvcClient.Tests.AccountControllerTests
{
    [TestFixture]
    public class ExternalLoginShould
    {
        private AccountController controllerUnderTest;

        [SetUp]
        public void Setup()
        {
            controllerUnderTest = new AccountController();
        }

        //[Test]
        //public void Render_default_view_for_get_to_index()
        //{
        //    controllerUnderTest.WithCallTo(c => c.ExternalLogin(It.IsAny<string>(), It.IsAny<string>()))
        //        .ValidateActionReturnType<HttpUnauthorizedResult>();
        //}
    }
}
