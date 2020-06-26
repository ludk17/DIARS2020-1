using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
    {
        //public UserConfiguration()
        //{
        //    ToTable("User");
        //    HasKey(o => o.Id);
        //}

        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.ToTable("Pelicula");
            builder.HasKey(o => o.Id);

            //builder.Property(o => o.Username).HasColumnName("Username");
        }
    }
}
