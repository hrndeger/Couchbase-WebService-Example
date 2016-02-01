using System.Web.Mvc;
using CouchbaseWebService.Web.ControllerHandler;
using CouchbaseWebService.Web.ControllerHandler.Interface;
using CouchbaseWebService.Web.Controllers;
using CouchbaseWebService.Web.Data;
using CouchbaseWebService.Web.Data.Interface;
using CouchbaseWebService.Web.Manager;
using CouchbaseWebService.Web.Manager.Interface;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace CouchbaseWebService.Web
{
    public class Bootstrapper
    {
        /// <summary>
        /// Initialises this instance.
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer Initialise()
        {
            IUnityContainer container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }

        /// <summary>
        /// Builds the unity container.
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<ICouchbaseDAO, CouchbaseDAO>();
            container.RegisterType<IServiceDAO,ServiceDAO>();
            container.RegisterType<IAirportManager,AirportManager>();
            container.RegisterType<IAirportControllerHandler,AirportControllerHandler>();
            container.RegisterType<IController,AirportController>("Airport");

            CustomControllerFactory.MvcUnityContainer.Container = container;
            return container;
        }
    }
}