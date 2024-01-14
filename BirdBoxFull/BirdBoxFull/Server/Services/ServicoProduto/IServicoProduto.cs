﻿namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public interface IServicoProduto
    {
        Task<List<Leilao>> GetAllLeiloes();
        Task<List<Leilao>> GetLeilaoByFiltro(List<string> filtros);
        Task<Leilao> GetLeilao(string codLeilao);
    }
}