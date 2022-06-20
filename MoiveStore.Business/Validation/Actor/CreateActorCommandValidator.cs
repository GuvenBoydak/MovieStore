using FluentValidation;
using MovieStore.Business.Operations.ActorOperations.Command.CreateActor;

namespace MovieStore.Business.Validation.Actor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.Surname).NotEmpty();

        }
    }
}
