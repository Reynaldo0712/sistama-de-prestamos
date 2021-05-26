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
    public partial class Form9 : Form
    {
        NEntidad enti = new NEntidad();
        NNegocio NEGO = new NNegocio();
        ComboBox combo = new ComboBox();
        public Form9()
        {
            InitializeComponent();
            NEGO.obtener1(comboBox1);
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Listado();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            enti.Cedula = comboBox1.Text;
            NEGO.eliminar(enti.Cedula);
            comboBox1.SelectedIndex = 0;
            Listado();
        }
        public void Listado()
        {
            DataTable dat = NEGO.N_Listado2();
            dataGridView1.DataSource = dat;
        }
    }
}
