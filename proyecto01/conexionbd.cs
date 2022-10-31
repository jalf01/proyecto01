
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NominaEmpleados
{
    class conexionbd
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection("server = D19B9590; database = nominadb; integrated security = true;");
            conexion.Open();
        return conexion;
        }
  /*  public conexionbd()
        {
            Conectar.ConnectionString = cadenaConexion;
        }
        public void abrir()
        {
            try
            {
                Conectar.Open();
                Console.WriteLine("Conexión exitosa");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la BD "+ex.Message);
            }
        }
        public void cerrar()
        {
            Conectar.Close();

        }
        */
     
    }
}
