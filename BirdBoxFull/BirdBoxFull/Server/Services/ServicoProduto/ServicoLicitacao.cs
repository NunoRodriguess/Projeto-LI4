// ServicoLicitacao.cs
using BirdBoxFull.Server.Data;
using BirdBoxFull.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BirdBoxFull.Server.Services.ServicoProduto
{
    public class ServicoLicitacao : IServicoLicitacao
    {
        private readonly DataContext _context;

        public ServicoLicitacao(DataContext context)
        {
            _context = context;
        }

        public async Task AddLicitacao(Licitacao newLicitacao)
        {

           

            // Assuming novoLeilao.Utilizador is the associated Utilizador
            var existingUtilizador = await _context.Utilizadores.FindAsync(newLicitacao.UtilizadorUsername);
            var existingLeilao = await _context.Leiloes.FindAsync(newLicitacao.LeilaoCodLeilao);

            // Attach or load the Utilizador
            if (existingUtilizador != null)
            {
                _context.Entry(existingUtilizador).State = EntityState.Unchanged;
                newLicitacao.Utilizador = existingUtilizador;
            }

            if (existingLeilao != null)
            {
                _context.Entry(existingLeilao).State = EntityState.Unchanged;
                newLicitacao.Leilao = existingLeilao;
            }
            _context.Licitacoes.Add(newLicitacao);
            await _context.SaveChangesAsync();
        }

        public async Task<Licitacao> ConsultarLicitacao(string username, string codLeilao)
        {
            return await _context.Licitacoes
                .Where(l => l.UtilizadorUsername.Equals(username) && l.LeilaoCodLeilao.Equals(codLeilao))
                .FirstOrDefaultAsync();
        }

		public async Task<List<Licitacao>> ConsultarLicitacaoList(string Username)
		{
			return await _context.Licitacoes
				.Where(l => l.UtilizadorUsername.Equals(Username))
				.ToListAsync();
		}

        public async Task ApagarLicitacao(string codLicitacao)
        {
            var licitacaoToDelete = await _context.Licitacoes.FindAsync(codLicitacao);

            if (licitacaoToDelete != null)
            {
                _context.Licitacoes.Remove(licitacaoToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Licitacao not found");
            }
        }
    }
}
