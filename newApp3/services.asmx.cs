using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;
using System.Web.Routing;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using newApp3.DataServices;
using System.Text.RegularExpressions;
using System.Web.UI;

using System.Web.UI.WebControls;
using newApp3.Services;
using static newApp3.Services.LocationHelpers;
using System.Reflection;

namespace newApp3
{
    /// <summary>
    /// Summary description for services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class services : System.Web.Services.WebService
    {

        [WebMethod]
        public string sendMessage(string Message)
        {
            dynamic message = new JavaScriptSerializer().Deserialize<Object>(Message);

            var userNAme = message["Name"];


            var sub = new Subscription(message["Name"], message["Email"],message["Phone"], message["userMessage"],message["MessageStamp"]);

           

          

            sub.saveSubscription();
            //var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand("spCreateSubscription", con))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = message._Name.ToString();
            //        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = message.Email.ToString();

            //        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = message.Phone.ToString();
            //        cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = message.userMessage.ToString();
            //        cmd.Parameters.Add("@MessageStamp", SqlDbType.NVarChar).Value = message.MessageStamp.ToString();



            //        con.Open();
            //        cmd.ExecuteNonQuery();

            //    }
            //}

            return "Success";
        }

        [WebMethod]
        public Subscription getMessage(Object email, Object MessageStamp)
        {
            var message = new Subscription(email.ToString(),MessageStamp.ToString());


            return message.GetMessage(email.ToString(), MessageStamp.ToString());
        }

        [WebMethod]
        public string SendEmail(string email, string MessageStamp)
        {
            var subscription = new Subscription(email,MessageStamp);
            subscription.sendEmail(email,MessageStamp);
            return "Email Sent";
        }

       
        [WebMethod]
        public string GetUserLocation(string window)
        {
            string targetIP ="";
            if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null) {
              targetIP  = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString(); }
            string IPForward ="";
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] !=null)
            {
                 IPForward = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            string userAgent ="";
            if (HttpContext.Current.Request.ServerVariables["http_user_agent"] != null){
                 userAgent = HttpContext.Current.Request.ServerVariables["http_user_agent"].ToString();
            }
            string requestMethod ="";
            if ( HttpContext.Current.Request.ServerVariables["request_method"] != null) {
                requestMethod = HttpContext.Current.Request.ServerVariables["request_method"].ToString();
            }
            string serverMethod="";
            if (HttpContext.Current.Request.ServerVariables["server_name"] !=null)
            {
                serverMethod = HttpContext.Current.Request.ServerVariables["server_name"].ToString();
            }
            string serverPort="";
            if (HttpContext.Current.Request.ServerVariables["server_port"] != null)
            {
                serverPort = HttpContext.Current.Request.ServerVariables["server_port"].ToString();
            }
            string serverSoftware="";
            if (HttpContext.Current.Request.ServerVariables["server_port"] != null)
            {
                serverSoftware = HttpContext.Current.Request.ServerVariables["server_software"].ToString();
            }

            string userHostAddr = string.Empty;
           
            if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                userHostAddr = HttpContext.Current.Request.UserHostAddress;
            }

            string strHostName = "";
            if(System.Net.Dns.GetHostName() != null)
            {
                strHostName = System.Net.Dns.GetHostName();
            }
            var ipRegex = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            var ipFromDnsFinal = string.Empty;
            if (Dns.GetHostAddresses(strHostName) != null)
            {
                IPAddress[] ipaddress = Dns.GetHostAddresses(strHostName);
                foreach (var ipFromDns in ipaddress)
                {
                   
                    var isMatch = Regex.Match(ipFromDns.ToString(), ipRegex, RegexOptions.IgnoreCase);
                    if (isMatch.Success)
                    {
                        ipFromDnsFinal = ipFromDns.ToString();
                    }
                }
            }
            
          
           
            IPForward = ipFromDnsFinal;


            //GetUserLocation();

            //Initializing a new xml document object to begin reading the xml file returned
            XmlDocument doc = new XmlDocument();
           ;
            //var ip2 = "173.160.164.169";
            var match = Regex.Match(userHostAddr, ipRegex, RegexOptions.IgnoreCase);
            doc.Load("http://ip-api.com/xml/");
            XmlNodeList nodelstIP = doc.GetElementsByTagName("IP");
            XmlNodeList nodelstCountryCode = doc.GetElementsByTagName("CountryCode");
            XmlNodeList nodeLstCountry = doc.GetElementsByTagName("CountryName");
            XmlNodeList nodeLstRegion = doc.GetElementsByTagName("RegionCode");
            XmlNodeList nodelstRegionName = doc.GetElementsByTagName("RegionName");
            XmlNodeList nodeLstCity = doc.GetElementsByTagName("City");
            var maskedip = nodelstIP[0].InnerText;
            var maskedcountryCode = nodelstCountryCode[0].InnerText;
            var maskedcountryName = nodeLstCountry[0].InnerText;
            var maskedregionCode = nodeLstRegion[0].InnerText;
            var maskedregionName = nodelstRegionName[0].InnerText;
            var maskedcity = nodeLstCity[0].InnerText;
            //XmlNodeList nodelstZipCode = doc.GetElementsByTagName("ZipCode");
          
            if (!match.Success)
            {
                doc.Load("http://ip-api.com/xml/");
              
                //return ("123");

            }
            else
            {  // IPAddress[] addr = ipEntry.AddressList;
                var url = "http://ip-api.com/xml/" + userHostAddr;

               
                
                doc.Load(url);
            }

            var ip ="";
            if (IPForward != string.Empty)
            {
                var url = "http://www.freegeoip.net/xml/" + IPForward;
                doc.Load(url);
                ip = IPForward;
            }
            else
            {
                ip =  nodelstIP[0].InnerText;
            }
           
          
             nodelstIP = doc.GetElementsByTagName("IP");
             nodelstCountryCode = doc.GetElementsByTagName("CountryCode");
             nodeLstCountry = doc.GetElementsByTagName("CountryName");
             nodeLstRegion = doc.GetElementsByTagName("RegionCode");
             nodelstRegionName = doc.GetElementsByTagName("RegionName");
             nodeLstCity = doc.GetElementsByTagName("City");
            XmlNodeList nodelstZipCode = doc.GetElementsByTagName("ZipCode");
            XmlNodeList nodeLstTimeZone = doc.GetElementsByTagName("TimeZone");
            XmlNodeList nodeLstLat = doc.GetElementsByTagName("Latitude");
            XmlNodeList nodeLstLong = doc.GetElementsByTagName("Longitude");
            XmlNodeList nodeLstMetroCode = doc.GetElementsByTagName("MetroCode");
             
            var countryCode = nodelstCountryCode[0].InnerText;
            var countryName = nodeLstCountry[0].InnerText;
            var regionCode = nodeLstRegion[0].InnerText;
            var regionName = nodelstRegionName[0].InnerText;
            var city = nodeLstCity[0].InnerText;
            var zipCode = nodelstZipCode[0].InnerText;
            var timeZone = nodeLstTimeZone[0].InnerText;
            var lat = nodeLstLat[0].InnerText;
            var lon = nodeLstLong[0].InnerText;
            var metroCode = nodeLstMetroCode[0].InnerText;


            var siteVisitor = new storeSiteVisitor(strHostName, ip,  countryCode, countryName, regionCode, regionName, city, zipCode, timeZone, lat, lon, metroCode, IPForward, userAgent,requestMethod,serverMethod, serverPort, serverSoftware,userHostAddr, targetIP,
                maskedip, maskedcountryCode, maskedcountryName, maskedregionCode, maskedregionName, maskedcity);
            siteVisitor.saveSiteVisitor();

            // IP = "" + nodeLstCity[0].InnerText + "<br>" + IP;
            var result = nodeLstCity[0].InnerText + ", " + nodeLstRegion[0].InnerText + ", " + nodeLstCountry[0].InnerText ;
            //var city = nodeLstCity[0].InnerText;

            return (result);
            //return (result);
            ////Response.Write(IP);
            ////this is my header that I love
        }
        [WebMethod]
        public WeatherInfo GetWeather(string city)
        {
            var weather = new weather(city);
            var weatherInfo = weather.GetWeather();
            weatherInfo.videoPath =  setVideo(weatherInfo.currentTemp, weatherInfo.description);
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            var cityArr = city.Split(',');
            var cityLocation = cityArr[0];
            var cityCountry = cityArr[cityArr.Length - 1];
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("spSaveWeather", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = cityLocation;
                    cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = cityCountry;

                    

                    cmd.Parameters.Add("@MaxTemp", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@MinTemp", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@CurrentTemp", SqlDbType.VarChar).Value = weatherInfo.currentTemp;
                 
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                   
                }
            }
            return weatherInfo;
        }

        [WebMethod]
        public LocationInformation GetUserCity()
        {
            var userLocation = new Services.LocationHelpers();

           return(userLocation.GetUserPlace());
        }

        [WebMethod]
        public string GetTrends(string locationInformation)
        {
           
            //Type type = Type.GetType(locationInformation);
            JObject jObject = JObject.Parse(locationInformation);
            var location = new LocationInformation();
            location.City = (string)jObject["City"];
            location.Country = (string)jObject["Country"];
            location.CountryCode = (string)jObject["CountryCode"];
            location.State = (string)jObject["State"];
            location.StateCode = (string)jObject["StateCode"];
            location.zipcode = (string)jObject["zipcode"];
            
            var trends = new GetTrends(location);
            trends.getWOEIDByCity();

            return ("1");
            
        }

      

        public static string setVideo (string currentTemp, string condition)
        {
            var temp = 100.00 - double.Parse(currentTemp);

            var weather = "";
            if(temp > 55.00)
            {
                weather = "Snow";
            }
            else if(temp <55.0)
            {
                weather = "Summer";
            }
            else if (condition.ToLower().IndexOf("rain") != -1)
            {
                weather = "Rain";
            }

            var videoPath = "";

            switch (weather)
            {
                case "Snow":
                    videoPath = @"assets/VideoBG/Snow/";
                    break;

                case "Summer":
                    videoPath = @"assets/VideoBG/Summer/";
                    break;
                case "Rain":
                    videoPath = @"assets/VideoBG/Rain/";
                    break;
            }

            var Path = new Dictionary<string, string[]>();
            Path.Add("Rain",new string[]{ @"Cold-Stream/Cold-stream.mp4"});
            Path.Add("Snow", new string[] { @"Fency-Snow/Fency-Snow.mp4",@"Frozen_stream/Frozen_stream.mp4",@"Mt_Baker/Mt_Baker.mp4"
                        ,@"Snow-Dog/Snow-Dog.mp4",@"Ski-Day/Ski-Day.mp4",@"Snowy-Bench/Snowy-Bench.mp4",@"Snow-Bricks/Snow-Bricks.mp4",@"It-Snowed/It-Snowed.mp4"});
            Path.Add("Summer", new string[] { @"Desert-Watching/Desert-Watching.mp4", @"Desert_Storm/Desert_Storm.mp4",
                        @"Friday_Afternoon/Friday_Afternoon.mp4",@"Summer_Place_Flyby/Summer_Place_Flyby.mp4" });


            var pathArr = Path[weather];
            var random = new Random();
            var num = random.Next(0, pathArr.Length);
            var pathString = videoPath+ pathArr[num];

            return (pathString);
             

            
        }

       
    }
}
