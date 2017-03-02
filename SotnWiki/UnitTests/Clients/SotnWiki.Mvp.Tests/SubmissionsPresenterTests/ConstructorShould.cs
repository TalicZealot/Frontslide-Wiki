using Moq;
using NUnit.Framework;
using SotnWiki.Mvp.Submissions;
using System;

namespace SotnWiki.Mvp.Tests.SubmissionsPresenterTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<ISubmissionsView>();

            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new SubmissionsPresenter(mockedView.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
