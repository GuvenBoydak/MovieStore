using FluentValidation;
using MovieStore.Business.Operations.ActorOperations.Query.GetDetailActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Actor
{
    public class GetDetailActorQueryValidator:AbstractValidator<GetDetailActorQuery>
    {
        public GetDetailActorQueryValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.Surname).NotEmpty();
            RuleFor(x => x.ActorId).NotEmpty();
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}
