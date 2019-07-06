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
            List<Forecast> forecasts = OpenWeatherMapDAL.GetFiveDayThreeHourForecastJSON("49505");
            return View(forecasts);
        }
    }
}