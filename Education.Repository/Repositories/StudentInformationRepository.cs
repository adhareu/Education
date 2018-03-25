using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Infrastructure;
using Education.Model;


namespace Education.Repository
{
    public interface IStudentInformationRepository : IRepository<StudentInformation>
    {
    }
    public class StudentInformationRepository : RepositoryBase<StudentInformation>, IStudentInformationRepository
    {
        public StudentInformationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
       
    }
}
