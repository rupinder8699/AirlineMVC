using AirlineMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirlineMVC.Controllers
{
    public class ContactDataController : Controller
    {

        // GET: ContactData
        //object of data base to fetch the record from the table and display in the table format with the help of crud and entity fromat 
        DbAirlineEntities2 objdata = new DbAirlineEntities2();
        //this action is used to fetch the whole record from the table who is contact with us through the contact page . we can see the whole record with the hep of crud entities format

        public ActionResult ConactData()
        {
            return View(objdata.tbContacts.ToList());
        }

        // GET: ContactData/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactData/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactData/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactData/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactData/Delete/5
        public ActionResult Delete(tbContact tbId)
        {
            //delete the record of the particular id after clicking on the id or delete button with the help of crud record format 
            var d = objdata.tbContacts.Where(x => x.ID == tbId.ID).FirstOrDefault();
            objdata.tbContacts.Remove(d);
            objdata.SaveChanges();
            return RedirectToAction("ConactData");
        }

        // POST: ContactData/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
