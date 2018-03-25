using Asset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset.Cache.Interfaces
{
    public interface IGenericCacheRepository<T> where T : BaseEntity
    {
        bool Exists();
        IEnumerable<T> GetAll();
        void Add(List<T> entities);
        void Delete();
    }
}
