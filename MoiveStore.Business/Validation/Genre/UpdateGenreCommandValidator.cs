using FluentValidation;
using MovieStore.Business.Operations.GenreOperations.Command.UpdateGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Genre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.GenreId).NotEmpty();
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
