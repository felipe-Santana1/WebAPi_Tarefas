using Teste_Felipe_Santana_CapiGemini.Enuns;

namespace Teste_Felipe_Santana_CapiGemini.Models;

public class TarefaModel
{
    public int id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefas Status { get; set; }
    public int? UsuarioID { get; set; }  
    public virtual UsuarioModel? Usuario { get; set; }

}
