using FluentValidation;
using MovieStore.Business.Operations.MovieOperations.Command.DeleteMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Movie
{
    public class DeleteMovieCommandValidation:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidation()
        {
            RuleFor(x => x.MovieId).NotEmpty();
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
