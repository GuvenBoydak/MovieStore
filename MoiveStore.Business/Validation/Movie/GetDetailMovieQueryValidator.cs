using FluentValidation;
using MovieStore.Business.Operations.MovieOperations.Query.GetDetailMovie;
using MovieStore.Business.Operations.MovieOperations.Query.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Movie
{
    public class GetDetailMovieQueryValidator:AbstractValidator<GetDetailMovieQuery>
    {
        public GetDetailMovieQueryValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.MovieId).GreaterThan(0);
            
        }
    }
}
