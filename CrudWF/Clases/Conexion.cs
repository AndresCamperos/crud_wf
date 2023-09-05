using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWF.Clases
{
    internal class Conexion
    {
        MySqlConnection conex = new MySqlConnection();

        static string Servidor = "localhost";
        static string Puerto = "3306";
        static string Usuario ="root";
        static string Bd = "estudiantes";
        static string Password = "";

        string cadenaDeConexion = $"server={Servidor};port={Puerto};user id={Usuario};password={Password}; database={Bd}";

        public MySqlConnection EstablecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaDeConexion;
                conex.Open();
                //MessageBox.Show("conexion exitosa");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Sin conexion" + ex.Message);
            }
            return conex;
        }
        public void CerrarConexion()
        {
            conex.Close();
        }
    }

}
