using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace NominaEmpleados
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea regresar?",
                  "Volver a atras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Lobby Lobby = new Lobby();
                Lobby.Show();
                this.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //llama al formulario Datos Empleados para insertar un nuevo empleado.
            DatosEmpleado DatosEmpleado = new DatosEmpleado();
            this.Hide();
            DatosEmpleado.Text = "Nuevo Empleado";
            DatosEmpleado.ShowDialog();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro que desea cambiar el estado del empleado " + tablaEmpleados.CurrentRow.Cells[1].Value.ToString() + "?",
                 "Cambiar estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                conexionbd.Conectar();
                if (tablaEmpleados.CurrentRow.Cells[2].Value.ToString() != "I")
                {
                    SqlCommand queryEliminar = new SqlCommand("update empleados set Estado = 'I' where Id = @Id", conexionbd.Conectar());
                    queryEliminar.Parameters.AddWithValue("@Id", tablaEmpleados.CurrentRow.Cells[0].Value.ToString());
                    queryEliminar.ExecuteNonQuery();                   
                    tablaEmpleados.DataSource = llenar_grid2();
                    Cambiar_titulo_grid2();
                    /*SqlCommand queryUsuario = new SqlCommand();
                    queryUsuario.Connection = conexionbd.Conectar();
                    queryUsuario.Parameters.Clear();
                    queryUsuario.CommandText = @"delete from Usuarios where  IdUsuario = @IdUsuario";
                    queryUsuario.Parameters.AddWithValue("@IdUsuario", tablaEmpleados.CurrentRow.Cells[0].Value.ToString());
                    queryUsuario.ExecuteNonQuery();*/
                    MessageBox.Show("Empleado inactivo", "Estado del empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqlCommand queryEliminar = new SqlCommand("update empleados set Estado = 'A' where Id = @Id", conexionbd.Conectar());
                    queryEliminar.Parameters.AddWithValue("@Id", tablaEmpleados.CurrentRow.Cells[0].Value.ToString());
                    queryEliminar.ExecuteNonQuery();
                    MessageBox.Show("Empleado Activo", "Estado del empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tablaEmpleados.DataSource = llenar_grid2();
                    Cambiar_titulo_grid2();
                    //.Show("Error 402: No se puede eliminar a los Administradores...", "¡¡Operacion Cancelada!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MainTable.Datos.Id = tablaEmpleados.CurrentRow.Cells[0].Value.ToString();
            //llama al formulario Datos Empleados Editar.
            DatosEmpleado DatosEmpleado = new DatosEmpleado();
            this.Hide();
            DatosEmpleado.Text = "Editar Empleado";
            DatosEmpleado.ShowDialog();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            tablaEmpleados.DataSource = llenar_grid2();
            Cambiar_titulo_grid2();
        }
        public DataTable llenar_grid2()
        {
            conexionbd.Conectar();
            Configuracion1 configuracion1 = new Configuracion1();
            DataTable datatable = new DataTable();
            SqlCommand query = new SqlCommand();
            query.Connection = conexionbd.Conectar();
            if ((MainTable.Datos.CheckBox1 == "true") && (MainTable.Datos.CheckBox2 == "true")) {
                query.CommandText = "Select * from empleados";
            }
            else if ((MainTable.Datos.CheckBox1 == "true") && (MainTable.Datos.CheckBox2 == "false")) {
                query.CommandText = "Select * from empleados where Estado = 'A' ";
            }
            else if ((MainTable.Datos.CheckBox1 == "false") && (MainTable.Datos.CheckBox2 == "true")) {
                query.CommandText = "Select * from empleados where Estado = 'I' ";
            }
            // string consulta = "select "
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query);
            dataAdapter.Fill(datatable);
            return datatable;
        }

        private void tablaEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Empleados_Shown(object sender, EventArgs e)
        {
            

        }
        public void Cambiar_titulo_grid2()
        {
            tablaEmpleados.Columns[1].HeaderText = "Nombre";
            tablaEmpleados.Columns[2].HeaderText = "Estado";
            tablaEmpleados.Columns[4].HeaderText = "Telefono";
            tablaEmpleados.Columns[6].HeaderText = "Categoria";
            tablaEmpleados.Columns[7].HeaderText = "Fech. Nto.";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexionbd.Conectar();

            SqlCommand queryBuscar = new SqlCommand("select Id, Cedula, Estado, TelefonoEmpleado, Correo, NombreCompleto, CodigoCategoria  from empleados as a where a.NombreCompleto like '%" + txtBuscar.Text.ToString() + "%'", conexionbd.Conectar());
            queryBuscar.Parameters.AddWithValue("@NombreCompleto", txtBuscar.Text.ToString());
            queryBuscar.ExecuteNonQuery();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryBuscar);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);
            tablaEmpleados.DataSource = datatable;
        }

        private void tablaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarEmpleados MostrarEmpleados = new MostrarEmpleados();
            MainTable.Datos.Id = tablaEmpleados.CurrentRow.Cells[0].Value.ToString();
            MainTable.Datos.activarAscenderEmpleado = 2;
            MostrarEmpleados.Show();
            this.Close();
        }
    }
}
