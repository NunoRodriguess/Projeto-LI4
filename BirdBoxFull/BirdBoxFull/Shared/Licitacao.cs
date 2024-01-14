using System;
using System.ComponentModel.DataAnnotations;

namespace BirdBoxFull.Shared
{
    public class Licitacao
    {
        [Key]
        public string codLicitacao { get; set; }
        public string codLeilao { get; set; }
        public string codUtilizador { get; set; }
        public float valor { get; set; }
        public DateTime timestamp { get; set; }

        public Licitacao(string codLicitacao, string codLeilao, string codUtilizador, float valor, DateTime timestamp)
        {
            this.codLicitacao = codLicitacao;
            this.codLeilao = codLeilao;
            this.codUtilizador = codUtilizador;
            this.valor = valor;
            this.timestamp = timestamp;
        }


        public override string ToString()
        {
            return "Licitacao{" +
                   "codLicitacao='" + codLicitacao + '\'' +
                   ", codLeilao='" + codLeilao + '\'' +
                   ", codUtilizador='" + codUtilizador + '\'' +
                   ", valor=" + valor +
                   ", timestamp=" + timestamp +
                   '}';
        }

    }

}
