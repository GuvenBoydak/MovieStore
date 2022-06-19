using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.MovieOperations.Command.DeleteMovie;
using MovieStore.Business.Validation.Movie;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.Movie.Command.DeleteMovie
{
    public class DeleteMovieCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors()
        {
            int movieId = 0;

            DeleteMovieCommand command = new DeleteMovieCommand(null);
            command.MovieId = movieId;

            DeleteMovieCommandValidation validator = new DeleteMovieCommandValidation();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {

            int movieId = 2;

            DeleteMovieCommand command = new DeleteMovieCommand(null);
            command.MovieId = movieId;

            DeleteMovieCommandValidation validator = new DeleteMovieCommandValidation();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
