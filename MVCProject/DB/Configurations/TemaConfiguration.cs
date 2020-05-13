using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class TemaConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Tema");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Categoria)
                /*.WithMany(o => o.Temas)*/
                .WithMany()
                .HasForeignKey(o => o.CategoriaId);


            //builder.HasMany(o => o.Preguntas)
            //  .WithOne(o => o.Tema)
            //  .HasForeignKey(o => o.TemaId);
        }
    }
}
