using FluentValidation;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Customer
{
    public class CreateTokenCommandValidator:AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(x => x.Model.Email).NotEmpty();
            RuleFor(x => x.Model.Email).EmailAddress();
            RuleFor(x => x.Model.Password).NotEmpty();
            RuleFor(x => x.Model.Password).MinimumLength(4);
        }
    }
}
