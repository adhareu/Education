using Education.Service;
using Education.WebAPI.DI;
using Microsoft.Practices.Unity;
using System.Web.Http;



namespace Education.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IStudentInformationService, StudentInformationService>();
            container.RegisterType<IStudentAttendanceService, StudentAttendanceService>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}