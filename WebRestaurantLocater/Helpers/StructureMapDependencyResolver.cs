using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace WebRestaurantLocater.Helpers
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;
        
        public StructureMapDependencyResolver(IContainer container)
        {
            _container = container;
        }
        
        public object GetService(Type serviceType)
        {
            return (serviceType.IsSubclassOf(typeof(Controller))) ? GetConcreteService(serviceType) : GetInterfaceService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances<object>().Where(x => x.GetType() == serviceType);
        }

        private object GetConcreteService(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        private object GetInterfaceService(Type serviceType)
        {
            return _container.TryGetInstance(serviceType);
        }
    }
}