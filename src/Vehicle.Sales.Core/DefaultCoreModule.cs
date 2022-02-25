using Autofac;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.Services;

namespace Vehicle.Sales.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleSaleCreateService>()
                .As<IVehicleSaleCreateService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleSaleDeleteService>()
                .As<IVehicleSaleDeleteService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleSaleImportService>()
                .As<IVehicleSaleImportService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleSaleSearchService>()
                .As<IVehicleSaleSearchService>().InstancePerLifetimeScope();
        }
    }
}
