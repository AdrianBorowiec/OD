using OD.Models;
using System.Data.Entity.ModelConfiguration;

namespace OD.Domain.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");

            Property(x => x.Id).IsRequired();
            Property(x => x.Nickname).IsRequired();
            Property(x => x.Nickname).HasMaxLength(30);
            Property(x => x.Password).IsRequired();
            Property(x => x.FirstName).IsRequired();
            Property(x => x.FirstName).HasMaxLength(50);
            Property(x => x.LastName).IsRequired();
            Property(x => x.LastName).HasMaxLength(50);
        }
    }
}
