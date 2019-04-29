using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using AirlineMVC.Models;

namespace AirlineMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        // GET: AdminLogin
        //this controer is used to pass the message to the admin for any kind of query from the customer side with the help of crud entities nd data base queries 
        //WeakReference can use different type of concept with the help of object of the different classes
            SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;


        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=DESKTOP-QULTHGL\\SQLEXPRESS;Initial Catalog=DbAirline;Integrated Security=True";

        }
        // this method is used to pass the message to the database from the customer side for the queries using the entites concept 
        [HttpPost]
        public ActionResult Msg(Contact log)
        {
            // insert the feedback message for the admin for future performance  
            connectionString();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "insert into tbContact(Sname,Semail,Smsg) values('" + log.SName + "','" + log.SEmail + "','" + log.SMsg + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            return View("Message");


        }

    }
}