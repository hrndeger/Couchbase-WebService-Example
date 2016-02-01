namespace CouchbaseWebService.Data.Dto
{
    public class AirportDto
    {
        public string AirportCode { get; set; }
        public string CityOrAirportName { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string LatitudeDegree { get; set; }        
        public string LongitudeDegree { get; set; }
    }
}