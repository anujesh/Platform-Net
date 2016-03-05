using FluentValidation;
using Platform.Core.Basic;

namespace Platform.Core
{
    public class PageValidator : AbstractValidator<Page>
    {
        public PageValidator()
        {
            RuleFor(p => p.Content).NotEmpty();
        }
    }
}
