using ContabilidadHogar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadHogar.Database.Configurations
{
    public class MoneyControlConfiguration : IEntityTypeConfiguration<MoneyControl>
    {
        public void Configure(EntityTypeBuilder<MoneyControl> builder)
        {
            builder.HasKey(c => c.IdTransaction);
            builder.Property(b => b.IdTransaction).HasDefaultValueSql("NEWID()");
            builder.Property(b => b.Description).IsRequired().HasColumnType("varchar(100)");
            builder.Property(b => b.Details).HasColumnType("varchar(200)");
            builder.Property(b => b.TransactionDateTime).IsRequired();
            builder.Property(b => b.IncomeTransaction).IsRequired();
            builder.Property(b => b.BalanceTransaction).IsRequired();
            builder.Property(b => b.AmountTransaction).IsRequired();
        }
    }
}
