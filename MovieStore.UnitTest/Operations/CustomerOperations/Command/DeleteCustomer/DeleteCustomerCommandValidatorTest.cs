using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.CustomerOperations.Command.DeleteCustomer;
using MovieStore.Business.Validation.Customer;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.CustomerOperations.Command.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null);
            command.CustomerId = id;


            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            int customerId = 1;
            DeleteCustomerCommand command = new DeleteCustomerCommand(null);
            command.CustomerId = customerId;


            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
