using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetAllEventosAsync(includePalestrantes);
                if (eventos is null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepository.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos is null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
              try
            {
                var eventos = await _eventoRepository.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos is null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _eventoRepository.Add<Evento>(model);
                var result = await _eventoRepository.SaveChangesAsync();
                if (!result)
                    throw new Exception("Erro ao salvar evento.");

                return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(Evento model)
        {
            try
            {
                var evento = _eventoRepository.GetEventoByIdAsync(model.Id);

                if (evento is null)
                    throw new Exception("Evento não encontrado");

                _eventoRepository.Update<Evento>(model);

                var result = await _eventoRepository.SaveChangesAsync();

                if (!result)
                    throw new Exception("Erro ao atualizar evento.");

                return await _eventoRepository.GetEventoByIdAsync(model.Id, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {

            try
            {
                var evento = await _eventoRepository.GetEventoByIdAsync(eventoId);

                if (evento is null)
                    throw new Exception("Evento não encontrado.");

                _eventoRepository.Delete<Evento>(evento);
                var result = await _eventoRepository.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}