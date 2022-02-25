using System;
using Vehicle.Sales.Core.VehicleSaleAggregate;

namespace Vehicle.Sales.UnitTests
{
    public class VehicleSaleBuilder
    {
        private VehicleSale _vehicleSale = new();

        public VehicleSaleBuilder Id(int id)
        {
            _vehicleSale.Id = id;
            return this;
        }

        public VehicleSaleBuilder WithDefaultValues()
        {
            _vehicleSale = new VehicleSale(1234, "Leandro", "Ford Marcas", "2022 Tucson", 30000, DateTime.Now);
            return this;
        }

        public VehicleSale Build() => _vehicleSale;
    }
}
