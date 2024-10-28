using FluentValidation;
using Teste_Felipe_Santana_CapiGemini.Dto;

namespace Teste_Felipe_Santana_CapiGemini.Validators;

public class TarefaValidator : AbstractValidator<TarefaDto>
{
    public TarefaValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição não pode ser null")
            .NotNull()
            .WithMessage("Descrição não pode estar vazio");
    }
}
