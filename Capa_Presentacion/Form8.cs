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
    public partial class Form8 : Form
    {
        
        NNegocio NEGO = new  NNegocio();
        ComboBox combo = new ComboBox();
        NEntidad enti = new NEntidad();
        public Form8()
        {
            InitializeComponent();
            NEGO.obtener1(comboBox1);
           
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
            Listado();


        }

        

        public void Listado()
        {
            DataTable dat = NEGO.N_Listado2();
            dataGridView1.DataSource = dat;
        }

        private void btnModi_Click(object sender, EventArgs e)
        {

            try
            {
                enti.Monto = decimal.Parse(txtMod.Text);
                enti.Cedula = comboBox1.Text;
                NEGO.modificarPres(enti.Cedula,enti.Monto);
                Listado();
                MessageBox.Show("Datos modificado");
                comboBox1.SelectedIndex = 0;
                txtMod.Clear();


            }
            catch
            {
                MessageBox.Show("El valor no es valido");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            enti.Cedula = comboBox1.Text;
            NEGO.prueba(enti.Cedula);
            listar();

        }

        public void listar()
        {
            DataTable dat1 = NEGO.prueba(enti.Cedula);
            dataGridView1.DataSource = dat1;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
