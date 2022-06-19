using AutoMapper;
using MovieStore.DataAccess.Context;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Entities.Entities;
using MovieStore.Business.Operations.MovieOperations.Command.CreateMovie;
using MovieStore.Entities.ViewModel.MovieViewModel;
using FluentAssertions;

namespace MovieStore.UnitTest.Operations.Movie.Command.CreateMovie
{
    public class CreateMovieCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateMovieCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenAlreadyExistMovieNameIsGiven_InvalidOperationException_ShoudBeReturn()
        {
            Entities.Entities.Movie movie = new Entities.Entities.Movie()
            {
                Name = "test",
                Price = 100,
                Year = 2000,
                CreatedDate = DateTime.Now,
                GenreId = 1,
                DirectorId = 1
            };

            _db.Movies.Add(movie);
            _db.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_db,_mapper);
            command.Model = new CreateMovieViewModel()
            {
                Name = movie.Name,
            };

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Film mevcut");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            CreateMovieCommand command = new CreateMovieCommand(_db, _mapper);
            CreateMovieViewModel model = new CreateMovieViewModel()
            {
                Name = "test",
                Price = 100,
                Year=200,
                GenreId = 1,
                DirectorId = 1
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Entities.Entities.Movie movie = _db.Movies.SingleOrDefault(x=>x.Name==model.Name);

            movie.Should().NotBeNull();
            movie.Name.Should().Be(model.Name);
            movie.Price.Should().Be(model.Price);
            movie.Year.Should().Be(model.Year);
            movie.GenreId.Should().Be(model.GenreId);
            movie.DirectorId.Should().Be(model.DirectorId);
        }
    }
}
