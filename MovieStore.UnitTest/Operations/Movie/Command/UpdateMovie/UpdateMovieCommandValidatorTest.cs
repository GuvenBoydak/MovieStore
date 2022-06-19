using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.MovieOperations.Command.UpdateMovie;
using MovieStore.Business.Validation.Movie;
using MovieStore.Entities.ViewModel.MovieViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.Movie.Command.UpdateMovie
{
    public class UpdateMovieCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
        public object UpdateMovieCommandValidator { get; private set; }

        [Theory]
        [InlineData("", 1, 1, 1, 1)]
        [InlineData("", 0, 0, 0, 1)]
        [InlineData("test", 0, 0, 0, 0)]
        [InlineData("", 0, 0, 1, 1)]
        [InlineData("", 0, 1, 1, 1)]
        [InlineData("", 1, 0, 0, 1)]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name, int year, decimal price, int genreId, int directorId)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Model = new UpdateMovieViewModel()
            {
                Name = name,
                Price = price,
                Year = year,
                GenreId = genreId,
                DirectorId = directorId
            };

            UpdateMovieCommandValidation validator = new UpdateMovieCommandValidation();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.Model = new UpdateMovieViewModel()
            {
                Name = "test",
                Price = 100,
                Year = 2000,
                GenreId = 1,
                DirectorId = 1
            };

            UpdateMovieCommandValidation validator = new UpdateMovieCommandValidation();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
