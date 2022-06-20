using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.MovieOperations.Command.UpdateMovie;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.ViewModel.MovieViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.MovieOperations.Command.UpdateMovie
{
    public class UpdateMovieCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public UpdateMovieCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenTheMovieToUpdateIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int movieId = 5;

            UpdateMovieCommand command = new UpdateMovieCommand(_db);
            command.MovieId = movieId;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeUpdated()
        {
            int movieId = 1;

            UpdateMovieCommand command = new UpdateMovieCommand(_db);
            command.MovieId = movieId;
            UpdateMovieViewModel model = new UpdateMovieViewModel()
            {
                Name = "test",
                Price = 100,
                Year = 2000,
                GenreId = 1,
                DirectorId = 1
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Entities.Entities.Movie movie = _db.Movies.SingleOrDefault(x=>x.Id==movieId);

            movie.Should().NotBeNull();
            movie.Name.Should().Be(model.Name);
            movie.Price.Should().Be(model.Price);
            movie.Year.Should().Be(model.Year);
            movie.GenreId.Should().Be(model.GenreId);
            movie.DirectorId.Should().Be(model.DirectorId);

        }
    }
}
