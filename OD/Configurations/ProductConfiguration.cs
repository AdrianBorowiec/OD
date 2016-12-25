using OD.Models;
using System.Data.Entity.ModelConfiguration;

namespace OD.Domain.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");

            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.Price).IsRequired();
            HasRequired(x => x.Producer).WithMany();
        }
    }
}
