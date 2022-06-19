using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.MovieOperations.Command.DeleteMovie;
using MovieStore.DataAccess.Context;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.Movie.Command.DeleteMovie
{
    public class DeleteMovieCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public DeleteMovieCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void WhenTheMovieToDeleteIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int movieId = 5;

            DeleteMovieCommand command = new DeleteMovieCommand(_db);
            command.MovieId = movieId;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeDeleted()
        {
            int movieId = 1;
            DeleteMovieCommand command = new DeleteMovieCommand(_db);
            command.MovieId=movieId;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Entities.Entities.Movie movie = _db.Movies.SingleOrDefault(x => x.Id == movieId);

            movie.Should().Be(null);
        }
    }
}
