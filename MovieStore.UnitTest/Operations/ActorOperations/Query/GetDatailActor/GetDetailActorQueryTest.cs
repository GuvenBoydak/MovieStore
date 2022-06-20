using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.ActorOperations.Query.GetDetailActor;
using MovieStore.DataAccess.Context;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Query.GetDatailActor
{
    public class GetDetailActorQueryTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public GetDetailActorQueryTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidActorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            int actorID = 5;
            GetDetailActorQuery query = new GetDetailActorQuery(_db,_mapper);
            query.ActorId = actorID;

            FluentActions.Invoking(() => query.Handlerr()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu Bulunamdı");
        }

        [Fact]
        public void WhenValidActorIdIsGiven_InvalidOperationException_ShouldNotBeReturnError()
        {
            int actorId = 1;
            GetDetailActorQuery query = new GetDetailActorQuery(_db,_mapper);
            query.ActorId = actorId;

            FluentActions.Invoking(() => query.Handlerr()).Invoke();
        }
    }
}
