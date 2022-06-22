using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.DirectorOperations.Query.GetDetailDirector;
using MovieStore.DataAccess.Context;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Query.GetDetailDirector
{
    public class GetDetailDirectorQueryTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailDirectorQueryTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidDirectorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            GetDetailDirectorQuery query = new GetDetailDirectorQuery(_db, _mapper);
            query.DirectorId = 5;

            FluentActions
               .Invoking(() => query.Handler()).Should().Throw<InvalidOperationException>()
               .And.Message.Should().Be("Yönetmen bulunamadı");
        }

        public void WhenValidDirectorIdIsGiven_InvalidOperationException_ShouldNotBeReturnError()
        {
            GetDetailDirectorQuery query = new GetDetailDirectorQuery(_db, _mapper);
            query.DirectorId = 1;

            FluentActions
               .Invoking(() => query.Handler()).Invoke();
        }
    }
}
