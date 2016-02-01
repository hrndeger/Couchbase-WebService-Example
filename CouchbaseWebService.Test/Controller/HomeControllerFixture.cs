using System.Web.Mvc;
using Couchbase.Views;
using CouchbaseWebService.Web.Controllers;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace CouchbaseWebService.Test.Controller
{
    [TestFixture]
    public class HomeControllerFixture
    {
        private HomeController m_HomeControllerMock;
       
        [Test]
        public void Index()
        {
            m_HomeControllerMock = Substitute.For<HomeController>();

            var result = m_HomeControllerMock.Index() as ActionResult;

            Assert.IsNull(result);
        }

    }
}