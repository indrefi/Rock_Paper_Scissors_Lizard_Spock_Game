using FluentValidation;

namespace Application.UseCases.Scoreboard.Commands.AddToScoreboard
{
    public class AddToScoreboardCommandValidator : AbstractValidator<AddToScoreboardCommand>, IValidator
    {
        public AddToScoreboardCommandValidator()
        {
            RuleFor(x => x.PlayerOneChoiseId).GreaterThan(0).WithMessage("Player choise id has to be a strict positive number.");
            RuleFor(x => x.PlayerOneChoiseId).LessThanOrEqualTo(5).WithMessage("Player choise id cannot be greater than 5.");
            RuleFor(x => x.PlayerTwoChoiseId).GreaterThan(0).WithMessage("Player choise id has to be a strict positive number.");
            RuleFor(x => x.PlayerTwoChoiseId).LessThanOrEqualTo(5).WithMessage("Player choise id cannot be greater than 5.");

            RuleFor(x => x.PlayerOneId).GreaterThan(0).WithMessage("Player id has to be a strict positive number.");
            RuleFor(x => x.PlayerTwoId).GreaterThan(0).WithMessage("Player id has to be a strict positive number.");

            RuleFor(x => x.Result).GreaterThan(0).WithMessage("Result id has to be a strict positive number.");
            RuleFor(x => x.Result).LessThanOrEqualTo(3).WithMessage("Result id has to be less or equal than 3.");
        }
    }
}
