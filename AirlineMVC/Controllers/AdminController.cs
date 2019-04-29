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
    public class AdminController : Controller
    {
        // GET: Admin
        // GET: AdminLogin

        DbAirlineEntities3 obj = new DbAirlineEntities3();

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        //t his method is used for login in themvc portal by the admin for beter services with the user name or password 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminArea()
        {
            return View();
        }
     
        public ActionResult Login(String srch, String srchn)
        {
            return View(obj.tbAdmins.Where(x => x.SName.Equals(srch) && x.SPassword.Equals(srchn)).ToList());

        }


        // this method is used to pass the connection string to the crud with the help of ado.net to pass all the queries 
        void connectionString()
        {
            con.ConnectionString = "Data Source=DESKTOP-QULTHGL\\SQLEXPRESS;Initial Catalog=DbAirline;Integrated Security=True";

        }

        [HttpPost]
        public ActionResult Verify(Admin log)
        {
            //verify the user name or password after filling the user name or password 
            connectionString();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "select * from tbAdmin where SName='" + log.UserName + "' and SPassword='" + log.Password + "'";

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //if the user name is correct then transfer the focus to adminarea
                con.Close();
                return View("AdminArea");
            }
            else
            {
                //if  its wrong then move to invalid user name or password page this concept is used with the help of crud and entites 
                con.Close();
                return View("Wrong");
            }
        }


    }
}