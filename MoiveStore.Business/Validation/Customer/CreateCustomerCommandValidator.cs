using FluentValidation;
using MovieStore.Business.Operations.CustomerOperations.Command.CreateCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Customer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.Surname).NotEmpty();
            RuleFor(x => x.Model.Email).NotEmpty();
            RuleFor(x => x.Model.Email).EmailAddress();
            RuleFor(x => x.Model.Password).NotEmpty();
            RuleFor(x => x.Model.Password).MinimumLength(4);
        }
    }
}
