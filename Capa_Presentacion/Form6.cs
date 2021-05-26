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
    public partial class Form6 : Form
    {
        NNegocio nego = new NNegocio();
        NEntidad enti = new NEntidad();
        ComboBox combo = new ComboBox();
        public Form6()
        {
            InitializeComponent();
            nego.obtener(comboBox1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                enti.Fecha_inicio = Convert.ToDateTime(dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                enti.Fecha_final = Convert.ToDateTime(dateTimePicker2.Value.Date.ToString("yyyy-MM-dd"));
                enti.Nombre = labelN.Text;
                enti.Apellido = labelA.Text;  
                enti.Telefono = labelTE.Text;
                enti.Cedula = labelC.Text;
                enti.Monto = decimal.Parse(textMonto.Text);
                enti.Interes = txtInteres.Text;
                enti.Deudad = txtTotal.Text;
                enti.Cuota = decimal.Parse(txtCuota.Text);
                nego.entra(enti.Nombre, enti.Apellido, enti.Cedula, enti.Telefono, enti.Monto, enti.Interes, enti.Fecha_inicio, enti.Fecha_final, enti.Deudad, enti.Cuota);
                borrar();
                Listado();
                MessageBox.Show("Datos guardados");

            }
            catch
            {
                MessageBox.Show("Error");
            }








        }


        public void Listado()
        {
            DataTable dat = nego.DatosPres();
            dataGridView1.DataSource = dat;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            Listado();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(comboBox1.SelectedIndex >0)
            {

                string[] valores = nego.obtener2(comboBox1.Text);
                labelN.Text = valores[1];
                labelA.Text = valores[2];
                labelC.Text = valores[3];
                labelTE.Text = valores[4];

                labelN.Visible = true;
                labelA.Visible = true;
                labelC.Visible = true;
                labelTE.Visible = true;


            }


           




        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void borrar()
        {
           
            
            labelN.ResetText();
            labelA.ResetText();
            labelC.ResetText();
            labelTE.ResetText();
            txtInteres.Clear();
            textMonto.Clear();
            txtTotal.Clear();
            txttiempo.Clear();
            txtCuota.Clear();
            comboBox1.SelectedIndex = 0;
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcular();
        }
        public void calcular()
        {
            decimal monto = Convert.ToDecimal(textMonto.Text);
            decimal tasa = Convert.ToDecimal(txtInteres.Text);
            tasa = tasa / 100;
            decimal total = monto + (monto * tasa);
            int tiempo = Convert.ToInt32(txttiempo.Text);


            if (cbxtiempo.Text == "Dias")
            {
                dateTimePicker2.Value = DateTime.Today.AddDays(tiempo);
            }
            else if (cbxtiempo.Text == "Meses")
            {

                dateTimePicker2.Value = DateTime.Today.AddMonths(tiempo);
            }
            if (cbxtiempo.Text == "Años")
            {
                dateTimePicker2.Value = DateTime.Today.AddYears(tiempo);
            }

            txtCuota.Text = Convert.ToString(Math.Truncate (total / tiempo));
            txtTotal.Text = Convert.ToString(Math.Truncate (total));

   





        }
    }
}
