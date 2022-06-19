using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class MovieActors
    {
        public static void AddMovieActors(this MovieStoreDb db)
        {
            db.MovieActors.AddRange(new MovieActor() { ActorId = 1, MovieId = 3 }, new MovieActor() { ActorId = 2, MovieId = 2 }, new MovieActor() { ActorId = 3, MovieId = 1 });
        }
    }
}
