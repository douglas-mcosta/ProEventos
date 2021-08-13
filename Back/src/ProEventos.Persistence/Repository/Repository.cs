using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Context;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence.Repository
{
    public abstract class Repository : IRepository
    {
        public readonly ProEventosContext _context;

        public Repository(ProEventosContext context)
        {
            _context = context;
        }

        //GENERIC
        public void Add<T>(T entidade) where T : class
        {
            _context.Add<T>(entidade);
        }

        public void Update<T>(T entidade) where T : class
        {
            _context.Update<T>(entidade);
        }
        public void Delete<T>(T entidade) where T : class
        {
            _context.Remove<T>(entidade);
        }

        public void DeleteRange<T>(T[] entidades) where T : class
        {
            _context.RemoveRange(entidades);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
           _context?.Dispose();
        }
    }
}