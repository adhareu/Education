using System.Data.Entity;
using Education.Infrastructure;

namespace Education.Model
{
    /// <summary>
    /// Database Factory
    /// Manage Db Context
    /// Author: Asif Iqbal
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContext dataContext;
        public DbContext Get()
        {
            return dataContext ?? (dataContext = new Education_DbEntities());
        }
       
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
