using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDb db)
        {
            db.Genres.AddRange(new Genre() { Name = "Aksiyon" }, new Genre() { Name = "Macerea" }, new Genre() { Name = "Komedi" });
        }
    }
}
