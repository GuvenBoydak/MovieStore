using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.OrderOpertation.Command.CreateOrder;
using MovieStore.Business.Validation.Order;
using MovieStore.Entities.ViewModel.OrderViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.OrderOperations.Command.CreateOrder
{
    public class CreateOrderCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors()
        {
            CreateOrderCommand command = new CreateOrderCommand(null,null);
            command.Model = new CreateOrderViewModel() { CustomerId = 0, MovieId = 0,Price=0 };

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateOrderCommand command = new CreateOrderCommand(null, null);
            command.Model = new CreateOrderViewModel() { CustomerId = 1, MovieId = 1, Price = 100 };

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}
