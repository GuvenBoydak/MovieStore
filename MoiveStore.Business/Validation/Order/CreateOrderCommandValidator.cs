using FluentValidation;
using MovieStore.Business.Operations.OrderOpertation.Command.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Order
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).NotEmpty();
            RuleFor(x => x.Model.CustomerId).GreaterThan(0);
            RuleFor(x => x.Model.MovieId).NotEmpty();
            RuleFor(x => x.Model.MovieId).GreaterThan(0);
            RuleFor(x => x.Model.Price).NotEmpty();
            RuleFor(x => x.Model.Price).GreaterThan(0);
        }
    }
}
