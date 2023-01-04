using Demo.IocNinject.Contract;
using Demo.IocNinject.Repository;
using Ninject;
using System.Web.Http;
using System.Web.Mvc;

namespace Demo.IocNinject.Register
{
    public class NinjectRegister
    {
        private static IKernel ninjectKernel;

        static NinjectRegister()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        public static void RegisterFovMvc()
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolverForMvc(ninjectKernel));
        }

        public static void RegisterFovWebApi(HttpConfiguration config)
        {
            config.DependencyResolver = new NinjectDependencyResolverForWebApi(ninjectKernel);
        }


        private static void AddBindings()
        {
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
    
}