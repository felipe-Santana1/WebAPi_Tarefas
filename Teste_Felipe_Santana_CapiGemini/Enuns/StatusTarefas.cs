using System.ComponentModel;

namespace Teste_Felipe_Santana_CapiGemini.Enuns;

public enum StatusTarefas
{
    [Description("A fazer")]
    Afazer = 1,

    [Description("Em andamento")]
    EmAndamento = 2,

    [Description("Feito")]
    Feito = 3,

}
