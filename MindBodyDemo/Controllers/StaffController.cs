using MindBodyDemo.Models.BL;
using MindBodyDemo.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MindBodyDemo.Controllers
{
    public class StaffController : Controller
    {
        //
        // GET: /Staff/

        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            IMindBodyDemoBL bl = new MindBodyDemoBL();
            var model = bl.GetCompanyStaff();
            return View(model);
        }

        //
        // GET: /Staff/Appointment/6

        public ActionResult Appointment(string id)
        {
            IMindBodyDemoBL bl = new MindBodyDemoBL();
            var model = bl.GetStaffAppointments(id);
            return View(model);
        }


        //
        // GET: /Staff/Info/5

        public ActionResult Info(string id)
        {
            IMindBodyDemoBL bl = new MindBodyDemoBL();
            var model = bl.GetStaffInfo(id);
            return View(model);
        }
    }
}
