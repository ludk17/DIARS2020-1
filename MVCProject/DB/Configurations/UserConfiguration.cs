using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.DB.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //public UserConfiguration()
        //{
        //    ToTable("User");
        //    HasKey(o => o.Id);
        //}

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(o => o.Id);

            //builder.Property(o => o.Username).HasColumnName("Username");
        }
    }
}
