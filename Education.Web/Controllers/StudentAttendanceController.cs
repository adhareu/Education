using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using Education.Model;
namespace Education.Web.Controllers
{
    public class StudentAttendanceController : Controller
    {
        Education_DbEntities db = new Education_DbEntities();
        // GET: StudentAttendance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult DetailsReport()

        {

            LocalReport localReport = new LocalReport();

            localReport.ReportPath = Server.MapPath("~/Reports/StudentAttendanceReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", db.StudentAttendanceView.ToList());



            localReport.DataSources.Add(reportDataSource);

            string reportType = "PDF";

            string mimeType;

            string encoding;

            string fileNameExtension;




            string deviceInfo =

"<DeviceInfo>" +

"  <OutputFormat>PDF</OutputFormat>" +

"  <PageWidth>8.5in</PageWidth>" +

"  <PageHeight>11in</PageHeight>" +

"  <MarginTop>0.5in</MarginTop>" +

"  <MarginLeft>1in</MarginLeft>" +

"  <MarginRight>1in</MarginRight>" +

"  <MarginBottom>0.5in</MarginBottom>" +

"</DeviceInfo>";


            Warning[] warnings;
            string[] streamids;
           
            

            byte[] bytes = localReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streamids, out warnings);


            Response.AddHeader("content-disposition", "attachment; filename=StudentAttendanceReport." + fileNameExtension);

            return File(bytes, mimeType);

        }
    }
}