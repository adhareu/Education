using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Education.Model;

using Education.Service;
using System.Web.Http.Cors;

namespace Education.WebAPI.Controllers.Setup
{
   
    public class StudentAttendanceController : ApiController
    {
        private readonly IStudentAttendanceService _StudentAttendanceService;
        public StudentAttendanceController(IStudentAttendanceService StudentAttendanceService)
        {
            _StudentAttendanceService = StudentAttendanceService;
        }
        // GET: api/StudentAttendance
       
        [HttpGet]
        public List<StudentAttendance> GetAllStudentAttendance()
        {
            return _StudentAttendanceService.GetAll();
        }

        // GET: api/StudentAttendance/5
      
        [HttpGet]
        [ResponseType(typeof(StudentAttendance))]
        public StudentAttendance GetStudentAttendance(int id)
        {
            StudentAttendance aStudentAttendance = _StudentAttendanceService.GetById(id);
           
                return aStudentAttendance;
            
    
           
        }

        // PUT: api/StudentAttendance/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddStudentAttendance( StudentAttendance aStudentAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _StudentAttendanceService.Add(aStudentAttendance);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentAttendance
       
        [HttpPut]
        [ResponseType(typeof(StudentAttendance))]
        public IHttpActionResult UpdateStudentAttendance(StudentAttendance aStudentAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _StudentAttendanceService.Update(aStudentAttendance);

            return CreatedAtRoute("DefaultApi", new { id = aStudentAttendance.AttendanceId }, aStudentAttendance);
        }

        // DELETE: api/StudentAttendance/5
     
        [HttpDelete]
        [ResponseType(typeof(StudentAttendance))]
        public IHttpActionResult DeleteStudentAttendance(int id)
        {
            StudentAttendance aStudentAttendance = _StudentAttendanceService.GetById(id);
            if (aStudentAttendance == null)
            {
                return NotFound();
            }

            _StudentAttendanceService.Delete(aStudentAttendance);

            return Ok(aStudentAttendance);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
       
        [HttpGet]
        public List<StudentAttendance> GetStudentAttendanceBydate(DateTime date)
        {
            return _StudentAttendanceService.FindByDate(date);
        }
    }
}