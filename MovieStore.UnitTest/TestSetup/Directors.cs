using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDb db)
        {
            db.Directors.AddRange(new Director() { Name = "Christoper", Surname = "Nolan" }, new Director() { Name = "Dennis", Surname = "Villeneuve" }, new Director() { Name = "Todd", Surname = "Philips" });
        }
    }
}
