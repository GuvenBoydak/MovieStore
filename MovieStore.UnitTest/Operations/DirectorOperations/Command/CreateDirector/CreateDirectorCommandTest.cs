using AutoMapper;
using FluentAssertions;
using MovieStore.Business.Operations.DirectorOperations.Command.CreateDirector;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Command.CreateDirector
{
    public class CreateDirectorCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTest( CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistDirectorNameAndSurnameIsGiven_InvalidOperationException_ShoudBeReturn()
        {
            Director director = new Director() { Name = "test", Surname = "test" };
            _db.Directors.Add(director);
            _db.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_db,_mapper);
            command.Model = new CreateDirectorViewModel() { Name = director.Name, Surname = director.Surname };

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu İsim Soyisimli Yönetmen Mevcut");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeCreated()
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_db, _mapper);
            CreateDirectorViewModel vm = new CreateDirectorViewModel() { Name = "test",Surname="test"};

            command.Model = vm;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Director director = _db.Directors.SingleOrDefault(x=>x.Name + x.Surname == vm.Name + vm.Surname);

            director.Should().NotBeNull();
            director.Name.Should().Be(vm.Name);
            director.Surname.Should().Be(vm.Surname);
        }
    }
}
