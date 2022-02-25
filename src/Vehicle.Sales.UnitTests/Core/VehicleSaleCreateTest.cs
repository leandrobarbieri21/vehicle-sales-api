using System;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Xunit;

namespace Vehicle.Sales.UnitTests.Core
{
    public class VehicleSaleCreateTest
    {
        private VehicleSale _vehicleSale = new();

        public VehicleSaleCreateTest()
        {
            _vehicleSale = new VehicleSaleBuilder()
                .Id(1)
                .WithDefaultValues()
                .Build();
        }

        [Fact]
        public void Should_create_vehicle_sale_from_constructor()
        {
            var vehicleSale = new VehicleSale(1234, "Leandro", "Ford Marcas", "2022 Tucson", 30000, DateTime.Now);

            Assert.Equal(_vehicleSale.DealNumber, vehicleSale.DealNumber);
            Assert.Equal(_vehicleSale.CustomerName, vehicleSale.CustomerName);
        }

        [Fact]
        public void Should_create_vehicle_sale_from_csv_line()
        {
            var csvLine = "1234,Leandro,Ford Marcas,2022 Tucson,\"30,000\",2/20/2022";
            
            var vehicleSale = VehicleSale.CreateFromCsvLine(csvLine);

            Assert.Equal(_vehicleSale.DealNumber, vehicleSale.DealNumber);
            Assert.Equal(_vehicleSale.CustomerName, vehicleSale.CustomerName);
        }
    }
}
