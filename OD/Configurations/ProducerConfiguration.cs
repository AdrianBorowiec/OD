using OD.Models;
using System.Data.Entity.ModelConfiguration;

namespace OD.Domain.Configurations
{
    public class ProducerConfiguration : EntityTypeConfiguration<Producer>
    {
        public ProducerConfiguration()
        {
            ToTable("Producers");

            Property(x => x.Id).IsRequired();
            Property(x => x.Name).IsRequired();
            Property(x => x.ApartmentNumber).IsRequired();
            Property(x => x.ApartmentNumber).HasMaxLength(15);
            Property(x => x.Street).IsRequired();
            Property(x => x.Street).HasMaxLength(50);
            Property(x => x.City).IsRequired();
            Property(x => x.City).HasMaxLength(50);
            Property(x => x.Country).IsRequired();
            Property(x => x.Country).HasMaxLength(50);
            Property(x => x.PhoneNumber).IsRequired();
            Property(x => x.PhoneNumber).HasMaxLength(30);
        }
    }
}
