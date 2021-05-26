using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
using System.Data;
using System.Windows.Forms;

namespace Capa_Negocio
{
    public class NNegocio
    {
        NDatos objen = new NDatos();


        public DataTable N_Listado()
        {
            return objen.Mostrar();
        }


        public void ver(string nombre, string apellido, string cedula, string telefono, string fecha)
        {

            objen.Guardar(nombre, apellido, cedula, telefono, fecha);

        }

      
        public DataTable busc(int id)
        {
           return objen.Buscar(id);
        }

        public void ModificarDatos(string nombre, string apellido, string cedula, string telefono, string fecha,int id)
        {

            objen.Modificar(nombre, apellido, cedula, telefono, fecha, id);

        }
        
        public void borrar(int id)
        {
            objen.EliminarDatos(id);

        }


        public void entra(string nombre, string apellido, string cedula, string telefono, decimal monto, string interes,DateTime fecha, DateTime tiempo,string deuda, decimal cuota)
        {


            objen.entrar(nombre, apellido, cedula, telefono, monto, interes,fecha ,tiempo,deuda,cuota);


        }


          public void obtener(ComboBox combo)
          {
            objen.Seleccionar(combo); 
          
          }

          public string[] obtener2(string cedula)
         {
            return objen.captarDatos(cedula);
         }

        public DataTable N_Listado2()
        {
            return objen.Mostrar2();
        }

       public void obtener1(ComboBox combo)
        {

            objen.Seleccionar2(combo);


        }

        public DataTable buscarPres(string cedula)
        {
            return objen.BuscarPres(cedula);
        }

       public DataTable DatosPres()
        {
            return objen.BuscarPresDatos();
        }

        public void modificarPres(string cedula, decimal monto)
        {
            objen.ModificarPres(cedula,monto);
        }


        public DataTable prueba(string cedula)
        {
            return objen.BuscarModifi(cedula);
        }

        public void eliminar(string cedula)
        {
            objen.EliminarPres(cedula);
        }
    }
}
