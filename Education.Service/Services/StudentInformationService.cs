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
    public class StudentInformationService:IStudentInformationService
    {
        private IStudentInformationRepository repository;
        private IUnitOfWork unitOfWork;
        public StudentInformationService()
        {
            var objDatabaseFactory = new DatabaseFactory();
            repository = new StudentInformationRepository(objDatabaseFactory);
            unitOfWork = new UnitOfWork(objDatabaseFactory);
        }
        //public StudentInformationService(string connString)
        //{
        //    var objDatabaseFactory = new DatabaseFactory();
        //    repository = new StudentInformationRepository(connString,objDatabaseFactory);
        //    unitOfWork = new UnitOfWork(objDatabaseFactory);
        //}

        public List<StudentInformation> GetAll()
        {
           
            var S_StudentInformation = repository.GetAll().ToList();
           
            return S_StudentInformation;
        }

        public StudentInformation GetById(int id)
        {
            return repository.GetDataById(id);
        }

        public List<StudentInformation> FindByName(string name)
        {
            return repository.GetMany(e => e.StudentName.Equals(name)).ToList();
        }
        public bool Add(StudentInformation aStudentInformation)
        {
            try
            {
                aStudentInformation.Status =1;
                repository.Add(aStudentInformation);
                unitOfWork.Commit();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Update(StudentInformation aStudentInformation)
        {
            try
            {

                repository.Update(aStudentInformation);
                unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(StudentInformation aStudentInformation)
        {
            try
            {

                repository.Update(aStudentInformation);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
