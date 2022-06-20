using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.ActorOperations.Command.CreateActor;
using MovieStore.Business.Validation.Actor;
using MovieStore.Entities.ViewModel.ActorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Command.CreateActor
{
    public class CreateActorCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","")]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name,string surname)
        {
            CreateActorCommand command = new CreateActorCommand(null,null);
            command.Model = new CreateActorViewModel() { Name = name, Surname = surname };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {

            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorViewModel() { Name = "test", Surname = "test" };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
