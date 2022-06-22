using FluentAssertions;
using MovieStore.Business.Operations.DirectorOperations.Command.UpdateDirector;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Command.UpdateDirector
{
    public class UpdateDirectorCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;

        public UpdateDirectorCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
        }


        [Fact]
        public void WhenTheDirectorToUpdateIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int id = 5;
            UpdateDirectorCommand command = new UpdateDirectorCommand(_db);
            command.DirectorId = id;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen Bulunamdı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeUpdated()
        {
            int id = 1;
            UpdateDirectorCommand command = new UpdateDirectorCommand(_db);
            UpdateDirectorViewModel vm = new UpdateDirectorViewModel()
            {
                Name = "test",
                Surname = "test"
            };
            command.Model = vm;
            command.DirectorId = id;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Director director = _db.Directors.SingleOrDefault(x=>x.Id==id);

            director.Should().NotBeNull();
            director.Name.Should().Be(vm.Name);
            director.Surname.Should().Be(vm.Surname);

        }

    }
}
