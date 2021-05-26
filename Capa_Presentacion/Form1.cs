using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace Capa_Presentacion
{ 
    public partial class Sistema_Prestamos : Form
    {
        public Sistema_Prestamos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listado();
            customize();
        }

        NNegocio nego = new NNegocio();
        NEntidad enti = new NEntidad();

        public void Listado()
        {
            //DataTable dat = nego.N_Listado();
            //dataGridView1.DataSource = dat;
        }
        #region Funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION 
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
       

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;
        private void BtnMaximizar_Click(object sender, EventArgs e)
        {

            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            BtnMaximizar.Visible = false;
            BtnMinimizar.Visible = true;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

        }
      
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            BtnMaximizar.Visible = true;
            BtnMinimizar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;

                formulario.Show();

            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }



        }
       



        public void customize()
        {
            ControlClientes.Visible = false;
            ControlPrestamos.Visible = false;

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ShowSubMenu(ControlClientes);
        }

        
        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form3>();
        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form4>();
        }

        private void BtnEli_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form5>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowSubMenu(ControlPrestamos);
        }
        private void btnPres_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form6>();
        }

        private void BtnBusc_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form7>();
        }

        private void btnModiPres_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form8>();
        }

        private void btneliPres_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form9>();
        }

        private void BtnRegistro_Click_1(object sender, EventArgs e)
        {
            hideSubmenu();
            AbrirFormulario<Form2>();
        }

        private void hideSubmenu()
        {
            if(ControlClientes.Visible==true)
              ControlClientes.Visible = false;        
            if (ControlPrestamos.Visible == true)        
               ControlPrestamos.Visible = false;
          
        }

        private void ShowSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }



    }

}