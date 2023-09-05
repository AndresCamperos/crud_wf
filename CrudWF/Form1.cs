using CrudWF.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Alumnos alumnos = new Alumnos();
            alumnos.MostrarAlumnos(dgvAlumnos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            conexion.EstablecerConexion();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.GuardarAlumnos(txtNombre, txtApellido);
            alumnos.MostrarAlumnos(dgvAlumnos);
        }

        private void dgvAlumnos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.SeleccionarAlumnos(dgvAlumnos, txtId, txtNombre, txtApellido);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.ModificarAlumnos(txtId, txtNombre, txtApellido);
            alumnos.MostrarAlumnos(dgvAlumnos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Alumnos alumnos = new Alumnos();
            alumnos.EliminarAlumnos(txtId);
            alumnos.MostrarAlumnos(dgvAlumnos);
        }
    }
}
