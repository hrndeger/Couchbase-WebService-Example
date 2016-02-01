using System.Web.Mvc;
using CouchbaseWebService.Data.Dto;
using CouchbaseWebService.Web.ControllerHandler.Interface;
using CouchbaseWebService.Web.Models;
using CouchbaseWebService.Web.Utilities;

namespace CouchbaseWebService.Web.Controllers
{
    public class AirportController : Controller
    {
        private readonly IAirportControllerHandler m_AirportControllerHandler;

        public AirportController()
        {
            
        }

        public AirportController(IAirportControllerHandler airportControllerHandler)
        {
            if (!airportControllerHandler.IsNullOrDefault())
            {
                m_AirportControllerHandler = airportControllerHandler;    
            }
        }

        public ActionResult Search()
        {
            return View(new AirportViewModel());
        }

        [HttpPost]
        public ActionResult Search(string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                AirportDto airportDto = m_AirportControllerHandler.GetAirportInformationFromCouchbaseByAirportCode(code);

                if (airportDto.IsNullOrDefault())
                {
                    airportDto = m_AirportControllerHandler.GetAirportInformationByAirportCode(code);
                    m_AirportControllerHandler.AddAirportInformationToCouchbase(airportDto); 
                }
                
                if (!airportDto.IsNullOrDefault())
                {
                    AirportViewModel airportViewModel = new AirportViewModel
                    {
                        AirportCode = airportDto.AirportCode,
                        CityOrAirportName = airportDto.CityOrAirportName,
                        Country = airportDto.Country,
                        CountryCode = airportDto.CountryCode,
                        LatitudeDegree = airportDto.LatitudeDegree,
                        LongitudeDegree = airportDto.LongitudeDegree
                    };

                    return View(airportViewModel);
                }
            }

            return null;
        }
    }
}