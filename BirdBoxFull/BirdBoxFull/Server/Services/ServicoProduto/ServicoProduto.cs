using BirdBoxFull.Shared;
using System.Xml.Linq;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public class ServicoProduto : IServicoProduto
    {
        public List<Leilao> Leiloes { get; set; } = new List<Leilao>{

                new Leilao("codigo1","user1","Ganda Leilao",10,"nope","a decorrer", new List<string> {"https://picsum.photos/200/300", "https://picsum.photos/200/300", "https://picsum.photos/200/300","https://picsum.photos/200/300"},
                    "Produto",
                    10,
                    "Banladesh",
                     true,

                new DateTime(2024, 1, 15, 5, 10, 20)),

            };

        public async Task<List<Leilao>> GetAllLeiloes()
        {
            return Leiloes;
        }

        public async Task<Leilao> GetLeilao(string codLeilao)
        {
          return Leiloes.FirstOrDefault(p => p.CodLeilao.Equals(codLeilao));
        }

        public async Task<List<Leilao>> GetLeilaoByFiltro(List<string> filtros)
        {
            throw new NotImplementedException();
        }
    }
}
