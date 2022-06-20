using FluentAssertions;
using MovieStore.Business.Operations.ActorOperations.Command.UpdateActor;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Command.UpdateActor
{
    public class UpdateActorCommandTest:IClassFixture<CommonTestFixture>
    {

        private readonly MovieStoreDb _db;

        public UpdateActorCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
        }

        [Fact]
        public void WhenTheActorToUpdateIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int actorId = 5;

            UpdateActorCommand command = new UpdateActorCommand(_db);
            command.ActorId = actorId;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Oyuncu Bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeUpdated()
        {
            int actorId = 1;

            UpdateActorCommand command = new UpdateActorCommand(_db);
            command.ActorId = actorId;
            UpdateActorViewModel vm = new UpdateActorViewModel()
            {
                Name = "test",
                Surname = "test"
            };
            command.Model = vm;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Actor actor = _db.Actors.SingleOrDefault(x=>x.Id==actorId);

            actor.Should().NotBeNull();
            actor.Name.Should().Be(vm.Name);
            actor.Surname.Should().Be(vm.Surname);
        }
    }
}
