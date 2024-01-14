using System.ComponentModel.DataAnnotations;

namespace BirdBoxFull.Shared { 
public class Encomenda
{
    [Key]
    public string codEncomenda { get; set; }
    public string LeilaoCodLeilao { get; set; }
    public Leilao Leilao { get; set; }
    public string UtilizadorUsername { get; set; }
    public Utilizador Utilizador { get; set; }
    public string numeroSeguimento { get; set; }

    public Encomenda(string codEncomenda, string LeilaoCodLeilao, string UtilizadorUsername, string numeroSeguimento)
    {
        this.codEncomenda = codEncomenda;
        this.LeilaoCodLeilao = LeilaoCodLeilao;
        this.UtilizadorUsername = UtilizadorUsername;
        this.numeroSeguimento = numeroSeguimento;
    }

  

}
}
