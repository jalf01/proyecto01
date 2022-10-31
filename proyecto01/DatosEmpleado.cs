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
    public partial class DatosEmpleado : Form
    {
        public DatosEmpleado()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea regresar?",
                  "Volver a atras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) {
                Empleados Empleados = new Empleados();
                Empleados.Show();
                this.Close();
            } 
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Empleados Empleados = new Empleados();
            int index = 0;
            if (comBoxCargo.SelectedIndex > -1)
            {
                SqlCommand queryVerificar = new SqlCommand();
                queryVerificar.Connection = conexionbd.Conectar();
                queryVerificar.CommandText = @"	select CodigoCategoria from categoria where Cargo = @Cargo";
                queryVerificar.Parameters.AddWithValue("@Cargo", comBoxCargo.Text);
                SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
                if (dataReader0.Read())
                {
                    index = dataReader0.GetInt32(0);
                }
                if (this.Text == "Nuevo Empleado")
                {
                    conexionbd.Conectar();
                    string queryText = @"insert into empleados (Id, Cedula, TelefonoEmpleado, Correo, NombreCompleto, CodigoCategoria, 
                                       FechaNac, estado) values ((select coalesce(MAX(Id),1)+1 from empleados), @Cedula, @TelefonoEmpleado,
                                       @Correo, @NombreCompleto, @CodigoCategoria, @FechaNac, 'A');";  //(select coalesce(MAX(CodigoCategoria),1)+1 from empleados)
                    SqlCommand query = new SqlCommand(queryText, conexionbd.Conectar());
                    query.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                    query.Parameters.AddWithValue("@TelefonoEmpleado", txtTelefono.Text);
                    query.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    query.Parameters.AddWithValue("@NombreCompleto", txtNombre.Text);
                    query.Parameters.AddWithValue("@CodigoCategoria", index);
                    //  query.Parameters.AddWithValue("@Sueldo", txtSueldo.Text);
                    query.Parameters.AddWithValue("@FechaNac", dateFecha.Value);
                    try
                    {
                        query.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al intentar guardar los datos." + ex);
                    }
                    MessageBox.Show("Se han guardado los datos del empleado", "Datos almacenados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCedula.Clear();
                    txtNombre.Clear();
                    txtTelefono.Clear();
                    txtCorreo.Clear();
                    txtCedula.Focus();
                    Empleados.Show();
                    this.Close();
                }
                else
                {
                    conexionbd.Conectar();
                    string queryText = @"update empleados set Cedula = @Cedula, TelefonoEmpleado = @TelefonoEmpleado, Correo = @Correo, 
                                       NombreCompleto = @NombreCompleto, CodigoCategoria = @CodigoCategoria, FechaNac = @FechaNac where Id = @Id";
                    SqlCommand query = new SqlCommand(queryText, conexionbd.Conectar());
                    query.Parameters.AddWithValue("@Id", lbId.Text);
                    query.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                    query.Parameters.AddWithValue("@TelefonoEmpleado", txtTelefono.Text);
                    query.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    query.Parameters.AddWithValue("@NombreCompleto", txtNombre.Text);
                    query.Parameters.AddWithValue("@CodigoCategoria", index);
                    //  query.Parameters.AddWithValue("@Sueldo", txtSueldo.Text);
                    query.Parameters.AddWithValue("@FechaNac", dateFecha.Value);


                    try
                    {
                        query.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al salvar la  base de datos." + ex);
                    }                 
                    MessageBox.Show("Datos editados correctamente...", "Datos almacenados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Empleados.Show();
                    this.Close();
                }
            }
            else{
                MessageBox.Show("Dato Obligatoria", "Error 403: El cargo del empleado no esta seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DatosEmpleado_Enter(object sender, EventArgs e)
        {

        }

        private void DatosEmpleado_Shown(object sender, EventArgs e)
        {
            if (this.Text == "Editar Empleado")
            {
                if (MainTable.Datos.Id != "") {
                    lbId.Text = MainTable.Datos.Id.ToString();
                    conexionbd.Conectar();
                    SqlCommand queryEmpleado = new SqlCommand("select Id, Cedula, TelefonoEmpleado, Correo, NombreCompleto, CodigoCategoria, FechaNac, estado from empleados as a where a.Id = @Id", conexionbd.Conectar());
                    queryEmpleado.Parameters.AddWithValue("@Id", MainTable.Datos.Id.ToString());
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryEmpleado);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    txtCedula.Text = dataTable.Rows[0][1].ToString();
                    txtTelefono.Text = dataTable.Rows[0][2].ToString();
                    txtCorreo.Text = dataTable.Rows[0][3].ToString();
                    txtNombre.Text = dataTable.Rows[0][4].ToString();
                    dateFecha.Text = dataTable.Rows[0][6].ToString();

                    SqlCommand queryCategoria = new SqlCommand("select CodigoCategoria, Cargo, SueldoBruto from categoria where CodigoCategoria = @CodigoCategoria", conexionbd.Conectar());
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(queryCategoria);
                    DataTable dataTable2 = new DataTable();
                    queryCategoria.Parameters.AddWithValue("@CodigoCategoria", dataTable.Rows[0][5].ToString());
                    dataAdapter2.Equals(queryCategoria);
                    dataAdapter2.Fill(dataTable2);
                    if (dataTable.Rows[0][7].ToString() != "I") {
                        comBoxCargo.Items.Clear();
                        comBoxCargo.Items.Add(dataTable2.Rows[0][1].ToString());
                        comBoxCargo.SelectedIndex = 0;
                        comBoxSueldo.Items.Clear();
                        comBoxSueldo.Items.Add(dataTable2.Rows[0][2].ToString());
                        comBoxSueldo.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("El empleado no esta activo en la empresa.", "Error 403: Parametros invalidos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Empleados Empleados = new Empleados();
                        Empleados.Show();
                        this.Close();
                    }
                }            
            }
            SqlCommand queryCargos = new SqlCommand();
            queryCargos.Connection = conexionbd.Conectar();
            queryCargos.CommandText = @"select CodigoCategoria, Cargo, SueldoBruto from categoria where estado = 'A'";
            SqlDataReader dataReaderCargo = queryCargos.ExecuteReader();
            if (dataReaderCargo.HasRows)
            {
                comBoxCargo.Items.Clear();
                comBoxSueldo.Items.Clear();
                while (dataReaderCargo.Read())
                {
                    if (dataReaderCargo.GetInt32(0) != 0)
                    {
                        comBoxSueldo.Items.Add(dataReaderCargo.GetDecimal(2));
                        comBoxCargo.Items.Add(dataReaderCargo.GetString(1));
                        
                    }
                    
                }
            }
            //MessageBox.Show(comBoxCargo.SelectedIndex.ToString());
        }

        private void comBoxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comBoxSueldo.SelectedIndex = comBoxCargo.SelectedIndex;
        }

        private void comBoxCargo_Click(object sender, EventArgs e)
        {
            if (comBoxCargo.SelectedIndex > -1)
            {
                comBoxSueldo.SelectedIndex = comBoxCargo.SelectedIndex;
            }
        }
    }
}
