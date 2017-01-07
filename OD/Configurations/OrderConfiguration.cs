using OD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OD.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Orders");

            Property(x => x.Id).IsRequired();
            HasRequired(x => x.Customer).WithMany(x => x.Orders);
            Property(x => x.OrderStatus).IsRequired();
            Property(x => x.OrderCreateDT).IsRequired();
        }
    }
}