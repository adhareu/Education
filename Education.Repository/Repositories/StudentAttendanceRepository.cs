using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Infrastructure;
using Education.Model;


namespace Education.Repository
{
    public interface IStudentAttendanceRepository : IRepository<StudentAttendance>
    {
    }
    public class StudentAttendanceRepository : RepositoryBase<StudentAttendance>, IStudentAttendanceRepository
    {
        public StudentAttendanceRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
       
    }
}
