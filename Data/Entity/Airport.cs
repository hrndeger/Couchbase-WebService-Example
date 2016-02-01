using System;
using System.Xml.Serialization;

namespace Data.Entity
{
    [Serializable]
    [XmlRoot("Table")]
    public sealed class Airport
    {
        public string AirportCode { get; set; }
        public string CityOrAirportName { get; set; }
        public string Country { get; set; }
        public string CountryAbbrviation { get; set; }
        public string CountryCode { get; set; }
        public string GMTOffset { get; set; }
        public string RunwayLengthFeet { get; set; }
        public string RunwayElevationFeet { get; set; }
        public string LatitudeDegree { get; set; }
        public string LatitudeMinute { get; set; }
        public string LatitudeSecond { get; set; }
        public string LatitudeNpeerS { get; set; }
        public string LongitudeDegree { get; set; }
        public string LongitudeMinute { get; set; }
        public string LongitudeSeconds { get; set; }
        public string LongitLongitudeEperWudeSeconds { get; set; }
    }
}