using ContactRegister.Models;
using FluentValidation;

namespace ContactRegister.Validations
{
    public class ContactRequest : AbstractValidator<Contact>
    {
        public ContactRequest()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Must(x => x.Split(" ").Length > 1)
                .WithMessage("First name must contain at least one last name")
                .Must(x => !x.ContemEspacoEmBranco())
                .WithMessage("Name must not contain blanks")
                .Must(x => !x.ExisteAlgumSimboloOuCaracterEspecial())
                .WithMessage("Name must not contain special characters")
                .Must(x => x.TemPeloMenosDoisCaracteresParaCadaPalavra())
                .WithMessage("Invalid name. First and/or last name must contain at least two letters or more");

            RuleFor(x => x.PersonalPhone)
                .Must(x => x.IsNumberPhoneValid())
                .WithMessage("O Cellphone needs to be in the format '(XX) XXXXX-XXXX'");                
        }
    }
}
