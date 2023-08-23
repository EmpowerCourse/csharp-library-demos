using FluentNHibernate.Mapping;
using NHibernateDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemo.Mappings;

public class CustomerMap : ClassMap<Customer>
{
    public CustomerMap() 
    {
        Id(x => x.Id);
        Map(x => x.Name);
        Table("Customers");
    }
}
