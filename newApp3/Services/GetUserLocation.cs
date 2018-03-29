using newApp3.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;


namespace newApp3.Services
{
    public class LocationHelpers
    {
        public LocationInformation GetUserPlace(){

            string targetIP = "";
            if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
            {
                targetIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
           // return targetIP;
            string IPForward = "";
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                IPForward = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
           // return IPForward;
            string userAgent = "";
            if (HttpContext.Current.Request.ServerVariables["http_user_agent"] != null)
            {
                userAgent = HttpContext.Current.Request.ServerVariables["http_user_agent"].ToString();
            }
            string requestMethod = "";
            if (HttpContext.Current.Request.ServerVariables["request_method"] != null)
            {
                requestMethod = HttpContext.Current.Request.ServerVariables["request_method"].ToString();
            }
            string serverMethod = "";
            if (HttpContext.Current.Request.ServerVariables["server_name"] != null)
            {
                serverMethod = HttpContext.Current.Request.ServerVariables["server_name"].ToString();
            }
            string serverPort = "";
            if (HttpContext.Current.Request.ServerVariables["server_port"] != null)
            {
                serverPort = HttpContext.Current.Request.ServerVariables["server_port"].ToString();
            }
            string serverSoftware = "";
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
            if (System.Net.Dns.GetHostName() != null)
            {
                strHostName = System.Net.Dns.GetHostName();
            }

            var ipRegex = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            var ipFromDnsFinal = string.Empty;
            //strHostName = "EC2AMAZ-0BSC11J";
            if (Dns.GetHostAddresses(strHostName) != null)
            {
                IPAddress[] ipaddress = Dns.GetHostAddresses(strHostName);
                //return (string.Join(",",
                //          ipaddress.Select(x => x.ToString()).ToArray()));
                foreach (var ipFromDns in ipaddress)
                {
                   
                    var isMatch = Regex.Match(ipFromDns.ToString(), ipRegex, RegexOptions.IgnoreCase);
                    if (isMatch.Success)
                    {
                       // return (ipFromDns.ToString());
                        ipFromDnsFinal = ipFromDns.ToString();
                    }
                }
            }


            string urlIP;
           // IPForward = ipFromDnsFinal;
           if(String.IsNullOrEmpty(targetIP))
            {
                urlIP = ipFromDnsFinal;
            }
            else
            {
                urlIP = targetIP;
            }
            //Initializing a new xml document object to begin reading the xml file returned
            XmlDocument doc = new XmlDocument();
            //var ipRegex = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            //var ip2 = "173.160.164.169";
            var match = Regex.Match(userHostAddr, ipRegex, RegexOptions.IgnoreCase);//match will fail when checking in dev local
            doc.Load("http://ip-api.com/xml/");
            XmlNodeList nodelstIP = doc.GetElementsByTagName("query");
            XmlNodeList nodelstCountryCode = doc.GetElementsByTagName("countryCode");
            XmlNodeList nodeLstCountry = doc.GetElementsByTagName("country");
            XmlNodeList nodeLstRegion = doc.GetElementsByTagName("region");
            XmlNodeList nodelstRegionName = doc.GetElementsByTagName("regionName");
            XmlNodeList nodeLstCity = doc.GetElementsByTagName("city");
            XmlNodeList nodelstZipCode = doc.GetElementsByTagName("zip");
            XmlNodeList nodeLstTimeZone = doc.GetElementsByTagName("timezone");
            XmlNodeList nodeLstLat = doc.GetElementsByTagName("lat");
            XmlNodeList nodeLstLong = doc.GetElementsByTagName("lon");
            XmlNodeList nodeLstMetroCode = doc.GetElementsByTagName("isp");

            var maskedip = nodelstIP[0].InnerText;
            var maskedcountryCode = nodelstCountryCode[0].InnerText;
            var maskedcountryName = nodeLstCountry[0].InnerText;
            var maskedregionCode = nodeLstRegion[0].InnerText;
            var maskedregionName = nodelstRegionName[0].InnerText;
            var maskedcity = nodeLstCity[0].InnerText;
            var maskedzipCode = nodelstZipCode[0].InnerText;
            var maskedtimeZone = nodelstZipCode[0].InnerText;
            var maskedlat = nodeLstLat[0].InnerText;
            var maskedlon = nodeLstLong[0].InnerText;
            var maskedmetroCode = nodeLstMetroCode[0].InnerText;


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

            var ip = "";
            if (urlIP != string.Empty)
            {
                var url = "http://ip-api.com/xml/" + urlIP;
                //doc = null;
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                doc.Load(url);
                ip = urlIP;
                //return (ip);
            }
            else
            {
          
                nodelstIP = doc.GetElementsByTagName("IP");
                ip = nodelstIP[0].InnerText;
            }


            
            nodelstCountryCode = doc.GetElementsByTagName("countryCode");
            nodeLstCountry = doc.GetElementsByTagName("country");
            nodeLstRegion = doc.GetElementsByTagName("region");
            nodelstRegionName = doc.GetElementsByTagName("regionName");
            nodeLstCity = doc.GetElementsByTagName("city");
             nodelstZipCode = doc.GetElementsByTagName("zip");
             nodeLstTimeZone = doc.GetElementsByTagName("timezone");
             nodeLstLat = doc.GetElementsByTagName("lat");
             nodeLstLong = doc.GetElementsByTagName("lon");
             nodeLstMetroCode = doc.GetElementsByTagName("isp");
            var nodelstStatus = doc.GetElementsByTagName("status");


            var status = nodelstStatus[0].InnerText;

            //status = "0";
            string countryCode; string countryName; string regionCode; string regionName; string city;string zipCode; string timeZone;
            string lat;string metroCode; string lon;
            if (status!="fail" )
            {
                //return "Fail IF";
                countryCode = nodelstCountryCode[0].InnerText;
                //return countryCode + 'c';
                if (String.IsNullOrWhiteSpace(countryCode))
                {
                    //return "Fail IF";
                    countryCode = maskedcountryCode;
                    
                }
                 countryName = nodeLstCountry[0].InnerText;
                //return countryName;
                if (String.IsNullOrWhiteSpace(countryName))
                {
                    countryName = maskedcountryName;
                }
                 regionCode = nodeLstRegion[0].InnerText;
                //return regionCode;
                if (String.IsNullOrWhiteSpace(regionCode))
                {
                    regionCode = maskedregionCode;
                }
                 regionName = nodelstRegionName[0].InnerText;
                //return regionName;
                if (String.IsNullOrWhiteSpace(regionName))
                {
                    regionName = maskedregionName;
                }

                 city = nodeLstCity[0].InnerText;
                //return city;
                if (String.IsNullOrWhiteSpace(city))
                {
                    city = maskedcity;
                }
                 zipCode = nodelstZipCode[0].InnerText;
                //return zipCode;
                if (String.IsNullOrWhiteSpace(zipCode))
                {
                    zipCode = maskedzipCode;
            }
            timeZone = nodeLstTimeZone[0].InnerText;
                if (String.IsNullOrWhiteSpace(timeZone))
                {
                    timeZone = maskedtimeZone;
                }
                 lat = nodeLstLat[0].InnerText;
                if (String.IsNullOrWhiteSpace(lat))
                {
                    lat = maskedlat;
                }
                 lon = nodeLstLong[0].InnerText;
                if (String.IsNullOrWhiteSpace(lon))
                {
                    lon = maskedlon;
                }
                 
                 metroCode = nodeLstMetroCode[0].InnerText;
                if (String.IsNullOrWhiteSpace(metroCode))
                {
                    metroCode = maskedmetroCode;
                }
            }
            else
            { //return "ELSE";
                countryCode = maskedcountryCode;
                countryName = maskedcountryName;
                regionCode = maskedregionCode;
                regionName = maskedregionName;
                city = maskedcity;
                zipCode = maskedzipCode;
                timeZone = maskedtimeZone;
                lat = maskedlat;
                lon = maskedlon;
                metroCode = maskedmetroCode;
            }
           // var ip = nodelstIP[0].InnerText;
           


            var siteVisitor = new SiteVisitor(strHostName, ip, countryCode, countryName, regionCode, regionName, city, zipCode, timeZone, lat, lon, metroCode, IPForward, userAgent, requestMethod, serverMethod, serverPort, serverSoftware, userHostAddr, targetIP,
                maskedip, maskedcountryCode, maskedcountryName, maskedregionCode, maskedregionName, maskedcity);
            siteVisitor.saveSiteVisitor();

            var result = new LocationInformation();
            result.City = city;
            result.State = regionName;
            result.StateCode = regionCode;
            result.Country = countryName;
            result.CountryCode = countryCode;
            result.zipcode = zipCode;
            //var result = city + ", " + regionCode + ", " + countryName;
            var usetrendClass =  new GetTrends(result);
           result.WOEID =  usetrendClass.getWOEIDByCity(); //Adding WOEID Information from existing GetTrends class
           

            return (result);
           

        }


       // public void 

        public class LocationInformation
        {
            public string City { get; set; }
            public string State { get; set; }
            public string StateCode { get; set; }

            public string Country { get; set; }
            public string CountryCode { get; set; }
            public string zipcode { get; set; }
            public string WOEID { get; set; }
            //public string location { get; set; }
        }

    }
}