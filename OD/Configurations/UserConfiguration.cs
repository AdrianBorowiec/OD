using OD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OD.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");

            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.Password).IsRequired();
            Property(x => x.Email).IsOptional();
        }
    }
}