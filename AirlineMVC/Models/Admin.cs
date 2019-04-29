using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineMVC.Models
{
    public class Admin
    {
        //global variable of the getter setter class to pass or check the user name or password 
        //if the filled username and password is right then it will move to next page if not it will move wrong password page
        public String UserName { get; set; }

        public String Password { get; set; }
    }
}