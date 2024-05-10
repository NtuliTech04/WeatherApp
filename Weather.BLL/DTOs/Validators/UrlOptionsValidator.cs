using FluentValidation;
using Weather.DAL.Configurations;

namespace Weather.BLL.DTOs.Validators
{
    public class UrlOptionsValidator : AbstractValidator<OpenWeather>
    {
        public UrlOptionsValidator() 
        {
            //RuleFor(r=>r.Location).NotEmpty();
            //RuleFor(r=>r.Unit).NotEmpty();
        }
    }
}
