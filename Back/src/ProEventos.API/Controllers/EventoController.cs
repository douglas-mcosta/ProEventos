using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            var eventos = _context.Eventos.ToList();
            return eventos;
        }

        [HttpGet("{id:int}")]
        public Evento Get(int id)
        {
            var eventos = _context.Eventos.FirstOrDefault(x => x.EventoId == id);
            return eventos;
        }
    }
}
