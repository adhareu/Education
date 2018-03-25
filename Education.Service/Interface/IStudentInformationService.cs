using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Service
{
   public interface IStudentInformationService
    {
        List<StudentInformation> GetAll();
        StudentInformation GetById(int id);
        List<StudentInformation> FindByName(string name);
        bool Add(StudentInformation aStudentInformation);
        bool Update(StudentInformation aStudentInformation);
        bool Delete(StudentInformation aStudentInformation);
    }
}
