using Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries;
using FluentValidation;

namespace Application.UseCases.PlayGameMultiPlayer.Queries
{
    public class GetGameMultiPlayerResultQueryValidator : AbstractValidator<GetGameMultiPlayerResultQuery>, IValidator
    {
        public GetGameMultiPlayerResultQueryValidator()
        {
            RuleFor(x => x.PlayerOne).GreaterThan(0).WithMessage("Player choise id has to be a strict positive number.");
            RuleFor(x => x.PlayerOne).LessThanOrEqualTo(5).WithMessage("Player choise id cannot be greater than 5.");
            RuleFor(x => x.PlayerTwo).GreaterThan(0).WithMessage("Player choise id has to be a strict positive number.");
            RuleFor(x => x.PlayerTwo).LessThanOrEqualTo(5).WithMessage("Player choise id cannot be greater than 5.");
        }
    }
}
