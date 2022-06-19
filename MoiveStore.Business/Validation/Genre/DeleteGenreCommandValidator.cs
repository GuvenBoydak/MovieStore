using FluentValidation;
using MovieStore.Business.Operations.GenreOperations.Command.DeleteGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Genre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty();
            RuleFor(x => x.GenreId).GreaterThan(0);
        }
    }
}
