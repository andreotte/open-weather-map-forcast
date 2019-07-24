using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherFromOpenWeatherMap.Models;

namespace WeatherFromOpenWeatherMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string zipCode)
        {
            List<Forecast> forecasts = OpenWeatherMapDAL.GetFiveDayThreeHourForecastJSON(zipCode);
            return View(forecasts);
        }
    }
}