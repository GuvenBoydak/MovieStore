using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.DirectorOperations.Query.GetDetailDirector;
using MovieStore.Business.Validation.Director;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.DirectorOperations.Query.GetDetailDirector
{
    public class GetDetailDirectorQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors()
        {
            int id = 0;

            GetDetailDirectorQuery query = new GetDetailDirectorQuery(null,null);
            query.DirectorId = id;

            GetDetailDirectorQueryValidator validator = new GetDetailDirectorQueryValidator();
            ValidationResult result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            int id = 1;

            GetDetailDirectorQuery query = new GetDetailDirectorQuery(null,null);
            query.DirectorId = id;

            GetDetailDirectorQueryValidator validator = new GetDetailDirectorQueryValidator();
            ValidationResult result=validator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }

    }
}
