using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.ActorOperations.Command.DeleteActor;
using MovieStore.Business.Validation.Actor;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Command.DeleteActor
{
    public class DeleteActorCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors()
        {
            int actorId = 0;
            DeleteActorCommand command = new DeleteActorCommand(null);
            command.ActorId = actorId;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            ValidationResult result= validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            int actorId = 1;
            DeleteActorCommand command = new DeleteActorCommand(null);
            command.ActorId = actorId;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
