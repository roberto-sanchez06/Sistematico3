using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class Calendario
    {
        public int Id { get; set; }
        public Tipo Tipo { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto_Prestamo { get; set; }
        //calendario igual a numero de terminos
        public int Terminos { get; set; }
        public decimal Tasa { get; set; }
        public decimal Principal_Pagado { get; set; }
        public decimal Principal => (Monto_Prestamo * (1 + Tasa)) / Terminos;
        public decimal Interes => (Monto_Prestamo * Tasa / Terminos);
        public decimal Interes_Pagado { get; set; }
        public decimal Cuota => Principal + Tasa;
        public decimal Cuota_Pagado { get; set; }
    }
}
