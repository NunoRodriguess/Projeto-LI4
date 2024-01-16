using BirdBoxFull.Server.Data;
using BirdBoxFull.Shared;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public class ServicoProduto : IServicoProduto
    {
       /* public List<Leilao> Leiloes { get; set; } = new List<Leilao>{

                new Leilao("ide","user1","Ganda Leilao",10,"nope","a decorrer", new List<string> {"https://picsum.photos/200/300", "https://picsum.photos/200/300", "https://picsum.photos/200/300","https://picsum.photos/200/300"},
                    "Produto",
                    10,
                    "Banladesh",
                     true,

                new DateTime(2024, 1, 15, 5, 10, 20)),

            };*/

        private readonly DataContext _context;

        public ServicoProduto(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Leilao>> GetAllLeiloes()
        {
            
            List<Leilao> l = await _context.Leiloes.ToListAsync();
            foreach (Leilao le in l)
            {

                string codLeilaoToFilter = le.CodLeilao; // Replace with the actual value you're looking for

                List<LeilaoImage> filteredImages = await _context.LeilaoImages
                    .Where(image => image.LeilaoCodLeilao == codLeilaoToFilter)
                    .ToListAsync();

                foreach (var image in filteredImages)
                {
                    le.Images.Add(image.ImageUrl);
                }

            }
            return l;
           // return Leiloes;
           
        }

        public async Task<Leilao> GetLeilao(string codLeilao)
        {
           
            Leilao l =  await _context.Leiloes.FirstOrDefaultAsync(p => p.CodLeilao.Equals(codLeilao)).ConfigureAwait(false);

            string codLeilaoToFilter = l.CodLeilao; // Replace with the actual value you're looking for

            List<LeilaoImage> filteredImages = await _context.LeilaoImages
                .Where(image => image.LeilaoCodLeilao == codLeilaoToFilter)
                .ToListAsync();
            foreach (var image in filteredImages)
            {
                l.Images.Add(image.ImageUrl);
            }

            return l;
        }

        public async Task<List<Leilao>> GetLeilaoByFiltro(List<string> filtros)
        {
            throw new NotImplementedException();
        }


        public async Task UploadImages(List<LeilaoImage> images)
        {
            foreach (var image in images)
            {
                // Assuming Leilao associated with the LeilaoImage
                var existingLeilao = await _context.Leiloes.FindAsync(image.LeilaoCodLeilao);

                // Attach or load the Leilao
                if (existingLeilao != null)
                {
                    _context.Entry(existingLeilao).State = EntityState.Unchanged;
                    image.Leilao = existingLeilao;
                }

                // You can customize this logic based on your database structure and relationships
                _context.LeilaoImages.Add(image);
            }

            await _context.SaveChangesAsync();
        }

        public async Task AddLeilao(Leilao novoLeilao)
        {
           

            // Assuming novoLeilao.Utilizador is the associated Utilizador
            var existingUtilizador = await _context.Utilizadores.FindAsync(novoLeilao.Utilizador.Username);

            // Attach or load the Utilizador
            if (existingUtilizador != null)
            {
                _context.Entry(existingUtilizador).State = EntityState.Unchanged;
                novoLeilao.Utilizador = existingUtilizador;
            }

            _context.Leiloes.Add(novoLeilao);
            await _context.SaveChangesAsync();
        }

		public async Task<List<Leilao>> GetLeilaoByUser(string Username)
        {

			List<Leilao> l = await _context.Leiloes.ToListAsync();
            List<Leilao> final = new List<Leilao>();
			foreach (Leilao le in l)
			{
                if (le.UtilizadorUsername.Equals(Username))
                {
					string codLeilaoToFilter = le.CodLeilao; // Replace with the actual value you're looking for

					List<LeilaoImage> filteredImages = await _context.LeilaoImages
						.Where(image => image.LeilaoCodLeilao == codLeilaoToFilter)
						.ToListAsync();

					foreach (var image in filteredImages)
					{
						le.Images.Add(image.ImageUrl);
					}
                    final.Add(le);

				}

			}
			return final;
		}

	}
}
