using BirdBoxFull.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Leilao
{
    [Key]
    public string CodLeilao { get; set; }
    public string UtilizadorUsername { get; set; }
    public string Descricao { get; set; }
    public float ValorMinimo { get; set; }
    public string Relatorio { get; set; }
    public string Estado { get; set; }
    public List<string> Images { get; set; }
    public string Name { get; set; }
    public decimal EntryPrice { get; set; }
    public string Location { get; set; }
    public bool IsPublic { get; set; }
    public DateTime DataFinal { get; set; }

    // Parameterized constructor
    public Leilao(string codLeilao, string codUtilizador, string descricao,
                  float valorMinimo, string relatorio, string estado,
                  List<string> images, string name, decimal entryPrice, string location, bool isPublic, DateTime dataFinal)
    {
        CodLeilao = codLeilao;
        UtilizadorUsername = codUtilizador;
        Descricao = descricao;
        ValorMinimo = valorMinimo;
        Relatorio = relatorio;
        Estado = estado;
        Images = images;
        Name = name;
        EntryPrice = entryPrice;
        Location = location;
        IsPublic = isPublic;
        DataFinal = dataFinal;
    }

    public Leilao() { }
}


