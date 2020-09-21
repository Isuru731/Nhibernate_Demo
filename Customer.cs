using System;
using System.Collections.Generic;
using System.Text;

namespace NhibernateDemo
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
    }
}
