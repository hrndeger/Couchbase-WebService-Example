using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.Utilities;
using Data.Entity;

namespace CouchbaseWebService.Web.Mapping
{
    public static class MapToAirport
    {
        public static AirportDto MapFromObjectToAirport(Airport airport)
        {
            if (!airport.IsNullOrDefault())
            {
                AirportDto airportDto = new AirportDto
                {
                    AirportCode = airport.AirportCode,
                    Country = airport.Country,
                    CountryCode = airport.CountryCode,
                    CityOrAirportName = airport.CityOrAirportName,
                    LatitudeDegree = airport.LatitudeDegree,
                    LongitudeDegree = airport.LongitudeDegree
                };

                return airportDto;
            }

            return null;
        }
    }
}