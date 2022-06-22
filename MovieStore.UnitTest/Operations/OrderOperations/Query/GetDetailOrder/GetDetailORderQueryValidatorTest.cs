using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.OrderOpertation.Query.GetDetailOrder;
using MovieStore.Business.Validation.Order;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.OrderOperations.Query.GetDetailOrder
{
    public class GetDetailORderQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors() 
        {
            GetDetailOrderQuery query = new GetDetailOrderQuery(null,null);
            query.Id = 0;

            GetDetailOrderQueryValidator validator = new GetDetailOrderQueryValidator();
            ValidationResult result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            GetDetailOrderQuery query = new GetDetailOrderQuery(null, null);
            query.Id = 1;

            GetDetailOrderQueryValidator validator = new GetDetailOrderQueryValidator();
            ValidationResult result = validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }
    }
}
