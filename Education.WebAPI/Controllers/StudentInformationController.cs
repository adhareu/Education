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
   
    public class StudentInformationController : ApiController
    {
        private readonly IStudentInformationService _StudentInformationService;
        public StudentInformationController(IStudentInformationService StudentInformationService)
        {
            _StudentInformationService = StudentInformationService;
        }
        // GET: api/StudentInformation
       
        [HttpGet]
        public List<StudentInformation> GetAllStudentInformation()
        {
            return _StudentInformationService.GetAll();
        }

        // GET: api/StudentInformation/5
      
        [HttpGet]
        [ResponseType(typeof(StudentInformation))]
        public StudentInformation GetStudentInformation(int id)
        {
            StudentInformation aStudentInformation = _StudentInformationService.GetById(id);
           
                return aStudentInformation;
            
    
           
        }

        // PUT: api/StudentInformation/5
     
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddStudentInformation( StudentInformation aStudentInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

           

                _StudentInformationService.Add(aStudentInformation);
           

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentInformation
       
        [HttpPut]
        [ResponseType(typeof(StudentInformation))]
        public IHttpActionResult UpdateStudentInformation(StudentInformation aStudentInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _StudentInformationService.Update(aStudentInformation);

            return CreatedAtRoute("DefaultApi", new { id = aStudentInformation.StudentId }, aStudentInformation);
        }

        // DELETE: api/StudentInformation/5
     
        [HttpDelete]
        [ResponseType(typeof(StudentInformation))]
        public IHttpActionResult DeleteStudentInformation(int id)
        {
            StudentInformation aStudentInformation = _StudentInformationService.GetById(id);
            if (aStudentInformation == null)
            {
                return NotFound();
            }

            _StudentInformationService.Delete(aStudentInformation);

            return Ok(aStudentInformation);
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
        public bool IsStudentInformationExists(string Name)
        {
            return _StudentInformationService.FindByName(Name).Count() > 0;
        }
    }
}