using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.ControllerHandler.Interface;
using CouchbaseWebService.Web.Manager.Interface;
using CouchbaseWebService.Web.Utilities;

namespace CouchbaseWebService.Web.ControllerHandler
{
    public sealed class AirportControllerHandler : IAirportControllerHandler
    {
        #region Fields

        private readonly IAirportManager m_AirportManager;

        #endregion

        #region Ctor

        public AirportControllerHandler(IAirportManager airportManager)
        {
            if (!airportManager.IsNullOrDefault())
            {
                m_AirportManager = airportManager;
            }
        }

        #endregion

        public AirportDto GetAirportInformationByAirportCode(string airportCode)
        {
            if (!string.IsNullOrWhiteSpace(airportCode))
            {
                AirportDto result = m_AirportManager.GetAirportInformationByAirportCode(airportCode);
                return result;
            }

            return default(AirportDto);
        }

        public AirportDto GetAirportInformationFromCouchbaseByAirportCode(string airportCode)
        {
            if (!string.IsNullOrWhiteSpace(airportCode))
            {
                AirportDto result = m_AirportManager.GetAirportInformationFromCouchbaseByAirportCode(airportCode);
                return result;
            }

            return default(AirportDto);
        }

        public bool AddAirportInformationToCouchbase(AirportDto airportDto)
        {
            if (!airportDto.IsNullOrDefault())
            {
                bool result = m_AirportManager.AddAirportInformationToCouchbase(airportDto);
                return result;
            }

            return default(bool);
        }
    }
}