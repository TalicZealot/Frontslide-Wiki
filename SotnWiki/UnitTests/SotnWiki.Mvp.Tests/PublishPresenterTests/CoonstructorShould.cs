using Moq;
using NUnit.Framework;
using SotnWiki.DataServices.Contracts;
using SotnWiki.Mvp.Publish;
using System;

namespace SotnWiki.Mvp.Tests.PublishPresenterTests
{
    [TestFixture]
    public class CoonstructorShould
    {
        [Test]
        public void ThrowArgumentNullExceptionWhenPageServicetIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "IPageService";
            var mockedView = new Mock<IPublishView>();
            //Act
            var exc = Assert.Throws<ArgumentNullException>(() => { new PublishPresenter(mockedView.Object, null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
    }
}
