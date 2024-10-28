using FluentValidation;
using Teste_Felipe_Santana_CapiGemini.Dto;

namespace Teste_Felipe_Santana_CapiGemini.Validators;

public class UsuarioValidator : AbstractValidator<UsuarioDto>
{
    public UsuarioValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")
            .NotNull()
            .WithMessage("O nome não pode estar em branco");

    }
}
