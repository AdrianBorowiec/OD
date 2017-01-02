using OD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OD.Configurations
{
    public class OrderDetailsConfiguration : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsConfiguration()
        {
            ToTable("OrderDetails");

            Property(x => x.Id).IsRequired();
            HasRequired(x => x.Order).WithMany(x => x.OrderDetails);
            HasRequired(x => x.Product).WithMany();
            Property(x => x.Quantity).IsRequired();
            Property(x => x.UnitPrice).IsRequired();
        }
    }
}