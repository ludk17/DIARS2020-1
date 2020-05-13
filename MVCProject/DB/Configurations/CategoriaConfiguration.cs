using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {

        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(o => o.Id);

            //builder.HasMany(o => o.Temas)
            //    .WithOne(o => o.Categoria)
            //    .HasForeignKey(o => o.CategoriaId);
        }
    }
}
