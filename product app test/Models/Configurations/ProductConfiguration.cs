using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_app_test.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(col => col.item_id);

            builder.Property(col => col.item_name)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(col => col.item_dec)
                    .IsRequired()
                    .HasMaxLength(2500);

            builder.Property(col => col.item_img)
                    .IsRequired();

            builder.Property(col => col.ctg_id)
                    .IsRequired();


        }
    }
}
