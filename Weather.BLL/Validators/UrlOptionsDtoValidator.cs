using FluentValidation;
using Weather.BLL.DTOs;

namespace Weather.BLL.Validators
{
    public class UrlOptionsDtoValidator : AbstractValidator<UrlOptionsDto>
    {
        public UrlOptionsDtoValidator()
        {
            RuleFor(r => r.City).NotEmpty();
            RuleFor(r => r.Unit).NotEmpty();
        }
    }
}
