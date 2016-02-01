using CouchbaseWebService.Data.Dto;

namespace CouchbaseWebService.Web.Manager.Interface
{
    public interface IAirportManager
    {
        AirportDto GetAirportInformationByAirportCode(string airportCode);

        AirportDto GetAirportInformationFromCouchbaseByAirportCode(string airportCode);

        bool AddAirportInformationToCouchbase(AirportDto airportCode);
    }
}