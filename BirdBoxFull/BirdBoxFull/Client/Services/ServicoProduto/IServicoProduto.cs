using BirdBoxFull.Client.Pages;
using BirdBoxFull.Shared;

namespace BirdBoxFull.Client.Services.ServicoProduto
{
	public interface IServicoProduto
	{
		List<Leilao> Leiloes { get; set; }
		Task loadLeiloes();
        Task<Leilao> loadLeilao(string cod);
    }
}
