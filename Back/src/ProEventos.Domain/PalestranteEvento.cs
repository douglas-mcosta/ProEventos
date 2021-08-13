using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        public int PalentranteId { get; set; }
        public int EventoId { get; set; }

        //EF
        public Palestrante Palestrante { get; set; }
        public Evento Evento { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

    }
}