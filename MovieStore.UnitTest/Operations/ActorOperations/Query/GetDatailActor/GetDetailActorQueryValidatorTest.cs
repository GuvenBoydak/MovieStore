using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.ActorOperations.Query.GetDetailActor;
using MovieStore.Business.Validation.Actor;
using MovieStore.Entities.ViewModel.ActorViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.ActorOperations.Query.GetDatailActor
{
    public class GetDetailActorQueryValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("","",0)]
        [InlineData("","",-2)]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name,string surname,int id)
        {
            GetDetailActorQuery query = new GetDetailActorQuery(null,null);
            query.ActorId = id;
            query.Model = new GetDetailActorViewModel() { Name = name, Surname = surname };

            GetDetailActorQueryValidator valiator = new GetDetailActorQueryValidator();
            ValidationResult result = valiator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            GetDetailActorQuery query = new GetDetailActorQuery(null, null);
            query.ActorId = 1;
            query.Model = new GetDetailActorViewModel() { Name = "test", Surname = "test"};

            GetDetailActorQueryValidator valiator = new GetDetailActorQueryValidator();
            ValidationResult result = valiator.Validate(query);

            result.Errors.Count.Should().Be(0);
        }
    }
}
