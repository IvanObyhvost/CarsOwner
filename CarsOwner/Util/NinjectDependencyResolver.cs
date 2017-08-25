using Ninject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using CarsOwner.BLL.Interface;
using CarsOwner.BLL.Services;
using CarsOwner.DAL.Interface;
using CarsOwner.DAL.Repository;

namespace IoSApp.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IOwnerService>().To<OwnerService>();
            kernel.Bind<IOwnerRepository>().To<OwnerRepository>();

            kernel.Bind<ICarService>().To<CarService>();
            kernel.Bind<ICarRepository>().To<CarRepository>();
        }
    }
}