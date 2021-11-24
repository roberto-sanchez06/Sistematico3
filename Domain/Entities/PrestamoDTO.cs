using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PrestamoDTO
    {
        public int Id { get; set; }
        public Estado Estado { get; set; }
        public decimal Principal { get; set; }
        public decimal Interes { get; set; }
        public decimal Monto { get; set; }
        public decimal Tasa { get; set; }
        public int Termino { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
