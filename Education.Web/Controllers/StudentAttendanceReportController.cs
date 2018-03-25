using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Web.Controllers
{
    public class StudentAttendanceReportController : Controller
    {
        // GET: StudentAttendanceReport
        public ActionResult Index()
        {
            return View();
        }
    }
}