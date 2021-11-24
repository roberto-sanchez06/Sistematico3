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
    public partial class FrmCalendario : Form
    {
        private ICalendarioService calendarioService;
        public int indexelegido;
        public int ids;

        public FrmCalendario(ICalendarioService calendarioService)
        {
            this.calendarioService = calendarioService;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmCuota frmCuota = new FrmCuota();
            frmCuota.calendarioService = calendarioService;
            frmCuota.ShowDialog();
            llenarDgv(calendarioService.FindAll());
        }
        private void llenarDgv(List<Calendario> calendarios)
        {
            dataGridView1.Rows.Clear();
            foreach(Calendario  c in calendarios)
            {
                dataGridView1.Rows.Add(c.Id, c.Estado, c.FechaPago, c.FechaVencimiento, c.Monto_Prestamo, c.Terminos, c.Tasa, c.Principal, c.Interes);
            }
        }
        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            cmbFinder.Items.AddRange(Enum.GetValues(typeof(Finder)).Cast<object>().ToArray());
            cmbEstado.Items.AddRange(Enum.GetValues(typeof(Estado)).Cast<object>().ToArray());
            
        }

        private void cmbFinder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    numericUpDown1.Visible = true;
                    cmbEstado.Visible = false;
                    //dataGridView1.DataSource = calendarioService.FindAll(p => p.Tipo == (Tipo)cmbTipo.SelectedIndex);
                    break;
                case 1:
                    numericUpDown1.Visible = true;
                    cmbEstado.Visible = false;
                    //dataGridView1.DataSource = calendarioService.FindAll(p => p.Estado == (Estado)cmbEstado.SelectedIndex);
                    break;
                case 2:
                    numericUpDown1.Visible = false;
                    cmbEstado.Visible = true;
                    break;
                //dataGridView1.DataSource = calendarioService.FindAll();
                case 3:
                    numericUpDown1.Visible = false;
                    cmbEstado.Visible = false;
                    break;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    llenarDgv(calendarioService.FindAll().Where(x=>x.Principal==numericUpDown1.Value).ToList());
                    //dataGridView1.DataSource = calendarioService.FindAll().Where(x => x.Tipo == (Tipo)cmbTipo.SelectedIndex).ToList();
                    break;
                case 1:
                    llenarDgv(calendarioService.FindAll().Where(x => x.Interes == numericUpDown1.Value).ToList());
                    dataGridView1.DataSource = calendarioService.FindAll(p => p.Estado == (Estado)cmbEstado.SelectedIndex);
                    //dataGridView1.DataSource = calendarioService.FindAll().Where(x=> x.Estado == (Estado)cmbEstado.SelectedIndex).ToList();
                    break;
                case 2:
                    llenarDgv(calendarioService.FindAll().Where(x => x.Estado == (Estado)cmbEstado.SelectedIndex).ToList());
                    //dataGridView1.DataSource = calendarioService.FindAll();
                    break;
                case 3:
                    llenarDgv(calendarioService.FindAll());
                    break;
                default:
                    MessageBox.Show("No selecciono ningun criterio");
                    return;
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFinder_SelectedIndexChanged(sender, e);
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFinder_SelectedIndexChanged(sender, e);
        }

        private void btnMostrarCalendario_Click(object sender, EventArgs e)
        {
            FrmCalendarioPago frm = new FrmCalendarioPago();
            frm.calendarioS = calendarioService;
            frm.Id = ids;
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if ((e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1))
                {
                   indexelegido  = e.RowIndex;
                    //if (guna2DataGridView1.Rows[n].Cells[0].Value.ToString() == "")
                    //{
                    //    throw new ArgumentException();
                    //}
                     ids = Convert.ToInt32(dataGridView1.Rows[indexelegido].Cells[0].Value);
                    Calendario c = calendarioService.FindAll().Find(x => x.Id == ids);
                    if (c == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }


                    btnMostrarCalendario.Visible = true;
                }
                else
                {
                    throw new Exception();
                }
            
            
        }
    }
}
