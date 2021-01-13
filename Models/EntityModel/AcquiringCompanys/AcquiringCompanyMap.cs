using System.Collections.Generic;
using Equals_Api.Models.EntityModel.CardLayouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equals_Api.Models.EntityModel.AcquiringCompanys
{
    public static class AcquiringCompanyMap
    {
        public static void Map(this EntityTypeBuilder<AcquiringCompany> entity)
        {
            entity.ToTable("EmpresaAdquirente");
            entity.Property(p => p.Id).HasColumnName("ID").UseIdentityColumn();
            entity.Property(p => p.Description).HasColumnName("TIPO_REGISTRO");

            entity.HasMany(p => p.CardLayouts).WithOne(p => p.AcquiringCompany).HasForeignKey(p => p.AcquiringCompanyId);
        }
    }
}
