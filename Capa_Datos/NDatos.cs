using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class NDatos
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconex"].ConnectionString);

        #region cliente
        public DataTable Mostrar()
        {

            SqlCommand comando = new SqlCommand("Registro", con);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable dat = new DataTable();

            data.Fill(dat);

            return dat;



        }

        public void Guardar(string nombre, string apellido, string cedula, string telefono, string fecha)
        {



            con.Open();

            SqlCommand comando = new SqlCommand("Registro1", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@nombre", nombre));
            comando.Parameters.Add(new SqlParameter("@apellido", apellido));
            comando.Parameters.Add(new SqlParameter("@cedula", cedula));
            comando.Parameters.Add(new SqlParameter("@telefono", telefono));
            comando.Parameters.Add(new SqlParameter("@fecha", fecha));
            comando.ExecuteNonQuery();
            con.Close();



        }

        public DataTable Buscar(int id)
        {



            con.Open();
            SqlCommand comando = new SqlCommand("Buscar", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", id));

            comando.ExecuteNonQuery();

            SqlDataAdapter data1 = new SqlDataAdapter(comando);

            DataTable dat1 = new DataTable();

            data1.Fill(dat1);
            con.Close();
            return dat1;




        }


        public void Modificar(string nombre, string apellido, string cedula, string telefono, string fecha, int id)
        {



            con.Open();
            SqlCommand comando = new SqlCommand("Modificar", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", nombre));
            comando.Parameters.Add(new SqlParameter("@Apellido", apellido));
            comando.Parameters.Add(new SqlParameter("@Cedula", cedula));
            comando.Parameters.Add(new SqlParameter("@Telefono", telefono));
            comando.Parameters.Add(new SqlParameter("@Fecha", fecha));
            comando.Parameters.Add(new SqlParameter("@Id", id));
            comando.ExecuteNonQuery();
            con.Close();



        }


        public void EliminarDatos(int Id)
        {
            con.Open();
            SqlCommand comando = new SqlCommand("Eliminar", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            comando.ExecuteNonQuery();
            con.Close();



        }

        #endregion


        public void entrar(string nombre, string apellido, string cedula, string telefono, decimal monto, string interes, DateTime fecha, DateTime tiempo, string deudad, decimal cuota)
        {


            con.Open();

            SqlCommand comando = new SqlCommand("prestamosRegistro", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Nombre", nombre));
            comando.Parameters.Add(new SqlParameter("@Apellido", apellido));
            comando.Parameters.Add(new SqlParameter("@Cedula", cedula));
            comando.Parameters.Add(new SqlParameter("@Telefono", telefono));
            comando.Parameters.Add(new SqlParameter("@Monto", monto));
            comando.Parameters.Add(new SqlParameter("@Interes", interes));
            comando.Parameters.Add(new SqlParameter("@Fecha", fecha));
            comando.Parameters.Add(new SqlParameter("@tiempo", tiempo));
            comando.Parameters.Add(new SqlParameter("@Deuda", deudad));
            comando.Parameters.Add(new SqlParameter("@Cuota", cuota));



            comando.ExecuteNonQuery();
            con.Close();



        }


        public void Seleccionar(ComboBox combo)
        {
            combo.Items.Clear();
            con.Open();
            SqlCommand comando = new SqlCommand("Registrar2", con);
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                combo.Items.Add(dr[3].ToString());
            }
            con.Close();
            combo.Items.Insert(0, "Seleccione la Cedula del Cliente");
            combo.SelectedIndex = 0;
        }
        public string[] captarDatos(string Cedula)
        {
            con.Open();
            SqlCommand comando = new SqlCommand("captar", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@cedula", Cedula));
            SqlDataReader dr = comando.ExecuteReader();
            string[] resultado = null;
            while (dr.Read())
            {
                string[] valores =
                {
                    dr[0].ToString(),
                    dr[1].ToString(),
                    dr[2].ToString(),
                    dr[3].ToString(),
                    dr[4].ToString()

                };
                resultado = valores;
            }
            con.Close();
            return resultado;
        }


        public DataTable Mostrar2()
        {

            SqlCommand comando = new SqlCommand("MOSTRAR", con);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter data = new SqlDataAdapter(comando);

            DataTable dat = new DataTable();

            data.Fill(dat);

            return dat;



        }

        public void Seleccionar2(ComboBox combo)
        {
            combo.Items.Clear();
            con.Open();
            SqlCommand comando = new SqlCommand("buscarPrestamo1", con);
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                combo.Items.Add(dr[3].ToString());
            }
            con.Close();
            combo.Items.Insert(0, "Seleccione la Cedula del Cliente");
            combo.SelectedIndex = 0;
        }


        public DataTable BuscarPres(string cedula)
        {



            con.Open();
            SqlCommand comando = new SqlCommand("buscarPrestamos", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@cedula", cedula));

            comando.ExecuteNonQuery();

            SqlDataAdapter data1 = new SqlDataAdapter(comando);

            DataTable dat1 = new DataTable();

            data1.Fill(dat1);
            con.Close();
            return dat1;




        }
        public DataTable BuscarPresDatos()
        {



            con.Open();
            SqlCommand comando = new SqlCommand("buscarPrestamo1", con);
            comando.CommandType = CommandType.StoredProcedure;


            comando.ExecuteNonQuery();

            SqlDataAdapter data1 = new SqlDataAdapter(comando);

            DataTable dat1 = new DataTable();

            data1.Fill(dat1);
            con.Close();
            return dat1;



        }

        public void ModificarPres(string cedula ,decimal deuda)
        {
            con.Open();
          
            SqlCommand comando = new SqlCommand("PrestamosUpdate", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@cedula", cedula));
            comando.Parameters.Add(new SqlParameter("@deuda", deuda));

            comando.ExecuteNonQuery();
            con.Close();
        }


        public DataTable BuscarModifi(string cedula)
        {


            con.Open();
            SqlCommand comando = new SqlCommand("Busqueda", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@cedula", cedula));

            comando.ExecuteNonQuery();

            SqlDataAdapter data1 = new SqlDataAdapter(comando);

            DataTable dat1 = new DataTable();

            data1.Fill(dat1);
            con.Close();
            return dat1;


        }
        public DataTable EliminarPres(string cedula)
        {


            con.Open();
            SqlCommand comando = new SqlCommand("EliminarPres", con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@cedula", cedula));

            comando.ExecuteNonQuery();

            SqlDataAdapter data1 = new SqlDataAdapter(comando);

            DataTable dat1 = new DataTable();

            data1.Fill(dat1);
            con.Close();
            return dat1;


        }
    }
}