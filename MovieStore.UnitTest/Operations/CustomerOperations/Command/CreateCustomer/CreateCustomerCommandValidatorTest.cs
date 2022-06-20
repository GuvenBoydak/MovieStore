using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateCustomer;
using MovieStore.Business.Validation.Customer;
using MovieStore.Entities.ViewModel.CustomerViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.CustomerOperations.Command.CreateCustomer
{
    public class CreateCustomerCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","","","1234")]
        [InlineData("","","testtest","")]
        [InlineData("","","","")]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name,string surname,string email,string password)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null,null);
            command.Model = new CreateCustomerViewModel() { Name = name, Surname = surname, Email = email, Password = password };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerViewModel() {
                Name = "test", Surname = "test", Email = "test@gmail.com", Password = "12345" };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

    }
}
