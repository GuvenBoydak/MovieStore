using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.DirectorOperations.Command.DeleteDirector;
using MovieStore.Business.Validation.Director;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Command.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTest:IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors()
        {
            int id = 0;
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.DirectorId = id;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            int id = 1;
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.DirectorId = id;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
