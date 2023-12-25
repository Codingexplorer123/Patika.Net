using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0).WithMessage("Id degeri icin 0 dan buyuk deger giriniz");
            RuleFor(command=>command.Model.Title).NotEmpty().WithMessage("Title girilmesi zorunludur.");
            RuleFor(command=>command.Model.Title).MinimumLength(4).WithMessage("En az 4 karakter giriniz");
            RuleFor(command=>command.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(command=>command.Model.PublishDate).LessThan(DateTime.Now.Date);
            
        }
    }
}