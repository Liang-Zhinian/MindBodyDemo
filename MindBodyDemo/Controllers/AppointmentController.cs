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
    }
}
