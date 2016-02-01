using CouchbaseWebService.Data.Dto;

namespace CouchbaseWebService.Web.Data.Interface
{
    public interface ICouchbaseDAO
    {
        AirportDto GetAirportInformationFromCouchbaseByAirportCode(string airportCode);

        bool AddAirportInformationToCouchbase(AirportDto airportDto);
    }
}