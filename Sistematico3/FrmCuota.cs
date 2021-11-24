using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Sistematico3
{
    public partial class FrmCuota : Form
    {
        public ICalendarioService calendarioService { get; set; }
        public FrmCuota()
        {
            InitializeComponent();
        }

        private void FrmCuota_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.AddRange(Enum.GetValues(typeof(Estado)).Cast<object>().ToArray());
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validaciones();
                Calendario calendarioPago = new Calendario()
                {
                    Id = calendarioService.GetLastIdCuota() + 1,
                    Estado = (Estado)cmbEstado.SelectedIndex,
                    FechaPago = dtpPaga.Value,
                    Monto_Prestamo = nudMonto.Value,
                    Terminos = (int)nudTerminos.Value,
                    Tasa = nudTasa.Value
                };
                calendarioService.Add(calendarioPago);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void validaciones()
        {
            if(cmbEstado.SelectedIndex==-1)
            {
                throw new ArgumentException("Falta rellenar campos");
            }
        }
    }
}
