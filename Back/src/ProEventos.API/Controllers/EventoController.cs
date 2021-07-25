using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new Evento[]{
                new Evento(){
                    EventoId = 1,
                    Tema="Angular 11",
                    Local="São Paulo",
                    QtdPessoas= 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    Lote="1º Lote",
                    ImagemURL="evento.jpg"
                    },

                     new Evento(){
                    EventoId = 2,
                    Tema="Angular 12",
                    Local="São Paulo",
                    QtdPessoas= 150,
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    Lote="2º Lote",
                    ImagemURL="evento2.jpg"
                    }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {

            return _eventos;
        }

        [HttpGet("{id:int}")]
        public Evento Get(int id)
        {
            return _eventos.FirstOrDefault(x => x.EventoId == id);
        }
    }
}
