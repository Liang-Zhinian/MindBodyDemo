using MindBodyDemo.Models.BL;
using MindBodyDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MindBodyDemo.Controllers
{
    public class AppointmentController : Controller
    {
        //
        // GET: /Appointment/

        public ActionResult Index(string firstName, string lastName, string staffId)
        {
            IMindBodyDemoBL bl = new MindBodyDemoBL();
            var model = bl.GetStaffAppointments(firstName, lastName, staffId);
            return View(model);
        }

        //
        // GET: /Appointment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Appointment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Appointment/Create

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

        //
        // GET: /Appointment/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Appointment/Edit/5

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

        //
        // GET: /Appointment/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Appointment/Delete/5

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
