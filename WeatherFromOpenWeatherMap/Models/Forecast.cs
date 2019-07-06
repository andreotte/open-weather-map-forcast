using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherFromOpenWeatherMap.Models
{
    public class Forecast
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }

        public Forecast(int timeUnix, double tempKelvin, double pressure_hPa)
        {
            Date = UnixTimeStampToDateTime(timeUnix);
            Temperature = KelvinToFarenheit(tempKelvin);
            Pressure = pressure_hPa;
        }

        public DateTime UnixTimeStampToDateTime(int timeUnix)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timeUnix).ToLocalTime();
            return dtDateTime;
        }

        public double KelvinToFarenheit(double tempKelvin)
        {
            return 1.8 * (tempKelvin - 273.15) + 32;
        }
    }
}