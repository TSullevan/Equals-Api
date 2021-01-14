using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equals_Api.Models.EntityModel.CardLayouts
{
    public static class CardLayoutMap
    {
        public static void Map(this EntityTypeBuilder<CardLayout> entity)
        {
            entity.ToTable("CartaoBase");
            entity.Property(p => p.Id).HasColumnName("ID").UseIdentityColumn();
            entity.Property(p => p.RegisterType).HasColumnName("TIPO_REGISTRO");
            entity.Property(p => p.ProcessDate).HasColumnName("ESTABELECIMENTO");
            entity.Property(p => p.Establishment).HasColumnName("DATA_PROCESSAMENTO");
            entity.Property(p => p.FirstPeriod).HasColumnName("PERIODO_INICIAL");
            entity.Property(p => p.FinalPeriod).HasColumnName("PERIODO_FINAL");
            entity.Property(p => p.Sequence).HasColumnName("SEQUENCIA");

            entity.Property(p => p.AcquiringCompanyId).HasColumnName("EA_ID");

            entity.HasOne(p => p.AcquiringCompany).WithMany(p => p.CardLayouts).HasForeignKey(p => p.AcquiringCompanyId);
        }
    }
}
