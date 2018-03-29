using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
namespace newApp3.charts
{
    public partial class userVisits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // PopulateDDLWeather();


            if (!Page.IsPostBack)
            {
                ddlWeather_Load();
            }
            //GetUserMetric();
        }


       


        public static DataTable GetUserMetric()
        {
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(constr))
            {


                SqlDataAdapter adapter = new SqlDataAdapter("SELECT count(city) as COUNT,city,regionCode From userVisits  Group by city,regionCode", con);
                adapter.Fill(dt);
              


            }

            var k = dt.Rows.Count;
          
            return dt;
        }



        [WebMethod]
        public static Dictionary<string,int> GetUserVisitsByCity (string city)
        {
            var response = new string[2];
            Dictionary<string, int> CityData = new Dictionary<string, int>();
            var dt = GetUserMetric();
            foreach (DataRow datarow in dt.Rows)
            {
                var cityKey = datarow["city"].ToString();
                var state = datarow["regionCode"].ToString();
                cityKey = cityKey + "," + state;
                var cityCount = int.Parse(datarow["COUNT"].ToString());
                CityData.Add(cityKey, cityCount);
            }
            return CityData;
            
        }

        [WebMethod]
        public static dynamic GetWeatherByCity(string city)
        {
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(constr))
            {

                var cmd = "SELECT * FROM weather where WOEID = " + city;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd, con);
                adapter.Fill(dt);
                List<Dictionary<string, Object>> rows = new List<Dictionary<string, Object>>();
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                Dictionary<string, object> row;
                foreach (DataRow datarow in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, datarow[col]);
                    }
                    rows.Add(row);
                }
                var k = dt.Rows.Count;

                //var p = serializer.DeserializeObject(rows);
                //return serializer.Deserialize(rows);
                return rows;
            }

           
           

        }

        protected void ddlWeather_Load()
        {
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            DataTable ddl = new DataTable();

            using (SqlConnection con = new SqlConnection(constr))
            {


                SqlDataAdapter adapter = new SqlDataAdapter("spPopulateWeatherDDL", con);
                adapter.Fill(ddl);
                ddlWeather.DataSource = ddl;
                ddlWeather.DataTextField = "city";
                ddlWeather.DataValueField = "WOEID";
                ddlWeather.DataBind();
                //DataSet ds = new DataSet();
                //adapter.Fill(ds);
                //ddlState.DataSource = ds.Tables[0];
                //ddlWeather.DataSource = ddl;
                //ddlState.DataTextField = "stateName";
                //ddlState.DataValueField = "stateID";
                //ddlState.DataBind();


            }
            var k = ddl.Rows.Count;
        }
    }
}