using System;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface
{
    public interface IPalestranteRepository : IRepository
    {

         //Palestrantes
        Task<Palestrante[]> GetAllPalestranteByNomeAsync(string nome,bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> GetPalestranteByIdAsync(int palestranteId,bool includeEventos);

    }
}