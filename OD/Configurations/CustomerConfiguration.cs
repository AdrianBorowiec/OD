using OD.Models;
using System.Data.Entity.ModelConfiguration;

namespace OD.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");

            Property(x => x.Id).IsRequired();
            Property(x => x.Nickname).IsRequired();
            Property(x => x.Nickname).HasMaxLength(25);
            Property(x => x.Password).IsRequired();
        }
    }
}
