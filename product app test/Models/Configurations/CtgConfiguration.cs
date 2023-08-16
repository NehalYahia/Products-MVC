using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using product_app_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_app_test.Controllers.Configurations
{
    public class CtgConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(col => col.ctg_id);
            builder.Property(col => col.ctg_name)
                    .IsRequired()
                    .HasMaxLength(200);
                    
    }
    }
}
