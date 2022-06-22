using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.DirectorOperations.Command.CreateDirector;
using MovieStore.Business.Validation.Director;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Command.CreateDirector
{
    public class CreateDirectorCommandValidatorTest:IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("", "")]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name, string surname)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null,null);
            command.Model=new CreateDirectorViewModel() { Name=name,Surname=surname};

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            ValidationResult result= validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorViewModel() { Name = "test", Surname = "test" };

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
