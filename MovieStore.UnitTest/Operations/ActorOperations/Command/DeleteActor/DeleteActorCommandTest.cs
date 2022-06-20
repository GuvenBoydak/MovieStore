using FluentAssertions;
using MovieStore.Business.Operations.ActorOperations.Command.DeleteActor;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Command.DeleteActor
{
    public class DeleteActorCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        public DeleteActorCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
        }


        [Fact]
        public void WhenTheActorToDeleteIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int actorId = 5;

            DeleteActorCommand command = new DeleteActorCommand(_db);
            command.ActorId = actorId;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu Bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeDeleted()
        {
            int actorId = 1;

            DeleteActorCommand command = new DeleteActorCommand(_db);
            command.ActorId = actorId;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Actor actor=_db.Actors.SingleOrDefault(x => x.Id == actorId);

            actor.Should().Be(null);
        }
    }
}
