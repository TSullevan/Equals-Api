using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equals_Api.Models.EntityModel.DeliveryPeriodicitys
{
    public static class DeliveryPeriodicityMap
    {
        public static void Map(this EntityTypeBuilder<DeliveryPeriodicity> entity)
        {
            entity.ToTable("PeriodicidadeEntrega");
            entity.Property(p => p.Id).HasColumnName("ID").UseIdentityColumn();
            entity.Property(p => p.DaysWaiting).HasColumnName("INTERVALO_DIA");
            entity.Property(p => p.FilesQty).HasColumnName("QTD_ARQUIVO");

            entity.Property(p => p.AcquiringCompanyId).HasColumnName("EA_ID");

            entity.HasOne(p => p.AcquiringCompany).WithOne(p => p.DeliveryPeriodicity).HasForeignKey<DeliveryPeriodicity>(p => p.AcquiringCompanyId);
        }
    }
}