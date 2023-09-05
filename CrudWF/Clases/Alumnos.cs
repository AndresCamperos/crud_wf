using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWF.Clases
{
    internal class Alumnos
    {
        public void MostrarAlumnos( DataGridView dataGridView)
        {
			try
			{
				Conexion conexion = new Conexion();
                string query = "SELECT * FROM alumnos";

                dataGridView.DataSource = null;
				MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conexion.EstablecerConexion());
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                conexion.CerrarConexion();


            }
			catch (Exception ex)
			{
                MessageBox.Show("Error al mostrar los alumnos" + ex.Message);
            }
        }

        public void GuardarAlumnos(TextBox nombre,TextBox apellido)
        {
            try
            {
                Conexion conexion = new Conexion();
                string query = "INSERT INTO alumnos (nombre,apellido)" +
                    "VALUES ('" + nombre.Text + "','" + apellido.Text + "');";

                
                MySqlCommand sqlCommand = new MySqlCommand(query,conexion.EstablecerConexion());
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                MessageBox.Show("Guardado con exito");
                while (reader.Read()) { }
                conexion.CerrarConexion();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los alumnos" + ex.Message);
            }
        }

        public void SeleccionarAlumnos(DataGridView tablaAlumnos, TextBox id, TextBox nombre, TextBox apellido)
        {
            try
            {
                id.Text = tablaAlumnos.CurrentRow.Cells[0].Value.ToString();
                nombre.Text = tablaAlumnos.CurrentRow.Cells[1].Value.ToString();
                apellido.Text = tablaAlumnos.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar los alumnos" + ex.Message);
            }
        }
        public void ModificarAlumnos(TextBox id, TextBox nombre, TextBox apellido)
        {
            try
            {
                Conexion conexion = new Conexion();
                string query = "UPDATE alumnos SET nombre='" + nombre.Text + "', apellido='" + apellido.Text + "' WHERE id ='" + id.Text + "';";


                MySqlCommand sqlCommand = new MySqlCommand(query, conexion.EstablecerConexion());
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                MessageBox.Show("Modificado con exito");
                while (reader.Read()) { }
                conexion.CerrarConexion();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar los alumnos" + ex.Message);
            }
        }
        public void EliminarAlumnos(TextBox id)
        {
            try
            {
                Conexion conexion = new Conexion();
                string query = "DELETE FROM alumnos WHERE id ='" + id.Text + "';";


                MySqlCommand sqlCommand = new MySqlCommand(query, conexion.EstablecerConexion());
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                MessageBox.Show("Eliminado con exito");
                while (reader.Read()) { }
                conexion.CerrarConexion();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar los alumnos" + ex.Message);
            }
        }
    }
}

