using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineMVC.Models;

namespace AirlineMVC.Controllers
{
    public class PlaneController : Controller
    {
        // GET: Plane fetching the details of plains from database
        DbAirlineEntities1 objdata = new DbAirlineEntities1();
        // this action of the cru is used to see the whole record of the table in the table format with the help of crud format and display in the view page 

        public ActionResult ViewPlane()
        {
            return View(objdata.tbPlanes.ToList());
        }

        // GET: Plane/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plane/Create   for inserting new record into the databse
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plane/Create
        // this method is used to create a plane in the record for the better performance  with the help of crud and entities using crete model
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] tbPlane plane)
        {
            if (!ModelState.IsValid)
                return View();
            objdata.tbPlanes.Add(plane);
            objdata.SaveChanges();
              return RedirectToAction("ViewPlane");


        }
        // GET: Plane/Edit/5
        // edit the record after getting the id from the record for updation and pass the id to the next edit method for save the changes 
        public ActionResult Edit(int id)
        {
            var planeId= (from m in objdata.tbPlanes where m.ID == id select m).First();
            return View(planeId);
        }

        // POST: Plane/Edit/5
        [HttpPost]
        // this method is used to save the changes in the table using ado.net with entity 
        public ActionResult Edit(tbPlane planeId)
        {

            var orignalRecord = (from m in objdata.tbPlanes where m.ID ==planeId.ID select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            objdata.Entry(orignalRecord).CurrentValues.SetValues(planeId);

            objdata.SaveChanges();
            return RedirectToAction("ViewPlane");

        }

        // GET: Plane/Delete/5
        public ActionResult Delete(tbPlane planeid)
        {
            //delete the record of the particular id after clicking on the id or delete button
            var d = objdata.tbPlanes.Where(x => x.ID == planeid.ID).FirstOrDefault();
           objdata.tbPlanes.Remove(d);
            objdata.SaveChanges();
            return RedirectToAction("ViewPlane");
        }

        // POST: Plane/Delete/5
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
