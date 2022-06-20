using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Business.AutoMapper;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDb Db { get; set; }

        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDb>().UseInMemoryDatabase(databaseName: "MovieStoreDb").Options;

            Db = new MovieStoreDb(options);
            Db.Database.EnsureCreated();
            Db.AddActors();
            Db.AddCustomerGenres();
            Db.AddMovie();
            Db.AddMovieActors();
            Db.AddOrders();
            Db.AddGenres();
            Db.AddDirectors();
            Db.AddCustomers();
            Db.SaveChanges();

            Mapper=new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

            
        }
    }
}
