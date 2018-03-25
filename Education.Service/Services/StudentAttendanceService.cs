using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Infrastructure;
using Education.Model;

using Education.Repository;


namespace Education.Service
{
    public class StudentAttendanceService:IStudentAttendanceService
    {
        private IStudentAttendanceRepository repository;
        private IUnitOfWork unitOfWork;
        public StudentAttendanceService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new StudentAttendanceRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public StudentAttendanceService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new StudentAttendanceRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<StudentAttendance> GetAll()
        {
           
            var S_StudentAttendance = repository.GetAll().ToList();
           
            return S_StudentAttendance;
        }

        public StudentAttendance GetById(int id)
        {
            return repository.GetDataById(id);
        }

        public List<StudentAttendance> FindByDate(DateTime date)
        {
            return repository.GetMany(e => e.AttendanceDate==date).ToList();
        }
        public bool Add(StudentAttendance aStudentAttendance)
        {
            try
            {
                aStudentAttendance.Status =1;
                repository.Add(aStudentAttendance);
                unitOfWork.Commit();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Update(StudentAttendance aStudentAttendance)
        {
            try
            {

                repository.Update(aStudentAttendance);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(StudentAttendance aStudentAttendance)
        {
            try
            {

                repository.Update(aStudentAttendance);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
