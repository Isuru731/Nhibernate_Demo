using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhibernateDemo
{
    public class CustomerMapping : ClassMap<Customer>
    {
        public CustomerMapping()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Email);
        }
    }
}
