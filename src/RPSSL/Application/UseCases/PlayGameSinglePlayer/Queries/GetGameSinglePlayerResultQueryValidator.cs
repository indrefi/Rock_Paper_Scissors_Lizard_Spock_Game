using FluentValidation;

namespace Application.UseCases.PlayGameSinglePlayer.Queries
{
    public class GetGameSinglePlayerResultQueryValidator : AbstractValidator<GetGameSinglePlayerResultQuery>, IValidator
    {
        public GetGameSinglePlayerResultQueryValidator()
        {
            RuleFor(x => x.Player).GreaterThan(0).WithMessage("Player choise id has to be a strict positive number.");
            RuleFor(x => x.Player).LessThanOrEqualTo(5).WithMessage("Player choise id cannot be greater than 5.");
        }
    }
}
