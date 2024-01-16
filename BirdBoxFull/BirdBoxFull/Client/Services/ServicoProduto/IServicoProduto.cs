using BirdBoxFull.Client.Pages;
using BirdBoxFull.Shared;
using static System.Net.WebRequestMethods;

namespace BirdBoxFull.Client.Services.ServicoProduto
{
	public interface IServicoProduto
	{
		List<Leilao> Leiloes { get; set; }
		Task loadLeiloes();
        Task<Leilao> loadLeilao(string cod);

		Task UploadImages(List<LeilaoImage> images);

        Task AddLeilao(Leilao novoLeilao);
    }
}
