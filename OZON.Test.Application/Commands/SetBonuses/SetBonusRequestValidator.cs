using System;
using FluentValidation;

namespace OZON.Test.Application.Commands.SetBonuses
{
    public class SetBonusRequestValidator : AbstractValidator<SetBonusesRequest>
    {
        public SetBonusRequestValidator()
        {
            var thisYear = DateTime.Now.Year;
            RuleFor(x => x.Year)
                .InclusiveBetween(thisYear - 5, thisYear)
                .WithMessage("Incorrect year");
        }
    }
}