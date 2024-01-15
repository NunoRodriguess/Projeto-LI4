using System;
using System.ComponentModel.DataAnnotations;

namespace BirdBoxFull.Shared
{
    public class Licitacao
    {
        [Key]
        public string codLicitacao { get; set; } = Guid.NewGuid().ToString();
        public string LeilaoCodLeilao { get; set; }
        public Leilao Leilao { get; set; }
        public string UtilizadorUsername { get; set; }
        public Utilizador Utilizador {  get; set; }
        public float valor { get; set; }
        public DateTime timestamp { get; set; }
        public bool isWinner { get; set; }


    }

}
