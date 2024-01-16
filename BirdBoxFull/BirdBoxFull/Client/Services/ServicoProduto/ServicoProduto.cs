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

        public async Task UploadImages(List<LeilaoImage> images)
        {
            var response = await _http.PostAsJsonAsync("api/Leiloes/upload/image", images);

            if (!response.IsSuccessStatusCode)
            {
                // Handle the error as needed
                // Example: throw new ApplicationException("Image upload failed");
            }
        }

        public async Task AddLeilao(Leilao novoLeilao)
        {
            Console.WriteLine(novoLeilao.UtilizadorUsername + " " + novoLeilao.DataFinal + " " + novoLeilao.Estado + " " + novoLeilao.CodLeilao);
            var response = await _http.PostAsJsonAsync("api/Leiloes/regista", novoLeilao);

            if (!response.IsSuccessStatusCode)
            {
                // Handle the error as needed
                // Example: throw new ApplicationException("Image upload failed");
            }
        }
		public async Task<List<Leilao>> GetLeilaoByUser(string Username)
        {
            Console.WriteLine("BEEP BEEP");
			return await _http.GetFromJsonAsync<List<Leilao>>($"api/Leiloes/user/{Username}");
		}
	}
}
