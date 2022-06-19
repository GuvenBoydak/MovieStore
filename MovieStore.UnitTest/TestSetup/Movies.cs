using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class Movies
    {
        public static void AddMovie(this MovieStoreDb db)
        {
            db.Movies.AddRange(new Movie() { Name = "Tenet", Year = 2020, Price = 100, GenreId = 1, DirectorId = 1, },
                     new Movie() { Name = "Dune", Year = 2021, Price = 120, GenreId = 2, DirectorId = 2 },
                      new Movie() { Name = "Hangover", Year = 2009, Price = 70, GenreId = 3, DirectorId = 3 });
        }
    }
}
