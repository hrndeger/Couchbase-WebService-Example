using System.Xml;
using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.Data.Interface;
using CouchbaseWebService.Web.Helper;
using CouchbaseWebService.Web.Manager;
using CouchbaseWebService.Web.Mapping;
using Data.Entity;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CouchbaseWebService.Test.Manager
{
    [TestFixture]
    public sealed class AirportManagerFixture
    {
        #region Fields

        private IServiceDAO m_ServiceDaoMock;
        private ICouchbaseDAO m_CouchbaseDaoMock;

        #endregion

        private const string response = "<NewDataSet>\n  <Table>\n    <AirportCode>AMS</AirportCode>\n    <CityOrAirportName>AMSTERDAM SCHIPHOL</CityOrAirportName>\n    <Country>Netherlands</Country>\n    <CountryAbbrviation>NL</CountryAbbrviation>\n    <CountryCode>461</CountryCode>\n    <GMTOffset>-1</GMTOffset>\n    <RunwayLengthFeet>11329</RunwayLengthFeet>\n    <RunwayElevationFeet>0</RunwayElevationFeet>\n    <LatitudeDegree>52</LatitudeDegree>\n    <LatitudeMinute>19</LatitudeMinute>\n    <LatitudeSecond>0</LatitudeSecond>\n    <LatitudeNpeerS>N</LatitudeNpeerS>\n    <LongitudeDegree>4</LongitudeDegree>\n    <LongitudeMinute>47</LongitudeMinute>\n    <LongitudeSeconds>0</LongitudeSeconds>\n    <LongitudeEperW>E</LongitudeEperW>\n  </Table>\n  <Table>\n    <AirportCode>AMS</AirportCode>\n    <CityOrAirportName>AMSTERDAM SCHIPHOL</CityOrAirportName>\n    <Country>Netherlands</Country>\n    <CountryAbbrviation>NL</CountryAbbrviation>\n    <CountryCode>461</CountryCode>\n    <GMTOffset>-1</GMTOffset>\n    <RunwayLengthFeet>11329</RunwayLengthFeet>\n    <RunwayElevationFeet>0</RunwayElevationFeet>\n    <LatitudeDegree>52</LatitudeDegree>\n    <LatitudeMinute>19</LatitudeMinute>\n    <LatitudeSecond>0</LatitudeSecond>\n    <LatitudeNpeerS>N</LatitudeNpeerS>\n    <LongitudeDegree>4</LongitudeDegree>\n    <LongitudeMinute>47</LongitudeMinute>\n    <LongitudeSeconds>0</LongitudeSeconds>\n    <LongitudeEperW>E</LongitudeEperW>\n  </Table>\n</NewDataSet>";

        [Test]
        public void GetAirportInformationByAirportCodeWhenParamIsValid()
        {
            Init();

            const string airportCode = "AMS";

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "AMSTERDAM SCHIPHOL",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            m_ServiceDaoMock.GetAirportInformationByAirportCode(airportCode).Returns(response);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(response);

            XmlNodeList nodeList = xmlDocument.SelectNodes("NewDataSet/Table");

            if (nodeList != null)
            {
                string serializeObject = nodeList[0].SerializeObject();
                Airport deserializeObject = (Airport)serializeObject.DeserializeObject<Airport>();

                MapToAirport.MapFromObjectToAirport(deserializeObject);
                
                AirportManager airportManager = new AirportManager(m_ServiceDaoMock, m_CouchbaseDaoMock);
                airportManager.GetAirportInformationByAirportCode(airportCode).ShouldBeEquivalentTo(airportDto);
            }
        }

        [Test]
        public void GetAirportInformationByAirportCodeWhenParamIsNullOrEmpty()
        {
            string airportCode = string.Empty;

            AirportManager airportManager = new AirportManager(m_ServiceDaoMock, m_CouchbaseDaoMock);
            AirportDto actual = airportManager.GetAirportInformationByAirportCode(airportCode);

            Assert.AreEqual(null, actual);
        }

        [Test]
        public void GetAirportInformationFromCouchbaseByAirportCodeWhenParamIsValid()
        {
            Init();
            const string airportCode = "AMS";

            AirportDto airportDto = new AirportDto
            {
                AirportCode = "AMS",
                CityOrAirportName = "Amsterdam",
                Country = "Netherlands",
                CountryCode = "461",
                LatitudeDegree = "52",
                LongitudeDegree = "4"
            };

            m_CouchbaseDaoMock.GetAirportInformationFromCouchbaseByAirportCode(airportCode).Returns(airportDto);

            AirportManager airportManager = new AirportManager(m_ServiceDaoMock, m_CouchbaseDaoMock);
            airportManager.GetAirportInformationFromCouchbaseByAirportCode(airportCode).ShouldBeEquivalentTo(airportDto);

        }

        [Test]
        public void GetAirportInformationFromCouchbaseByAirportCodeWhenParamIsNullOrEmpty()
        {
            string airportCode = string.Empty;

            AirportManager airportManager = new AirportManager(m_ServiceDaoMock, m_CouchbaseDaoMock);
            AirportDto actual = airportManager.GetAirportInformationFromCouchbaseByAirportCode(airportCode);

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

            var expected = m_CouchbaseDaoMock.AddAirportInformationToCouchbase(airportDto);

            AirportManager airportManager = new AirportManager(m_ServiceDaoMock, m_CouchbaseDaoMock);
            var actual = airportManager.AddAirportInformationToCouchbase(airportDto);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddAirportInformationToCouchbaseWhenParamIsNull()
        {
            Init();

            AirportDto airportDto = default(AirportDto);

            AirportManager airportManager = new AirportManager(m_ServiceDaoMock, m_CouchbaseDaoMock);
            var actual = airportManager.AddAirportInformationToCouchbase(airportDto);

            Assert.AreEqual(false, actual);
        }

        private void Init()
        {
            m_ServiceDaoMock = Substitute.For<IServiceDAO>();
            m_CouchbaseDaoMock = Substitute.For<ICouchbaseDAO>();
        }

    }
}