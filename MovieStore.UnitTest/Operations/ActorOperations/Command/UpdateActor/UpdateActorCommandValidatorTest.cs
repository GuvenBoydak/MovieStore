using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.ActorOperations.Command.UpdateActor;
using MovieStore.Business.Validation.Actor;
using MovieStore.Entities.ViewModel.ActorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Command.UpdateActor
{
    public class UpdateActorCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name,string surname)
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Model = new UpdateActorViewModel() { Name = name, Surname = surname };

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            ValidationResult result=validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateActorCommand command = new UpdateActorCommand(null);
            command.Model = new UpdateActorViewModel() { Name = "test", Surname = "test" };

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
