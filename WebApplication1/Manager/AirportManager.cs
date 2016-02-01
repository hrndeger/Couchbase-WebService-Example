using System.Xml;
using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.Data.Interface;
using CouchbaseWebService.Web.Helper;
using CouchbaseWebService.Web.Manager.Interface;
using CouchbaseWebService.Web.Mapping;
using CouchbaseWebService.Web.Utilities;
using Data.Entity;

namespace CouchbaseWebService.Web.Manager
{
    public sealed class AirportManager : IAirportManager
    {

        #region Fields

        private readonly IServiceDAO m_ServiceDao;
        private readonly ICouchbaseDAO m_CouchbaseDao;

        #endregion

        #region Ctor

        public AirportManager(IServiceDAO serviceDao, ICouchbaseDAO couchbaseDao)
        {
            m_ServiceDao = serviceDao;
            m_CouchbaseDao = couchbaseDao;
        }

        #endregion

        /// <summary>
        /// Gets the airport information by airport code.
        /// </summary>
        /// <param name="airportCode">The airport code.</param>
        /// <returns></returns>
        public AirportDto GetAirportInformationByAirportCode(string airportCode)
        {
            if (!string.IsNullOrWhiteSpace(airportCode))
            {
                string response = m_ServiceDao.GetAirportInformationByAirportCode(airportCode);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(response);

                XmlNodeList nodeList = xmlDocument.SelectNodes("NewDataSet/Table");

                if (nodeList != null)
                {
                    string serializeObject = nodeList[0].SerializeObject();
                    Airport deserializeObject = (Airport) serializeObject.DeserializeObject<Airport>();

                    AirportDto result = MapToAirport.MapFromObjectToAirport(deserializeObject);
                    return result;
                }
            }

            return default(AirportDto);
        }

        /// <summary>
        /// Gets the airport information from couchbase by airport code.
        /// </summary>
        /// <param name="airportCode">The airport code.</param>
        /// <returns></returns>
        public AirportDto GetAirportInformationFromCouchbaseByAirportCode(string airportCode)
        {
            if (!string.IsNullOrWhiteSpace(airportCode))
            {
                AirportDto result = m_CouchbaseDao.GetAirportInformationFromCouchbaseByAirportCode(airportCode);
                return result;
            }

            return default(AirportDto);
        }

        /// <summary>
        /// Adds the airport information to couchbase.
        /// </summary>
        /// <param name="airportDto">The airport dto.</param>
        /// <returns></returns>
        public bool AddAirportInformationToCouchbase(AirportDto airportDto)
        {
            if (!airportDto.IsNullOrDefault())
            {
                bool result = m_CouchbaseDao.AddAirportInformationToCouchbase(airportDto);
                return result;                
            }

            return default(bool);
        }
    }
}