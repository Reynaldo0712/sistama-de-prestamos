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
    public partial class Form7 : Form
    {
        ComboBox combo = new ComboBox();
        NNegocio NEGO = new NNegocio();
        NEntidad enti = new NEntidad();
        public Form7()
        {
            InitializeComponent();
            NEGO.obtener1(comboBox1);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            Listado();


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            enti.Cedula = comboBox1.Text;
            NEGO.buscarPres(enti.Cedula);
            comboBox1.SelectedIndex = 0;
            mostrar();
        }


        public void mostrar()
        {
            DataTable  dat= NEGO.buscarPres(enti.Cedula);
            dataGridView1.DataSource = dat;
        }

        public void Listado()
        {
            DataTable dat = NEGO.N_Listado2();
            dataGridView1.DataSource = dat;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
