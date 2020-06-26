using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class ExamenPreguntaConfiguration : IEntityTypeConfiguration<ExamenPregunta>
    {
        public void Configure(EntityTypeBuilder<ExamenPregunta> builder)
        {
            builder.ToTable("ExamenPregunta");
            builder.HasKey(o => o.Id);
        }
    }
}
