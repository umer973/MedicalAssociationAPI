

namespace MedicalAssociationAPI
{
    using BusinessLogic.Admin;
    using BusinessLogic.Client;
    using BusinessLogic.Enquiry;
    using BusinessLogic.Partner;
    using System.Web.Http;
    using Unity;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAdmin, Admin>();
            container.RegisterType<IClient, Client>();
            container.RegisterType<IPartner, Partner>();
            container.RegisterType<IEnquiry, Enquiry>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}