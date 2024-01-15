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
            Console.WriteLine("Beep Beep");
            Console.WriteLine(l);
            Console.WriteLine(l.Count);
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

        public async Task AddLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            await _context.SaveChangesAsync();
        }

        public async Task UploadImages(List<LeilaoImage> images)
        {
            foreach (var image in images)
            {
                // You can customize this logic based on your database structure and relationships
                _context.LeilaoImages.Add(image);
            }

            await _context.SaveChangesAsync();
        }
    }
}
