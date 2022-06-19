using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDb db)
        {
            db.Customers.AddRange(new Customer() { Name = "Güven", Surname = "Boydak", Email = "gvn.boydak@gmail.com", Password = "12345" },
                    new Customer() { Name = "Aylin", Surname = "Boydak", Email = "aylinboydak@gmail.com", Password = "12345" },
                    new Customer() { Name = "Ali", Surname = "Boydak", Email = "aliboydak@gmail.com", Password = "12345" });
        }
    }
}
