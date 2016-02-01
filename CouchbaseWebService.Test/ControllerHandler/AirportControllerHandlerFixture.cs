using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.ControllerHandler;
using CouchbaseWebService.Web.Manager.Interface;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CouchbaseWebService.Test.ControllerHandler
{
    [TestFixture]
    public sealed class AirportControllerHandlerFixture
    {
        private IAirportManager m_AirportManagerMock;

        [Test]
        public void GetAirportInformationByAirportCodeWhenParamIsValid()
        {
            Init();

            string airportCode = "AMS";

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "Amsterdam",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            m_AirportManagerMock.GetAirportInformationByAirportCode(airportCode).Returns(airportDto);

            AirportControllerHandler airportControllerHandler = new AirportControllerHandler(m_AirportManagerMock);
            airportControllerHandler.GetAirportInformationByAirportCode(airportCode).ShouldBeEquivalentTo(airportDto);

        }

        [Test]
        public void GetAirportInformationByAirportCodeWhenParamIsNullOrEmpty()
        {
            string airportCode = string.Empty;

            AirportControllerHandler airportControllerHandler = new AirportControllerHandler(m_AirportManagerMock);

            AirportDto actual = airportControllerHandler.GetAirportInformationByAirportCode(airportCode);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void GetAirportInformationFromCouchbaseByAirportCodeWhenParamIsValid()
        {
            Init();

            string airportCode = "AMS";

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "Amsterdam",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            m_AirportManagerMock.GetAirportInformationFromCouchbaseByAirportCode(airportCode).Returns(airportDto);

            AirportControllerHandler airportControllerHandler = new AirportControllerHandler(m_AirportManagerMock);
            airportControllerHandler.GetAirportInformationFromCouchbaseByAirportCode(airportCode).ShouldBeEquivalentTo(airportDto);
        }

        [Test]
        public void GetAirportInformationFromCouchbaseByAirportCodeWhenParamIsNullOrEmpty()
        {
            string airportCode = string.Empty;

            AirportControllerHandler airportControllerHandler = new AirportControllerHandler(m_AirportManagerMock);

            AirportDto actual = airportControllerHandler.GetAirportInformationFromCouchbaseByAirportCode(airportCode);
            Assert.AreEqual(null, actual);
        }

        [Test]
        public void AddAirportInformationToCouchbaseWhenParamIsValid()
        {
            Init();

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "Amsterdam",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            bool actual = m_AirportManagerMock.AddAirportInformationToCouchbase(airportDto);

            AirportControllerHandler airportControllerHandler = new AirportControllerHandler(m_AirportManagerMock);
            bool excepted = airportControllerHandler.AddAirportInformationToCouchbase(airportDto);

            Assert.AreEqual(excepted,actual);
        }

        [Test]
        public void AddAirportInformationToCouchbaseWhenParamIsNull()
        {
            AirportDto airportDto = default (AirportDto);

            AirportControllerHandler airportControllerHandler = new AirportControllerHandler(m_AirportManagerMock);

            bool actual = airportControllerHandler.AddAirportInformationToCouchbase(airportDto);
            Assert.AreEqual(false, actual);
        }

        private void Init()
        {
            m_AirportManagerMock = Substitute.For<IAirportManager>();
        }

    }
}