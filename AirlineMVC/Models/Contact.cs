using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineMVC.Models
{
    public class Contact
    {
        // global varibale of the contact using the getteer setter function of method 
        //variable are decalared so that data can be transfered into data base
        public String SName { get; set; }

        public String SEmail { get; set; }


        public String SMsg { get; set; }
    }
}