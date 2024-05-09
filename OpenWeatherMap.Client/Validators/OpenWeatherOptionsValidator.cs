using FluentValidation;
using OpenWeatherMap.Client.Options;

namespace OpenWeatherMap.Client.Validators
{
    public class OpenWeatherOptionsValidator : AbstractValidator<OpenWeatherOptions>
    {
        public OpenWeatherOptionsValidator() 
        {
            RuleFor(r=>r.Location).NotEmpty();
            RuleFor(r=>r.Unit).NotEmpty();
        }
    }
}
