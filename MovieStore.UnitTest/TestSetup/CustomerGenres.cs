using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class CustomerGenres
    {
        public static void AddCustomerGenres(this MovieStoreDb db)
        {
            db.CustomerGenres.AddRange(new CustomerGenre() { CustomerId = 1, GenreId = 1 },
                  new CustomerGenre() { CustomerId = 1, GenreId = 2 },
                  new CustomerGenre() { CustomerId = 2, GenreId = 1 },
                  new CustomerGenre() { CustomerId = 3, GenreId = 1 });
        }
    }
}
