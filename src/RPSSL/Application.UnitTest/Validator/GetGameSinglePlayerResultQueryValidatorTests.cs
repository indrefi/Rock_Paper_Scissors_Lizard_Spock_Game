using Application.UseCases.PlayGameSinglePlayer.Queries;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTest.Validator
{
    public class GetGameSinglePlayerResultQueryValidatorTests
    {
        private GetGameSinglePlayerResultQueryValidator _validator;

        public static TheoryData<GetGameSinglePlayerResultQuery> _invalidData =>
            new TheoryData<GetGameSinglePlayerResultQuery>
            {
                new GetGameSinglePlayerResultQuery { Player = -1 },
                new GetGameSinglePlayerResultQuery { Player = 8 },
            };

        public GetGameSinglePlayerResultQueryValidatorTests()
        {
            _validator = new GetGameSinglePlayerResultQueryValidator();
        }

        [Theory]
        [MemberData(nameof(_invalidData), MemberType = typeof(GetGameSinglePlayerResultQueryValidatorTests))]
        public void ShouldReturnInvalidRequestTest(GetGameSinglePlayerResultQuery request)
        {
            var result = _validator.TestValidate(request);

            result.ShouldHaveValidationErrorFor(request => request.Player);
            result.ShouldHaveValidationErrorFor(request => request.Player);
        }

        [Fact]
        public void ShouldReturnValidRequestTest()
        {
            var request = new GetGameSinglePlayerResultQuery { Player = 1 };
            var result = _validator.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(request => request.Player);
        }
    }
}
