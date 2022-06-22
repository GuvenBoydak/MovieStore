using FluentValidation;
using MovieStore.Business.Operations.OrderOpertation.Query.GetDetailOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Order
{
    public class GetDetailOrderQueryValidator:AbstractValidator<GetDetailOrderQuery>
    {
        public GetDetailOrderQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
