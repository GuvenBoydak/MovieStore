using FluentValidation;
using MovieStore.Business.Operations.DirectorOperations.Query.GetDetailDirector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Director
{
    public class GetDetailDirectorQueryValidator:AbstractValidator<GetDetailDirectorQuery>
    {
        public GetDetailDirectorQueryValidator()
        {
            RuleFor(x=>x.DirectorId).NotEmpty();
            RuleFor(x=>x.DirectorId).GreaterThan(0);
        }
    }
}
