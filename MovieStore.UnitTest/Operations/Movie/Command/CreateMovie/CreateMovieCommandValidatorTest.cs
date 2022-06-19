using AutoMapper;
using FluentAssertions;
using FluentValidation.Results;
using MovieStore.Business.Operations.MovieOperations.Command.CreateMovie;
using MovieStore.Business.Validation.Movie;
using MovieStore.DataAccess.Context;
using MovieStore.Entities.ViewModel.MovieViewModel;
using MovieStore.UnitTest.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.UnitTest.Operations.Movie.Command.CreateMovie
{
    public class CreateMovieCommandValidatorTest:IClassFixture<CommonTestFixture>
    {
    

        [Theory]
        [InlineData("",1,1,1,1)]
        [InlineData("",0,0,0,1)]
        [InlineData("test",0,0,0,0)]
        [InlineData("",0,0,1,1)]
        [InlineData("",0,1,1,1)]
        [InlineData("",1,0,0,1)]
        public void WhenInvalidInputsAreGiven_Validator_SouldBeReturnErrors(string name, int year, decimal price,int genreId,int directorId)
        {
            CreateMovieCommand command = new CreateMovieCommand(null,null);
            command.Model = new CreateMovieViewModel()
            {
                Name = name,
                Price = price,
                Year = year,
                GenreId = genreId,
                DirectorId = directorId
            };

            CreateMovieCommandValidation validator = new CreateMovieCommandValidation();
            ValidationResult result= validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieViewModel()
            {
                Name = "test",
                Price = 100,
                Year = 2000,
                GenreId = 1,
                DirectorId = 1
            };

            CreateMovieCommandValidation validator = new CreateMovieCommandValidation();
            ValidationResult result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
