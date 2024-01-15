﻿using BirdBoxFull.Shared;

namespace BirdBoxFull.Client.Services.ServicoProduto
{
    public interface IServicoUtilizador
    {
        Utilizador Utilizador { get; set; }

        Task<Utilizador> GetUtilizador(string Username, string Password);

        Task<bool> AddUtilizador(Utilizador newUser);

        Task<bool> AlteraUtilizador(Utilizador User);


    }
}
