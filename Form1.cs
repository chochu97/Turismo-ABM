using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIP
{
    public partial class Form1 : Form
    {
        private EntradaBusiness entradaBusiness = new EntradaBusiness();
        private TipoTurismoBusiness turismobusy = new TipoTurismoBusiness();
        public Form1()
        {
            InitializeComponent();
            ActualizarGrilla();
            ActualizarCombo();
        }

        public void ActualizarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = entradaBusiness.GetEntradas();
        }

        public void ActualizarCombo()
        {
            comboTurismo.DataSource = null;
            comboTurismo.DataSource = turismobusy.GetTurismos();

            comboTurismo.DisplayMember = "nombre";
            comboTurismo.ValueMember = "id_tipoturismo";
            comboTurismo.DisplayMember = "nombre";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Entrada entrada = new Entrada();
            entrada.id_tipoturismo = Convert.ToInt32(comboTurismo.SelectedValue);
            entrada.dni = Convert.ToInt32(txtDNI.Text);
            entrada.monto = Convert.ToDouble(txtMonto.Text);
            entrada.fecha_registro = DateTime.Now;
            entrada.fecha_validez = dateTimePicker1.Value;

            try
            {
                entradaBusiness.GuardarEntrada(entrada);
                ActualizarGrilla();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                entradaBusiness.EliminarEntrada(Convert.ToInt32(txtIDEliminar.Text));
                ActualizarGrilla();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                entradaBusiness.ModificarEntrada(Convert.ToInt32(txtIDMod.Text), dateTimePicker2.Value);
                ActualizarGrilla();
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
