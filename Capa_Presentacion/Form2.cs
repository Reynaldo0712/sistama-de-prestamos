using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Listado();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        NNegocio nego = new NNegocio();
        NEntidad enti = new NEntidad();

        public void Listado()
        {
            DataTable dat = nego.N_Listado();
            dataGridView1.DataSource = dat;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                enti.Nombre = txtNombre.Text;
                enti.Apellido = txtApellido.Text;
                enti.Cedula = txtCedula.Text;
                enti.Telefono = txtTele.Text;
                enti.Fecha = dateTimePicker1.Text;
                nego.ver(enti.Nombre, enti.Apellido, enti.Cedula, enti.Telefono, enti.Fecha);
                Listado();
                borra();
                MessageBox.Show("Datos guardados");

            }
            catch(Exception ex)
            {
                MessageBox.Show("error",ex.Message);
            }
           
        }
        public void borra()
        {
            txtApellido.Clear();
            txtCedula.Clear();
            txtNombre.Clear();
            txtTele.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
