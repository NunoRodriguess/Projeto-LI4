using System.ComponentModel.DataAnnotations;

namespace BirdBoxFull.Shared { 
public class Encomenda
{
    [Key]
    public string codEncomenda { get; set; }
    public string codLeilao { get; set; }
    public string codUtilizador { get; set; }
    public string numeroSeguimento { get; set; }

    public Encomenda(string codEncomenda, string codLeilao,string codUtilizador, string numeroSeguimento)
    {
        this.codEncomenda = codEncomenda;
        this.codLeilao = codLeilao;
        this.codUtilizador = codUtilizador;
        this.numeroSeguimento = numeroSeguimento;
    }

  

}
}
