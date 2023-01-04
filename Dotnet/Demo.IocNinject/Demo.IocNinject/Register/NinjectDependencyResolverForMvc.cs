using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Demo.IocNinject.Register
{
    public class NinjectDependencyResolverForMvc : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolverForMvc(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}