using Couchbase;
using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.Data.Interface;
using CouchbaseWebService.Web.Utilities;

namespace CouchbaseWebService.Web.Data
{
    public sealed class CouchbaseDAO : ICouchbaseDAO
    {
        #region Fields

        private static Cluster m_Cluster;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="CouchbaseDAO"/> class.
        /// </summary>
        public CouchbaseDAO()
        {
            m_Cluster = new Cluster();
        }

        #endregion

        /// <summary>
        /// Gets the airport information from couchbase by airport code.
        /// </summary>
        /// <param name="airportCode">The airport code.</param>
        /// <returns></returns>
        public AirportDto GetAirportInformationFromCouchbaseByAirportCode(string airportCode)
        {
            if (!string.IsNullOrWhiteSpace(airportCode))
            {
                using (var defaultBucket = m_Cluster.OpenBucket())
                {
                    IDocumentResult<AirportDto> document = defaultBucket.GetDocument<AirportDto>(airportCode);

                    if (!document.IsNullOrDefault() && !document.Document.IsNullOrDefault())
                    {
                        AirportDto content = document.Document.Content;

                        AirportDto airportDto = new AirportDto
                        {
                            AirportCode = content.AirportCode,
                            CityOrAirportName = content.CityOrAirportName,
                            Country = content.Country,
                            CountryCode = content.CountryCode,
                            LatitudeDegree = content.LatitudeDegree,
                            LongitudeDegree = content.LongitudeDegree
                        };

                        return airportDto;      
                    }
                }    
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
            bool result = default (bool);
            
            if (!airportDto.IsNullOrDefault())
            {
                using (var defaultBucket = m_Cluster.OpenBucket())
                {
                    Document<AirportDto> document = new Document<AirportDto>
                    {
                        Id = airportDto.AirportCode,
                        Content = new AirportDto
                        {
                            AirportCode = airportDto.AirportCode,
                            CityOrAirportName = airportDto.CityOrAirportName,
                            Country = airportDto.Country,
                            CountryCode = airportDto.CountryCode,
                            LatitudeDegree = airportDto.LatitudeDegree,
                            LongitudeDegree = airportDto.LongitudeDegree
                        }
                    };

                    IDocumentResult<AirportDto> upsert = defaultBucket.Upsert(document);
                    if (upsert.Success)
                    {
                        result = true;
                    }
                }     
            }
            return result;
        }
    }
}