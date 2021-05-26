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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            Listado();

        }
        NNegocio nego = new NNegocio();
        NEntidad enti = new NEntidad();

        public void Listado()
        {
            DataTable dat = nego.N_Listado();
            dataGridView1.DataSource = dat;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                enti.Id = int.Parse(txtBuscar.Text);
                nego.busc(enti.Id);
                buscar();
                txtBuscar.Clear();
            }
           catch(Exception ex)
            {
                MessageBox.Show($"Error el valor ingresado " +
                    "no es numerico", ex.Message);
            }


        }
      
        public void buscar()
        {
            DataTable dat1 = nego.busc(enti.Id);
            dataGridView1.DataSource = dat1;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
