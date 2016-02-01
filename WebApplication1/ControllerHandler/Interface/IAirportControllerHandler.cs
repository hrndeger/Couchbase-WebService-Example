using CouchbaseWebService.Data.Dto;

namespace CouchbaseWebService.Web.ControllerHandler.Interface
{
    public interface IAirportControllerHandler
    {
        AirportDto GetAirportInformationByAirportCode(string airportCode);
     
        AirportDto GetAirportInformationFromCouchbaseByAirportCode(string airportCode);
        
        bool AddAirportInformationToCouchbase(AirportDto airportCode);
    }
}