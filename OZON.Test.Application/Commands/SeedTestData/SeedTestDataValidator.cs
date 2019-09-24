using FluentValidation;

namespace OZON.Test.Application.Commands.SeedTestData
{
    public class SeedTestDataValidator : AbstractValidator<SeedTestDataCommand>
    {
        public SeedTestDataValidator()
        {
            RuleFor(x => x.EmployeeCount)
                .GreaterThan(1000)
                .WithMessage("The number of test employees should be greater than 1000");
        }
    }
}