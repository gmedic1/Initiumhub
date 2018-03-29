using newApp3.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace newApp3
{
    /// <summary>
    /// Summary description for locationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class locationService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //[WebMethod]
        //public string getUserLocation(string user)
        //{
        //    string IP = "";

        //    string strHostName = "";
        //    strHostName = System.Net.Dns.GetHostName();

        //    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        //    IPAddress[] addr = ipEntry.AddressList;
        //    string IPv4;
        //    if (addr.Length > 3)
        //    {

        //        IP = addr[3].ToString();

        //        IPv4 = addr[5].ToString();
        //    }
        //    else
        //    {
        //        IPv4 = addr[1].ToString();
        //        IP = "No IPv6 found";
        //    }
            

        //    //Initializing a new xml document object to begin reading the xml file returned
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load("http://www.freegeoip.net/xml");

        //    XmlNodeList nodelstIP = doc.GetElementsByTagName("IP");
        //    XmlNodeList nodelstCountryCode = doc.GetElementsByTagName("CountryCode");
        //    XmlNodeList nodeLstCountry = doc.GetElementsByTagName("CountryName");
        //    XmlNodeList nodeLstRegion = doc.GetElementsByTagName("RegionCode");
        //    XmlNodeList nodelstRegionName = doc.GetElementsByTagName("RegionName");
        //    XmlNodeList nodeLstCity = doc.GetElementsByTagName("City");
        //    XmlNodeList nodelstZipCode = doc.GetElementsByTagName("ZipCode");
        //    XmlNodeList nodeLstTimeZone = doc.GetElementsByTagName("TimeZone");
        //    XmlNodeList nodeLstLat = doc.GetElementsByTagName("Latitude");
        //    XmlNodeList nodeLstLong = doc.GetElementsByTagName("Longitude");
        //    XmlNodeList nodeLstMetroCode = doc.GetElementsByTagName("MetroCode");
        //    var ip = nodelstIP[0].InnerText;
        //    var countryCode = nodelstCountryCode[0].InnerText;
        //    var countryName = nodeLstCountry[0].InnerText;
        //    var regionCode = nodeLstRegion[0].InnerText;
        //    var regionName = nodelstRegionName[0].InnerText;
        //    var city = nodeLstCity[0].InnerText;
        //    var zipCode = nodelstZipCode[0].InnerText;
        //    var timeZone = nodeLstTimeZone[0].InnerText;
        //    var lat = nodeLstLat[0].InnerText;
        //    var lon = nodeLstLong[0].InnerText;
        //    var metroCode = nodeLstMetroCode[0].InnerText;


        //    var siteVisitor = new storeSiteVisitor(strHostName, ip, IPv4, countryCode, countryName, regionCode, regionName, city, zipCode, timeZone, lat, lon, metroCode);
        //    siteVisitor.saveSiteVisitor();

        //    // IP = "" + nodeLstCity[0].InnerText + "<br>" + IP;
        //    var result = nodeLstCity[0].InnerText + ", " + nodeLstRegion[0].InnerText + ", " + nodeLstCountry[0].InnerText;
        //    //var city = nodeLstCity[0].InnerText;
        //    return (result);
        //}
    }
}
