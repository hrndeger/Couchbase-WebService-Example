using CouchbaseWebService.Web.Data.Interface;
using CouchbaseWebService.Web.ServiceReference1;
using CouchbaseWebService.Web.Utilities;

namespace CouchbaseWebService.Web.Data
{
    public sealed class ServiceDAO : IServiceDAO
    {
        #region Fields

        private readonly airportSoapClient m_AirportSoapClient;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDAO"/> class.
        /// </summary>
        public ServiceDAO()
        {
            m_AirportSoapClient = new airportSoapClient();
        }

        #endregion

        public string GetAirportInformationByAirportCode(string airportCode)
        {
            if (!airportCode.IsNullOrDefault())
            {
                string response = m_AirportSoapClient.getAirportInformationByAirportCode(airportCode);
                return response;
            }

            return null;
        }
    }
}