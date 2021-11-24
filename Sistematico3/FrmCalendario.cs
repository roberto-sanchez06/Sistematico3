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

        public FrmCalendario(ICalendarioService calendarioService)
        {
            this.calendarioService = calendarioService;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            FrmCuota frmCuota = new FrmCuota();
            frmCuota.calendarioService = calendarioService;
            frmCuota.ShowDialog();
            dataGridView1.DataSource = calendarioService.FindAll();
        }

        private void FrmCalendario_Load(object sender, EventArgs e)
        {
            cmbFinder.Items.AddRange(Enum.GetValues(typeof(Finder)).Cast<object>().ToArray());
            cmbEstado.Items.AddRange(Enum.GetValues(typeof(Estado)).Cast<object>().ToArray());
            cmbTipo.Items.AddRange(Enum.GetValues(typeof(Tipo)).Cast<object>().ToArray());
        }

        private void cmbFinder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    cmbTipo.Visible = true;
                    cmbEstado.Visible = false;
                    //dataGridView1.DataSource = calendarioService.FindAll(p => p.Tipo == (Tipo)cmbTipo.SelectedIndex);
                    break;
                case 1:
                    cmbTipo.Visible = false;
                    cmbEstado.Visible = true;
                    //dataGridView1.DataSource = calendarioService.FindAll(p => p.Estado == (Estado)cmbEstado.SelectedIndex);
                    break;
                case 2:
                    cmbTipo.Visible = false;
                    cmbEstado.Visible = false;
                    //dataGridView1.DataSource = calendarioService.FindAll();
                    break;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    dataGridView1.DataSource = calendarioService.FindAll(p => p.Tipo == (Tipo)cmbTipo.SelectedIndex);
                    //dataGridView1.DataSource = calendarioService.FindAll().Where(x => x.Tipo == (Tipo)cmbTipo.SelectedIndex).ToList();
                    break;
                case 1:
                    dataGridView1.DataSource = calendarioService.FindAll(p => p.Estado == (Estado)cmbEstado.SelectedIndex);
                    //dataGridView1.DataSource = calendarioService.FindAll().Where(x=> x.Estado == (Estado)cmbEstado.SelectedIndex).ToList();
                    break;
                case 2:
                    dataGridView1.DataSource = calendarioService.FindAll();
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
    }
}
