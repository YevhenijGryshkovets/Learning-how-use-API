using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWithAPI
{
    internal class Program
    {
        static void Main(string[] args) //50.42521737344382, 30.459336523106515
        {
            string url = @"https://api.openweathermap.org/data/2.5/weather?lat=50.42521737344382&&units=metric&lon=30.459336523106515&appid=9a5f1d07a77b773a9e4b7f5a619d5582";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            var json = JObject.Parse(response);
            var weather = json["main"];
            var name = json["name"];

            Console.WriteLine("The weather in " + name + " " + weather["temp"] + " Celsius degree");
            Console.Write("Press key for finish ");
            Console.ReadKey();
        }
    }
}
