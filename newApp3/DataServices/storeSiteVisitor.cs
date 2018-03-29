using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace newApp3.DataServices
{
    public class storeSiteVisitor
    {
        private static string _hostName { get; set; }
        private static string _ip { get; set; }
        private static string _countryCode { get; set; }
        private static string _countryName { get; set; }
        private static string _regionCode { get; set; }
        private static string _regionName { get; set; }
        private static string _city { get; set; }
        private static string _zipCode { get; set; }
        private static string _timeZone { get; set; }
        private static string _lat { get; set; }
        private static string _lon { get; set; }
        private static string _metroCode { get; set; }
        // private static string _ipv4 { get; set; }
        private static string _IPForward { get; set; }
        private static string _userAgent { get; set; }
        private static string _requestMethod { get; set; }
        private static string _serverMethod { get; set; }
        private static string _serverPort { get; set; }
        private static string _serverSoftware { get; set; }
        private static string _userHostAddr { get; set; }
        private static string _targetIP { get; set; }
        private static string _maskedip { get; set; }
        private static string _maskedcountryCode { get; set; }
        private static string _maskedcountryName { get; set; }
        private static string _maskedregionCode { get; set; }
        private static string _maskedregionName { get; set; }
        private static string _maskedcity { get; set; }



        public storeSiteVisitor(string hostName, string ip,  string countryCode, string countryName, string regionCode,string regionName,string city, string zipCode, string timeZone, string lat, string lon, string metroCode, string IPForward, string userAgent, string requestMethod, string serverMethod,
            string serverPort, string serverSoftware, string userHostAddr, string targetIP, string maskedip, string maskedcountryCode, string maskedcountryName,
            string maskedregionCode, string maskedregionName, string maskedcity)
        {
            _hostName = hostName;
            _ip = ip;
            _countryCode = countryCode;
            _countryName = countryName;
            _regionCode = regionCode;
            _regionName = regionName;
            _city = city;
            _zipCode = zipCode;
            _timeZone = timeZone;
            _lat = lat;
            _lon = lon;
            _metroCode = metroCode;
            //_ipv4 = ipv4;
            _IPForward = IPForward;
            _userAgent = userAgent;
            _requestMethod = requestMethod;
            _serverMethod = serverMethod;
            _serverPort = serverPort;
            _serverSoftware = serverSoftware;
            _userHostAddr = userHostAddr;
            _targetIP = targetIP;
            _maskedip = maskedip;
            _maskedcountryCode = maskedcountryCode;
            _maskedcountryName = maskedcountryName;
            _maskedregionCode = maskedregionCode;
            _maskedregionName = maskedregionName;
            _maskedcity = maskedcity;
        }

        public  void saveSiteVisitor()
        {   
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("spStoreVisitor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@hostName", SqlDbType.VarChar).Value = _hostName;
                    cmd.Parameters.Add("@ip", SqlDbType.VarChar).Value = _ip;
                    //cmd.Parameters.Add("@ipv4", SqlDbType.VarChar).Value = _ipv4;
                    cmd.Parameters.Add("@countryCode", SqlDbType.VarChar).Value = _countryCode;
                    cmd.Parameters.Add("@countryName", SqlDbType.VarChar).Value = _countryName;
                   
                    cmd.Parameters.Add("@regionCode", SqlDbType.VarChar).Value = _regionCode;
                    cmd.Parameters.Add("@regionName", SqlDbType.VarChar).Value = _regionName;
                    cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = _city;
                    cmd.Parameters.Add("@zipCode", SqlDbType.VarChar).Value = _zipCode;
                    cmd.Parameters.Add("@timeZone", SqlDbType.VarChar).Value = _timeZone;
                    cmd.Parameters.Add("@lat", SqlDbType.VarChar).Value = _lat;
                    cmd.Parameters.Add("@lon", SqlDbType.VarChar).Value = _lon;
                    cmd.Parameters.Add("@metroCode", SqlDbType.VarChar).Value = _metroCode;

                    cmd.Parameters.Add("@IPForward", SqlDbType.VarChar).Value = _IPForward;
                    cmd.Parameters.Add("@userAgent", SqlDbType.VarChar).Value = _userAgent;
                    cmd.Parameters.Add("@requestMethod", SqlDbType.VarChar).Value = _requestMethod;
                    cmd.Parameters.Add("@serverMethod", SqlDbType.VarChar).Value = _serverMethod;
                    cmd.Parameters.Add("@serverPort", SqlDbType.VarChar).Value = _serverPort;
                    cmd.Parameters.Add("@serverSoftware", SqlDbType.VarChar).Value = _serverSoftware;
                    cmd.Parameters.Add("@userHostAddr", SqlDbType.VarChar).Value = _userHostAddr;
                    cmd.Parameters.Add("@targetIP", SqlDbType.VarChar).Value = _targetIP;


                    cmd.Parameters.Add("@maskedip", SqlDbType.VarChar).Value = _maskedip;
                    cmd.Parameters.Add("@maskedcountryCode", SqlDbType.VarChar).Value = _maskedcountryCode;
                    cmd.Parameters.Add("@maskedcountryName", SqlDbType.VarChar).Value = _maskedcountryName;
                    cmd.Parameters.Add("@maskedregionCode", SqlDbType.VarChar).Value = _maskedregionCode;
                    cmd.Parameters.Add("@maskedregionName", SqlDbType.VarChar).Value = _maskedregionName;
                    cmd.Parameters.Add("@maskedcity", SqlDbType.VarChar).Value = _maskedcity;





                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }

    }
}