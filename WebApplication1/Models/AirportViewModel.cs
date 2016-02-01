using System;
using System.ComponentModel.DataAnnotations;

namespace CouchbaseWebService.Web.Models
{
    [Serializable]
    public sealed class AirportViewModel
    {
        [Display(Name = "Airport Code")]
        public string AirportCode { get; set; }

        [Display(Name = "City/Airport Name")]
        public string CityOrAirportName { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Display(Name = "Latitude Degree")]
        public string LatitudeDegree { get; set; }

        [Display(Name = "Longitude Degree")]
        public string LongitudeDegree { get; set; }
    }
}