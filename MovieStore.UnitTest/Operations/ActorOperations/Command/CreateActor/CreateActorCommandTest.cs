using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.ActorOperations.Command.CreateActor;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.ActorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Command.CreateActor
{
    public class CreateActorCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateActorCommandTest( CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorNameAndSurnameIsGiven_InvalidOperationException_ShoudBeReturn()
        {
            Actor actor = new Actor()
            {
                Name = "test",
                Surname = "test"
            };
            _db.Actors.Add(actor);
            _db.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_db,_mapper);
            command.Model = new CreateActorViewModel() { Name = actor.Name, Surname = actor.Surname };

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu isim ve soyisimli Oyuncu mevcut");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeCreated()
        {
            CreateActorCommand command = new CreateActorCommand(_db,_mapper);
            CreateActorViewModel vm=new CreateActorViewModel() { Name="test",Surname="test"};
            command.Model = vm;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Actor actor = _db.Actors.SingleOrDefault(x => x.Name + x.Surname == vm.Name + vm.Surname);

            actor.Should().NotBeNull();
            actor.Name.Should().Be(vm.Name);
            actor.Surname.Should().Be(vm.Surname);

        }

    }
}
