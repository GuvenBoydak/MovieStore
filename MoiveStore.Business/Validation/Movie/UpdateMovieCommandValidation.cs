using FluentValidation;
using MovieStore.Business.Operations.MovieOperations.Command.UpdateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Movie
{
    public class UpdateMovieCommandValidation:AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidation()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.Price).NotEmpty();
            RuleFor(x => x.Model.Year).NotEmpty();
            RuleFor(x => x.Model.GenreId).NotEmpty();
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.DirectorId).NotEmpty();
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
        }
    }
}
