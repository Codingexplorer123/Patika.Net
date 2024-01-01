using FluentValidation;
using WebApi.Application.Commands.CreateAuthor;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command=>command.Model.Name).MinimumLength(3);
            RuleFor(command=>command.Model.Surname).MinimumLength(3);
            RuleFor(command=>command.Model.Birthday).LessThan(DateTime.Now.Date);
        }
    }
}