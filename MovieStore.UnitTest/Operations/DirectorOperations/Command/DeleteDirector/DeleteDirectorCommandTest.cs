using FluentAssertions;
using MovieStore.Business.Operations.DirectorOperations.Command.DeleteDirector;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.Entities;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Command.DeleteDirector
{
    public class DeleteDirectorCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDb _db;

        public DeleteDirectorCommandTest(CommonTestFixture testFixture)
        {
            _db = testFixture.Db;
        }


        [Fact]
        public void WhenTheDirectorToDeleteIsNotFound_InvalidOperationException_ShoudBeReturn()
        {
            int directorId = 5;
            DeleteDirectorCommand command = new DeleteDirectorCommand(_db);
            command.DirectorId=directorId;

            FluentActions.Invoking(() => command.Handler()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yönetmen bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeDeleted()
        {
            int directorId = 1;
            DeleteDirectorCommand command = new DeleteDirectorCommand(_db);
            command.DirectorId = directorId;

            FluentActions.Invoking(() => command.Handler()).Invoke();

            Director director = _db.Directors.SingleOrDefault(x=>x.Id==directorId);

            director.Should().Be(null);
        }
    }
}
