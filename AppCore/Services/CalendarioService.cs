using System;
using System.Collections.Generic;
using System.Text;
using AppCore.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace AppCore.Services
{
    public class CalendarioService : ICalendarioService
    {
        private ICalendarioRepository calendarioRepository;

        public CalendarioService(ICalendarioRepository calendarioRepository)
        {
            this.calendarioRepository = calendarioRepository;
        }

        public void Add(Calendario c)
        {
            calendarioRepository.Add(c);
        }

        public List<Calendario> FindAll()
        {
            return calendarioRepository.FindAll();
        }

        public List<Calendario> FindAll(Predicate<Calendario> predicate)
        {
            return calendarioRepository.FindAll(predicate);
        }

        public int GetLastIdCuota()
        {
            return calendarioRepository.GetLastIdCuota();
        }
    }
}
