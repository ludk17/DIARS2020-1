using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class ExamenConfiguration : IEntityTypeConfiguration<Examen>
    {
        public void Configure(EntityTypeBuilder<Examen> builder)
        {
            builder.ToTable("Examen");
            builder.HasKey(o => o.Id);
        }
    }
}
