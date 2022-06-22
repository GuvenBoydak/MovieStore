
using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.DirectorOperations.Command.UpdateDirector;
using MovieStore.Business.Validation.Director;
using MovieStore.Entities.ViewModel.DirectorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Command.UpdateDirector
{
    public class UpdateDirectorCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","",0)]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name,string surname,int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.DirectorId = id;
            command.Model = new UpdateDirectorViewModel() { Name = name, Surname = surname };

            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("test", "test", 2)]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(string name, string surname, int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(null);
            command.DirectorId = id;
            command.Model = new UpdateDirectorViewModel() { Name = name, Surname = surname };

            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}
