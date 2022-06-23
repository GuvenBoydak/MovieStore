using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Core.Entities;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Context
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider provider)
        {
            using (var context = new MovieStoreDb(provider.GetRequiredService<DbContextOptions<MovieStoreDb>>()))
            {
                context.Movies.AddRange(new Movie() { Name = "Tenet", Year = 2020, Price = 100, GenreId = 1, DirectorId = 1, },
                    new Movie() { Name = "Dune", Year = 2021, Price = 120, GenreId = 2, DirectorId = 2 },
                     new Movie() { Name = "Hangover", Year = 2009, Price = 70, GenreId = 3, DirectorId = 3 });

                context.Genres.AddRange(new Genre() { Name = "Aksiyon" }, new Genre() { Name = "Macerea" }, new Genre() { Name = "Komedi" });

                context.Actors.AddRange(new Actor() { Name = " Bradley", Surname = "Cooper" }, new Actor() { Name = "Oscar", Surname = "Isaac" }, new Actor() { Name = "Jon Davit", Surname = "Washington"});

                context.Directors.AddRange(new Director() { Name="Christoper",Surname="Nolan"}, new Director() { Name = "Dennis", Surname = "Villeneuve" }, new Director() { Name = "Todd", Surname = "Philips" });

                context.Customers.AddRange(new Customer() { Name = "Güven", Surname = "Boydak", Email = "gvn.boydak@gmail.com", Password = "12345",CreatedDate=DateTime.Now },
                    new Customer() { Name = "Aylin", Surname = "Boydak", Email = "aylinboydak@gmail.com", Password = "12345", CreatedDate = DateTime.Now },
                    new Customer() { Name = "Ali", Surname = "Boydak", Email = "aliboydak@gmail.com", Password = "12345", CreatedDate = DateTime.Now });

                context.Orders.AddRange(new Order() { CustomerId = 1, MovieId = 1, OrderDate = DateTime.Now, Price = 100, IsActive = true },
                    new Order() { CustomerId = 2, MovieId = 2, OrderDate = DateTime.Now, Price = 120,IsActive=true },
                    new Order() { CustomerId = 3, MovieId = 3, OrderDate = DateTime.Now, Price = 70, IsActive = true });

                context.CustomerGenres.AddRange(new CustomerGenre() { CustomerId = 1, GenreId = 1 },
                    new CustomerGenre() { CustomerId = 1, GenreId = 2 },
                    new CustomerGenre() { CustomerId = 2, GenreId = 1 },
                    new CustomerGenre() { CustomerId = 3, GenreId = 1 });

                context.MovieActors.AddRange(new MovieActor() {ActorId=1,MovieId=3 }, new MovieActor() { ActorId = 2, MovieId = 2 }, new MovieActor() { ActorId = 3, MovieId = 1 });
              
                context.SaveChanges();
            }
        }
    }
}
