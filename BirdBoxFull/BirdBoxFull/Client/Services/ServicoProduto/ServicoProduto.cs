using BirdBoxFull.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BirdBoxFull.Client.Services.ServicoProduto
{
	public class ServicoProduto : IServicoProduto
	{
        private readonly HttpClient _http;

        public List<Leilao> Leiloes { get; set; } = new List<Leilao>();

        public ServicoProduto(HttpClient httpClient)
        {
            this._http = httpClient;
        }

        public async Task loadLeiloes()
		{

            Leiloes = await _http.GetFromJsonAsync<List<Leilao>>("api/Leiloes");
            
		
		}

        public async Task<Leilao> loadLeilao(string cod)
        {
            return await _http.GetFromJsonAsync<Leilao>($"api/Leiloes/{cod}");
      
        }
    }
}
