using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDb db)
        {
            db.Actors.AddRange(new Actor() { Name = " Bradley", Surname = "Cooper" }, new Actor() { Name = "Oscar", Surname = "Isaac" }, new Actor() { Name = "Jon Davit", Surname = "Washington" });
        }
    }
}
