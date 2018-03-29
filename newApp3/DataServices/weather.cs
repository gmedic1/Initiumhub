using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace newApp3.DataServices
{
    public class weather
    {
        public string City { get; set; }

        string _city;
        public weather(string city)
        {
            this._city = city;
        }

        public WeatherInfo GetWeather()
        {
            var accuweatherLocation = GetLocationDeatils(this._city);
            var weatherInfo = new WeatherInfo();
            var cityKey = accuweatherLocation.Key;
            var accuWeatherKey = ConfigurationManager.AppSettings["AccuWeatherKey"];
            var AWLocationurl = "http://dataservice.accuweather.com/currentconditions/v1/" + cityKey + @"?apikey=" + accuWeatherKey;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AWLocationurl);
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    dynamic json = JsonConvert.DeserializeObject(responseFromServer);
                   // wea.Key = json[0]["Key"];
                    weatherInfo.currentTemp = json[0]["Temperature"]["Imperial"]["Value"];
                    weatherInfo.description = json[0]["WeatherText"];
                    //accuWeatherLocation.State = json[0]["AdministrativeArea"]["LocalizedName"];
                    //accuWeatherLocation.Country = json[0]["Country"]["LocalizedName"];



                }
            }

            return weatherInfo;

           


        }

        private AccuWeatherLocation GetLocationDeatils(string city)
        {
           
            var cityArr = city.Split(',');
            var cityName = "";
            var country = "";
            var state = "";

            if (cityArr.Length < 3)
            {
                cityName = cityArr[0];
                country = cityArr[1];
            }

            else if (cityArr.Length == 3)
            {
                cityName = cityArr[0];
                country = cityArr[2];
                state = cityArr[1];
            }
            var APPID = ConfigurationManager.AppSettings["WeatherKey"];
            var accuWeatherKey = ConfigurationManager.AppSettings["AccuWeatherKey"];
            var accuWeatherCityCode = "";
            var databaseResults = new List<AccuWeatherLocation>();
            //var weatherInfo = new WeatherInfo();
            var accuWeatherLocation = new AccuWeatherLocation();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAccuWeatherLocation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cityName", SqlDbType.VarChar).Value = cityName;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var dataSet = new AccuWeatherLocation();
                        dataSet.Key = dr["locationKey"].ToString();
                        dataSet.City = dr["cityName"].ToString();
                        dataSet.State = dr["state"].ToString();
                        dataSet.Country = dr["country"].ToString();
                        databaseResults.Add(dataSet);
                    }

                    dr.Close();
                    con.Close();

                }
            }


            if (databaseResults.Count < 1)
            {
                var AWLocationurl = "http://dataservice.accuweather.com/locations/v1/cities/search?q=" + city + @"&apikey=" + accuWeatherKey;
                 ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AWLocationurl);
                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();
                        dynamic json = JsonConvert.DeserializeObject(responseFromServer);
                        var p = json[0]["Key"];
                        
                        accuWeatherLocation.Key = json[0]["Key"];
                        accuWeatherLocation.City = json[0]["LocalizedName"];
                        accuWeatherLocation.State = json[0]["AdministrativeArea"]["LocalizedName"];
                        accuWeatherLocation.Country = json[0]["Country"]["LocalizedName"];
                        accuWeatherLocation.saveAccuWeatherLocation();

                    }
                }
            }
            else if (databaseResults.Count == 1)
            {
                accuWeatherLocation = databaseResults[0];
            }
            else
            {
                var res = databaseResults.Where(p => p.Country == country);
                //List<AccuWeatherLocation> citiesList = res.ToList<AccuWeatherLocation>(); 

                var k = res.ToList();
                var res2 = new List<AccuWeatherLocation>();
                if (k.Count > 1)
                {
                    res2 = res.Where(p => p.State == state).ToList();
                    accuWeatherLocation = res2[0];
                }
            }


            return accuWeatherLocation;

        }

    }

    public class AccuWeatherLocation
    {
        public string Key { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        public void saveAccuWeatherLocation()
        {
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("spSaveAccuWeatherLocation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@locationKey", SqlDbType.VarChar).Value = Key;
                    cmd.Parameters.Add("@cityName", SqlDbType.VarChar).Value = City;
                    cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = State;
                    cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = Country;
                       con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }
    }


    public class WeatherInfo
    {
        public string description { get; set; }
        public string currentTemp { get; set; }
        public string minTemp { get; set; }
        public string maxTemp { get; set; }
        public string videoPath { get; set; }
    }


}