﻿using BirdBoxFull.Shared;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public interface IServicoEncomenda
    {

        Task addEncomenda(Encomenda e);

        Task<Encomenda> GetEncomenda(string codEncomenda);

        Task<List<Encomenda>> GetEncomendasByUser(string Username);

        Task<List<Encomenda>> GetEncomendas();


    }
}
