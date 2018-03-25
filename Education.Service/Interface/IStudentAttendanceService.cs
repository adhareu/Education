using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Service
{
   public interface IStudentAttendanceService
    {
        List<StudentAttendance> GetAll();
        StudentAttendance GetById(int id);
        List<StudentAttendance> FindByDate(DateTime date);
        bool Add(StudentAttendance aStudentAttendance);
        bool Update(StudentAttendance aStudentAttendance);
        bool Delete(StudentAttendance aStudentAttendance);
    }
}
