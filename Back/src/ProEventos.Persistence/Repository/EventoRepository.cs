using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Context;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence.Repository
{
    public class EventoRepository : Repository, IEventoRepository
    {
        public EventoRepository(ProEventosContext context) : base(context){}
      
        //EVENTOS
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {

            IQueryable<Evento> query = _context.Eventos
            .AsNoTracking()
            .Include(x => x.Lotes)
            .Include(x => x.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(x => x.PalestrantesEventos)
                .ThenInclude(x => x.Palestrante);
            }

            query = query
            .Where(x => x.Id == eventoId)
            .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();

        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .AsNoTracking()
            .Include(x => x.Lotes)
            .Include(x => x.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(x => x.PalestrantesEventos)
                .ThenInclude(x => x.Palestrante);
            }

            return await query.OrderBy(x => x.Id).ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .AsNoTracking()
           .Include(x => x.Lotes)
           .Include(x => x.RedeSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(x => x.PalestrantesEventos)
                .ThenInclude(x => x.Palestrante);
            }

            query = query
            .Where(x => x.Tema.ToLower().Contains(tema.ToLower()))
            .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
    }
}