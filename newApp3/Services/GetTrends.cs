using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using newApp3.DataServices;
using Newtonsoft.Json.Linq;
using newApp3.Services;
using static newApp3.Services.LocationHelpers;
using System.Xml;

namespace newApp3.Services
{
    public class GetTrends
    {
        private static LocationInformation _location { get; set; }
        public GetTrends(LocationInformation locationInformation)
        {
            _location = locationInformation;
        }
        string WOEID;
        public string getWOEIDByCity()
        {

            var city = _location.City;
            var state = _location.State;
            var country = _location.Country;

            //city = "Seattle";state = "Washington";country = "united states";

            DataSet ds = new DataSet("WOEIDS");
            DataTable dt = new DataTable();
            SqlConnection myConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spCheckWOEID", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();

            cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
            cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = state;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = country;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    WOEID = dr[0].ToString();
                }
            }


            if (string.IsNullOrWhiteSpace(WOEID))
            {
                return (RequestWEOID(_location));
            }

            else
            {
                getTwitterData(WOEID);
                return WOEID;
            }

        }
        public string RequestWEOID(LocationInformation location)
        {
            string url = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20geo.places%20where%20text%3D%22" + location.City + "%20" + location.State + "%20" + location.Country + "%22&format=xml";
            //string url = @"http://query.yahooapis.com/v1/public/yql?q=select * from geo.places where text%3D%22" + @location.City + @"," + @location.State + @", " + location.Country + @"&format=xml";
            var doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList nodelstwoeid = doc.GetElementsByTagName("woeid");
            var woeid = nodelstwoeid[0].InnerText;
            var city = location.City;
            var state = location.State;
            var country = location.Country;
            //var zipcode = location.zipcode;
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateNewWOEID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = city;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = state;

                    cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = country;
                    cmd.Parameters.Add("@WOEID", SqlDbType.VarChar).Value = woeid;


                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            getTwitterData(WOEID);
            return "";

        }
        public static string [] getTwitterData(string WOEID)
        {
            var arr = new string[5];
            //var ConsumerKey = ConfigurationManager.AppSettings["twitter_consumer_key"];
            //var ConsumerSecret = ConfigurationManager.AppSettings["twitter_consumer_secret"];
            //var UserToken = ConfigurationManager.AppSettings["twitter_user_token"];
            //var UserSecret = ConfigurationManager.AppSettings["twitter_user_secret"];

            //var url = "https://api.twitter.com/1.1/trends/place.json?id=" + WOEID;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //request.Method = "GET";
            //request.Headers.Add(HttpRequestHeader.Authorization, "oauth_consumer_key=" + ConsumerKey);
            ////request.Headers.Add(HttpRequestHeader.Authorization, "ConsumerSecret " + ConsumerSecret);
            //request.Headers.Add(HttpRequestHeader.Authorization, "oauth_token=" + UserToken);
            ////request.Headers.Add(HttpRequestHeader.Authorization, "TokenSecret " + UserSecret);
            ////request.Headers.Add(auth, "OAuth1.0")

            //var response = (HttpWebResponse)request.GetResponse();

            //JArray array;
            //var weatherInfo = new WeatherInfo();

            var twitterTrends = new twitter(WOEID);
           




            return arr;


        }




            








            

        
    }
}