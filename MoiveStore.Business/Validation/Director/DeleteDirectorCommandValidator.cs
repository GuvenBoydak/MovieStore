using FluentValidation;
using MovieStore.Business.Operations.DirectorOperations.Command.DeleteDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Director
{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x => x.DirectorId).NotEmpty();
            RuleFor(x => x.DirectorId).GreaterThan(0); ;
        }
    }
}
