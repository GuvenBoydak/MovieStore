using Microsoft.EntityFrameworkCore;
using MovieStore.Core.Entities;
using MovieStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.Abstract
{
    public interface IMovieStoreDb
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerGenre> CustomerGenres { get; set; }
        DbSet<MovieActor> MovieActors { get; set; }

        int SaveChanges();


    }
}
