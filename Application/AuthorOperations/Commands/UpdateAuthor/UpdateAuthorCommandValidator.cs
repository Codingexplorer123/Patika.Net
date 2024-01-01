using FluentValidation;
using WebApi.Application.Commands.UpdateAuthor;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command=>command.Model.Name).MinimumLength(3);
            RuleFor(command=>command.Model.Surname).MinimumLength(3);
            RuleFor(command=>command.Model.Birthday).LessThan(DateTime.Now.Date);
        }
    }
}