using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newApp3
{
    public partial class Sucess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static User UpperWM(string email)
        {
            var user = GetRecords(email);
            return user;
        }

        protected static User GetRecords( string email)
        {
            var user = new User();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetRecords", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        user.FirstName = dr["FirstName"].ToString();
                        user.LastName = dr["LastName"].ToString();
                        user.Pnumber= dr["phoneNumber"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.zipcode = dr["Zipcode"].ToString();
                        user.State = dr["State"].ToString();

                    }

                    dr.Close();
                    con.Close();

                }
            }

            return user;
        }



        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Pnumber { get; set; }
            public string zipcode { get; set; }
            public string State { get; set; }
        }
    }
}