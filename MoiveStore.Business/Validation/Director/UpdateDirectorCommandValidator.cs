using FluentValidation;
using MovieStore.Business.Operations.DirectorOperations.Command.UpdateDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Director
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.Surname).NotEmpty();
            RuleFor(x => x.DirectorId).NotEmpty();
            RuleFor(x => x.DirectorId).GreaterThan(0);
        }
    }
}
