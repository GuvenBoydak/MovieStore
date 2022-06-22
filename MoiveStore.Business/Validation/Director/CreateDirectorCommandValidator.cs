using FluentValidation;
using MovieStore.Business.Operations.DirectorOperations.Command.CreateDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Director
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.Surname).NotEmpty();
        }
    }
}
