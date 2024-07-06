using FluentValidation;
using Weather.BLL.DTOs;

namespace Weather.BLL.Validators
{
    public class UrlOptionsDtoValidator : AbstractValidator<UrlOptionsDto>
    {
        public UrlOptionsDtoValidator()
        {
            RuleFor(r => r.City)
                .NotEmpty().WithMessage("City field is required.");

            RuleFor(r => r.Unit)
                .NotEmpty().WithMessage("Unit field is required.");
        }
    }
}
