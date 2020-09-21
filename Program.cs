using NHibernate;
using System;
using System.Linq;


namespace NhibernateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DisplayAllCustomers();

            //Add new Customer
            AddNewCustomer();
            Console.WriteLine("After adding new customer..");
            DisplayAllCustomers();

            Console.WriteLine("Press Enter to exit..");
            Console.ReadLine();
        }

        static void AddNewCustomer()
        {
            Customer cus = new Customer()
            {
                Name = "New Customer",
                Email = "n.customer@abc.com"
            };

            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    session.Save(cus);
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }
        static void DisplayAllCustomers()
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    var customers = from customer in session.Query<Customer>()
                                    select customer;

                    foreach (var f in customers)
                    {
                        Console.WriteLine("{0} {1} {2}", f.Id, f.Name, f.Email);
                    }
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }
    }
}
