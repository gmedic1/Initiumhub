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

namespace newApp3.Services
{
    public class Subscription
    {
        public string _Name { get; set; }
        public string _Email { get; set; }
        public string _Phone { get; set; }
        public string _UserMessage { get; set; }
        public string _MessageStamp { get; set; }

        public Subscription(string name,string email, string phone, string userMessage, string messageStamp) 
        {
            _Name = name;
            _Email = email;
            _Phone = phone;
            _UserMessage = userMessage;
            _MessageStamp = messageStamp;
        }

        public Subscription(string email, string MessageStamp)
        {
            _Email = email;
            _MessageStamp = MessageStamp;
        }
        //public Subscription()
        //{

        //}

        public void saveSubscription()
        {
            var constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateSubscription", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = _Name.ToString();
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = _Email.ToString();

                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = _Phone.ToString();
                    cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = _UserMessage.ToString();
                    cmd.Parameters.Add("@MessageStamp", SqlDbType.NVarChar).Value = _MessageStamp.ToString();



                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }

        }



        public  Subscription GetMessage(string email, string MessageStamp)
        {
           // var message = new Subscription(email,MessageStamp);
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetSubscription", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@MessageStamp", SqlDbType.VarChar).Value = MessageStamp;
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        _Name = dr["Name"].ToString();

                        _Phone = dr["Phone"].ToString();
                        _Email = dr["Email"].ToString();
                        _UserMessage = dr["Message"].ToString().Replace("&quot", "\"");
                        _MessageStamp = dr["MessageStamp"].ToString();


                    }

                    dr.Close();
                    con.Close();

                }
            }

            return this;
        }


        public  void sendEmail(string email, string MessageStamp)
        {
            var fromAddress = new MailAddress("initiumhub@gmail.com", "Admin");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "initiumpassword";

            //const string body = "Body";
            var userMessage = GetMessage(email, MessageStamp);
            var subject = userMessage._Name + " " + userMessage._Email;

            var body = userMessage._UserMessage;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }



   
}