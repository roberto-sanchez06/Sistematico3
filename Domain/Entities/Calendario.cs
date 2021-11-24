using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class Calendario
    {
        public int Id { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaVencimiento => FechaPago.AddMonths(Terminos);
        public DateTime FechaPago { get; set; }
        public decimal Monto_Prestamo { get; set; }
        //calendario igual a numero de terminos
        public int Terminos { get; set; }
        public decimal Tasa { get; set; }
        public decimal Principal_Pagado => Principal;
        public decimal Principal => (Monto_Prestamo * (1 + Tasa)) / Terminos;
        public decimal Interes => (Monto_Prestamo * Tasa / Terminos);
        public decimal Interes_Pagado => Interes;
        public decimal Cuota => Principal + Interes;
        public decimal Cuota_Pagado => Cuota;
    }
}
