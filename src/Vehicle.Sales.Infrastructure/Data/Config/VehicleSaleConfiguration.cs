using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vehicle.Sales.Core.VehicleSaleAggregate;

namespace Vehicle.Sales.Infrastructure.Data.Config
{
    public class VehicleSaleConfiguration : IEntityTypeConfiguration<VehicleSale>
    {
        public void Configure(EntityTypeBuilder<VehicleSale> builder)
        {
            builder.Property(t => t.DealNumber)
                .IsRequired();
        }
    }
}
