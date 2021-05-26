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
      
    public partial class Form5 : Form
    {
        NEntidad enti = new NEntidad();
        NNegocio NEGO = new NNegocio();
        public Form5()
        {
            InitializeComponent();
            Listado();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            try
            {
                enti.Id = int.Parse(txtId.Text);
                NEGO.borrar(enti.Id);
                Listado();
                txtId.Clear();
            }
            catch
            {
                MessageBox.Show("El id ingresado no es valido");
            }
        }

        public void Listado()
        {
            DataTable dat = NEGO.N_Listado();
            dataGridView1.DataSource = dat;
        }
    }
}
