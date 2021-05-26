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
    public partial class Form4 : Form
    {
        NEntidad enti = new NEntidad();
        NNegocio nego = new NNegocio();
        public Form4()
        {
            InitializeComponent();
            Listado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {   try
            {
                enti.Nombre = txtNombre.Text;
                enti.Apellido = txtApellido.Text;
                enti.Cedula = txtCedula.Text;
                enti.Telefono = txtTele.Text;
                enti.Fecha = dateTimePicker1.Text;
                enti.Id = int.Parse(txtId.Text);
                modificardatos();
                Listado();
                limpiarCampos();
                MessageBox.Show("Datos actualizados  con exito");

            }
            catch
            {
                MessageBox.Show("El id ingresado no existe o no es valido");
            }

             
        }
        
        public void modificardatos()
        {

            nego.ModificarDatos(enti.Nombre, enti.Apellido, enti.Cedula, enti.Telefono, enti.Fecha,enti.Id);
          

        }

        public void Listado()
        {
            DataTable dat = nego.N_Listado();
            dataGridView1.DataSource = dat;
        }

        public void limpiarCampos()
        {
            txtApellido.Clear();
            txtCedula.Clear();
            txtId.Clear();
            txtNombre.Clear();
            txtTele.Clear();

        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
