using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BirdBoxFull.Shared
{
    public class Utilizador
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime dataNascimento { get; set; }
        public string metodoPagamento { get; set; }
        public string indicativo { get; set; }
        public string numeroTelemovel { get; set; }
        public string email { get; set; }
        public string numeroPorta { get; set; }
        public string rua { get; set; }
        public string localidade { get; set; }
        public string codigoPostal { get; set; }
        public string cc { get; set; }

        /*
        ALTER TABLE Utilizador
        ADD CodUtilizador VARCHAR(10) NOT NULL,
        ADD DataNascimento DATETIME NOT NULL,
        ADD MetodoPagamento VARCHAR(20) NOT NULL,
        ADD Indicativo VARCHAR(10) NOT NULL,
        ADD NumeroTelemovel VARCHAR(20) NOT NULL,
        ADD Rua VARCHAR(50) NOT NULL,
        ADD Localidade VARCHAR(50) NOT NULL,
        ADD CodigoPostal VARCHAR(10) NOT NULL;
        */

        public Utilizador(string codUtilizador, string password, DateTime dataNascimento, string metodoPagamento,
                            string indicativo, string numeroTelemovel, string email, string numeroPorta,
                            string rua, string localidade, string codigoPostal, string cc)
        {
            this.Username = codUtilizador;
            this.Password = password;
            this.dataNascimento = dataNascimento;
            this.metodoPagamento = metodoPagamento;
            this.indicativo = indicativo;
            this.numeroTelemovel = numeroTelemovel;
            this.email = email;
            this.numeroPorta = numeroPorta;
            this.rua = rua;
            this.localidade = localidade;
            this.codigoPostal = codigoPostal;
            this.cc = cc;
       
        }
        public Utilizador()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.metodoPagamento = string.Empty;
            this.indicativo = string.Empty;
            this.numeroTelemovel = string.Empty;
            this.email = string.Empty;
            this.numeroPorta = string.Empty;
            this.rua = string.Empty;
            this.localidade = string.Empty;
            this.codigoPostal = string.Empty;
            this.cc = string.Empty;

        }





    }
}

