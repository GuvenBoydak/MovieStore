using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.OrderOpertation.Command.DeleteOrder;
using MovieStore.Business.Validation.Order;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.OrderOperations.Command.DeleteOrder
{
    public class DeleteOrderCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors()
        {
            DeleteOrderCommand command = new DeleteOrderCommand(null);
            command.OrderId = 0;

            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            ValidationResult result=validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {

            DeleteOrderCommand command = new DeleteOrderCommand(null);
            command.OrderId = 1;

            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}
