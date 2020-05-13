using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class AlternativaConfiguration : IEntityTypeConfiguration<Alternativa>
    {
        public void Configure(EntityTypeBuilder<Alternativa> builder)
        {
            builder.ToTable("Alternativa");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Pregunta)
                .WithMany(o => o.Alternativas)
                .HasForeignKey(o => o.PreguntaId);
        }
    }
}
