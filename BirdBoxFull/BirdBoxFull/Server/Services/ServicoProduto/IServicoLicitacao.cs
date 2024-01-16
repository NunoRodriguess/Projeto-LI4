using BirdBoxFull.Shared;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public interface IServicoLicitacao
    {
        Task<Licitacao> ConsultarLicitacao(String Username, String codLeilao);

        Task AddLicitacao(Licitacao newLiciticao);

        Task ApagarLicitacao(string codLicitacao);
		Task<List<Licitacao>> ConsultarLicitacaoList(String Username);
	}
}
