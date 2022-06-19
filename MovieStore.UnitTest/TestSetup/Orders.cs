using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDb db)
        {
            db.Orders.AddRange(new Order() { CustomerId = 1, MovieId = 1, OrderDate = DateTime.Now, Price = 100 },
                    new Order() { CustomerId = 2, MovieId = 2, OrderDate = DateTime.Now, Price = 120 },
                    new Order() { CustomerId = 3, MovieId = 3, OrderDate = DateTime.Now, Price = 70 });
        }
    }
}
