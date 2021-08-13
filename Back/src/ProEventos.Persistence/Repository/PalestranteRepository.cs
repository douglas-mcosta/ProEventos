using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Context;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence.Repository
{
    public class PalestranteRepository : Repository, IPalestranteRepository
    {
        public PalestranteRepository(ProEventosContext context) : base(context){}
      
        //PALESTRANTES
        public async Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query
            .Where(p => p.Nome.ToLower() == nome.ToLower())
            .OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(x => x.RedeSociais);

            if (includeEventos)
            {
                query = query
                .Include(x => x.PalestrantesEventos)
                .ThenInclude(x => x.Evento);
            }

            return await query
            .OrderBy(x => x.Id)
            .ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSociais);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == palestranteId);
        }
    }
}