using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WeatherFromOpenWeatherMap.Models
{
    public class OpenWeatherMapDAL
    {
        //https://api.openweathermap.org/data/2.5/forecast?zip=[ZIP CODE],us&APPID=[YOUR API KEY]
        public static List<Forecast> GetFiveDayThreeHourForecastJSON(string zipcode)
        {
            string apiKey = ConfigReaderDAL.ReadSetting("api_key");
            string url = $"https://api.openweathermap.org/data/2.5/forecast?zip={zipcode},us&APPID={apiKey}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string apiText = rd.ReadToEnd();

            return GetDateTempPressureFromApiText(apiText);
        }

        public static List<Forecast> GetDateTempPressureFromApiText(string apiText)
        {
            JToken json = JToken.Parse(apiText);
            List<JToken> jsonTokens = json["list"].ToList();

            List<Forecast> forecasts = new List<Forecast>();
            foreach (JToken token in jsonTokens)
            {
                //string forecastToken = token.ToString();
                int time = int.Parse(token["dt"].ToString());
                double temperature = double.Parse(token["main"]["temp"].ToString());
                double pressure = double.Parse(token["main"]["pressure"].ToString());
               
                Forecast forecast = new Forecast(time, temperature, pressure);
                forecasts.Add(forecast);
            }

            return forecasts;
        }


    }
}