using System;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface
{
    public interface IRepository : IDisposable
    {
         void Add<T>(T entidade)  where T: class;
         void Update<T>(T entidade) where T: class;
         void Delete<T>(T entidade) where T: class;
         void DeleteRange<T>(T[] entidade) where T: class;
         Task<bool> SaveChangesAsync();       

    }
}