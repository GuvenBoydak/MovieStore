using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.MovieOperations.Query.GetDetailMovie;
using MovieStore.DataAccess.Context;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.Movie.Query.GetDetailMovie
{
    public class GetDetailMovieQueryTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailMovieQueryTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidMovieIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            int movieId = 0;

            GetDetailMovieQuery query = new GetDetailMovieQuery(_db, _mapper);
            query.MovieId = movieId;

            FluentActions.Invoking(() => query.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Film Bulunamadı");
        }

        [Fact]
        public void WhenValidMovieIdIsGiven_InvalidOperationException_ShouldNotBeReturnError()
        {

            int movieId = 1;

            GetDetailMovieQuery query = new GetDetailMovieQuery(_db, _mapper);
            query.MovieId = movieId;

            FluentActions.Invoking(() => query.Handler()).Invoke();

        }


    }
}
