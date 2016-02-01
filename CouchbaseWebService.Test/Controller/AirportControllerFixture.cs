using System.Web.Mvc;
using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.ControllerHandler.Interface;
using CouchbaseWebService.Web.Controllers;
using CouchbaseWebService.Web.Models;
using NSubstitute;
using NUnit.Framework;

namespace CouchbaseWebService.Test.Controller
{
    [TestFixture]
    public sealed class AirportControllerFixture
    {
        private IAirportControllerHandler m_AirportControllerHandlerMock;

        [Test]
        public void Search()
        {
            Init();

            AirportController airportController = new AirportController(m_AirportControllerHandlerMock);

            var result = airportController.Search() as ActionResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void SearchWhenGetFromCouchbase()
        {
            Init();

            string code = "AMS";

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "Amsterdam",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            m_AirportControllerHandlerMock.GetAirportInformationFromCouchbaseByAirportCode(code).Returns(airportDto);

            AirportViewModel airportViewModel = new AirportViewModel
            {
                AirportCode = airportDto.AirportCode,
                CityOrAirportName = airportDto.CityOrAirportName,
                Country = airportDto.Country,
                CountryCode = airportDto.CountryCode,
                LatitudeDegree = airportDto.LatitudeDegree,
                LongitudeDegree = airportDto.LongitudeDegree
            };

            AirportController airportController = new AirportController(m_AirportControllerHandlerMock);

            var result = airportController.Search(code) as ActionResult;

            Assert.IsNotNull(airportViewModel);
            Assert.IsNotNull(result);
        }

        [Test]
        public void SearchWhenGetFromService()
        {
            Init();
            string code = "AMS";

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "Amsterdam",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            m_AirportControllerHandlerMock.GetAirportInformationByAirportCode(code).Returns(airportDto);
            m_AirportControllerHandlerMock.AddAirportInformationToCouchbase(airportDto);

            AirportViewModel airportViewModel = new AirportViewModel
            {
                AirportCode = airportDto.AirportCode,
                CityOrAirportName = airportDto.CityOrAirportName,
                Country = airportDto.Country,
                CountryCode = airportDto.CountryCode,
                LatitudeDegree = airportDto.LatitudeDegree,
                LongitudeDegree = airportDto.LongitudeDegree
            };

            AirportController airportController = new AirportController(m_AirportControllerHandlerMock);

            var result = airportController.Search(code) as ActionResult;

            Assert.IsNotNull(airportViewModel);
            Assert.IsNotNull(result);
        }


        [Test]
        public void SearchWhenParamIsEmptyOrNull()
        {
            Init();

            string code = string.Empty;

            AirportController airportController = new AirportController(m_AirportControllerHandlerMock);

            var result = airportController.Search(code) as ActionResult;

            Assert.IsNull(result);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            m_AirportControllerHandlerMock = Substitute.For<IAirportControllerHandler>();
        }
    }
}