using FluentValidation;
using MovieStore.Business.Operations.ActorOperations.Command.DeleteActor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation.Actor
{
    public class DeleteActorCommandValidator:AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty();
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}
