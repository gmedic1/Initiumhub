using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Script.Services;

namespace newApp3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadData();
            }
        }

        protected void loadData()
        {
           
            {
                var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

                DataTable ddl = new DataTable();

                using (SqlConnection con = new SqlConnection(constr))
                {

                  
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT stateID, stateName FROM state", con);
                    adapter.Fill(ddl);
                        //DataSet ds = new DataSet();
                        //adapter.Fill(ds);
                        //ddlState.DataSource = ds.Tables[0];
                    ddlState.DataSource = ddl;
                    ddlState.DataTextField = "stateName";
                        ddlState.DataValueField = "stateID";
                        ddlState.DataBind();
                    

                }
                var k = ddl.Rows.Count;
               //initial item
                ddlState.Items.Insert(0, new ListItem("---Select State---", "0"));

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var user = new UserRecord();
            user.FirstName = txtFirstName.Value.Trim();
            user.LastName = txtLastName.Value.Trim();
            user.Email = txtEmail.Value.Trim();
            user.Phone = txtPhoneNumber.Value.Trim();
            user.Zipcode = txtZipcode.Value.Trim();
            user.State = int.Parse(ddlState.SelectedValue);
           

            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertRecord", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = user.FirstName ;
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = user.Email;
                    cmd.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = user.Phone;
                    cmd.Parameters.Add("@zipcode", SqlDbType.VarChar).Value = user.Zipcode;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = user.State;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Success.aspx?Email="+user.Email);
                }
            }

        }

      

        public class UserRecord
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            
            public string Phone { get; set; }
            public string Zipcode { get; set; }
            public int State { get; set; }

        }
    }
}