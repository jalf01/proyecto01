using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace NominaEmpleados
{
    public partial class Configuracion1 : Form
    {
        string codigo = "";
        public Configuracion1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MainTable.Datos.llave == 1)
            {
                conexionbd.Conectar();

                if (string.IsNullOrEmpty(txtNombreEmpresa.Text))
                {
                    MessageBox.Show("Debe llenar todos los campos", "Campo NombreEmpresa Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombreEmpresa.Focus();
                }
                else if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    MessageBox.Show("Debe llenar todos los campos", "Campo Direccion Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDireccion.Focus();
                }
                else if (string.IsNullOrEmpty(txtCorreo.Text))
                {
                    MessageBox.Show("Debe llenar todos los campos", "Campo Correo Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Focus();
                }
                else if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("Debe llenar todos los campos", "Campo Telefono Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefono.Focus();
                }
                else if (string.IsNullOrEmpty(txtRNC.Text))
                {
                    MessageBox.Show("Debe llenar todos los campos", "Campo RNC Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRNC.Focus();
                }
                else
                {
                    SqlCommand queryConfiguracion = new SqlCommand();
                    queryConfiguracion.Connection = conexionbd.Conectar();
                    queryConfiguracion.CommandText = @"update configuracion set NombreEmpresa = @NombreEmpresa, 
                                             Direccion = @Direccion, TelefonoEmpresa = @TelefonoEmpresa,
                                             RNC = @RNC, AFPOrg = @AFPOrg, Correo = @Correo, SFSOrg = @SFSOrg, INFOTEP = @INFOTEP where Id = 1";

                    queryConfiguracion.Parameters.AddWithValue("@NombreEmpresa", txtNombreEmpresa.Text);
                    queryConfiguracion.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    queryConfiguracion.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    queryConfiguracion.Parameters.AddWithValue("@TelefonoEmpresa", txtTelefono.Text);
                    queryConfiguracion.Parameters.AddWithValue("@RNC", txtRNC.Text);
                    queryConfiguracion.Parameters.AddWithValue("@AFPOrg", txtAFPOrg.Text);
                    queryConfiguracion.Parameters.AddWithValue("@SFSOrg", txtSFSOrg.Text);
                    queryConfiguracion.Parameters.AddWithValue("@INFOTEP", txtInfotepOrg.Text);
                    MessageBox.Show("Datos actualizados correctamente", "Datos de la configuracion actualizados");
                    queryConfiguracion.ExecuteNonQuery();
                    DialogResult r = MessageBox.Show("Los datos almacenados correctamente. El programa se reiniciara para realizar los cambios",
                      "Salir de la aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (r == DialogResult.OK) Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Favor Completar la pestaña Seguridad Social.");
                tabControl1.TabIndex = 3;
                tabControl1.SelectedIndex = 3;
            }            
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

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void Configuracion1_Shown(object sender, EventArgs e)
        {
            MainTable.Datos.activar = 1;
            TablaConfiguracion.DataSource = llenar_grid2();
            Cambiar_titulo_grid2();
            TablaUsuario.DataSource = llenar_grid4();
            Cambiar_titulo_grid4();

            if (MainTable.Datos.firstRun != "Default")
            {
                llaner_campos();
                SqlCommand queryDatoEmpresa = new SqlCommand();
                queryDatoEmpresa.Connection = conexionbd.Conectar();
                queryDatoEmpresa.CommandText = @"select NombreEmpresa, Direccion, TelefonoEmpresa, rnc, AFPOrg, correo, INFOTEP, SFSOrg, SFSEmp, AFPEmp from configuracion";
                //queryDatoEmpresa.Parameters.AddWithValue("@CodigoCategoria", TablaConfiguracion.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader dataReader0 = queryDatoEmpresa.ExecuteReader();
                if (dataReader0.Read())
                {
                    txtCorreo.Text = dataReader0.GetString(5);
                    txtNombreEmpresa.Text = dataReader0.GetString(0);
                    txtDireccion.Text = dataReader0.GetString(1);
                    txtTelefono.Text = dataReader0.GetString(2);
                    txtRNC.Text = dataReader0.GetString(3);
                    txtAFPOrg.Text = dataReader0.GetDecimal(4).ToString();
                    txtInfotepOrg.Text = dataReader0.GetDecimal(6).ToString();
                    txtSFSOrg.Text = dataReader0.GetDecimal(7).ToString();
                    txtSFS.Text = dataReader0.GetDecimal(8).ToString();
                    txtAFP.Text = dataReader0.GetDecimal(9).ToString();
                    MainTable.Datos.llave = 1;
                }
            }
            else
            {
                MessageBox.Show("Favor Completar la pestaña Seguridad Social.");
                tabControl1.TabIndex = 3;
                tabControl1.SelectedIndex = 3;
                MainTable.Datos.llave = 0;
            }
        }
        public void Cambiar_titulo_grid2()
        {
            TablaConfiguracion.Columns[0].HeaderText = "No. Categoria";
            TablaConfiguracion.Columns[2].HeaderText = "Sueldo Bruto";
        }
        public void Cambiar_titulo_grid4()
        {
            TablaUsuario.Columns[0].HeaderText = "id";
            TablaUsuario.Columns[1].HeaderText = "Nombre";
        }
        public DataTable llenar_grid2()
        {
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryCategoria = new SqlCommand("select CodigoCategoria, Cargo, SueldoBruto, estado from categoria", conexionbd.Conectar());
            // string consulta = "select "
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryCategoria);
            dataAdapter.Fill(datatable);
            return datatable;
        }

        public DataTable llenar_grid3()
        {
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryAddAdm = new SqlCommand(@"select a.Id, a.NombreCompleto
                                                    from categoria as c
                                                    inner join empleados as a on c.CodigoCategoria = a.CodigoCategoria
                                                    where a.Estado = 'A'", conexionbd.Conectar());
            // string consulta = "select "
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryAddAdm);
            dataAdapter.Fill(datatable);
            return datatable;
        }

        public DataTable llenar_grid4()
        {
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryAddAdm = new SqlCommand(@"select a.IdUsuario, b.NombreCompleto, a.Usuario from  Usuarios a
                                                    inner join empleados as b on b.Id = a.IdUsuario", conexionbd.Conectar());
            // string consulta = "select "
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryAddAdm);
            dataAdapter.Fill(datatable);
            return datatable;
        }

        public void llaner_campos()
        {
            SqlCommand queryCommand = new SqlCommand();            
            queryCommand.Connection = conexionbd.Conectar();       
            string queryTXT = @"select escala, excedente, porciento, Escala1, id from ISR";
            queryCommand.CommandText = queryTXT;
            SqlDataReader dataReader2 = queryCommand.ExecuteReader();
            if (dataReader2.HasRows)
            {
                while (dataReader2.Read())
                {
                    switch (dataReader2.GetInt32(4).ToString())
                    {
                        case "1":
                            txtEscalaIni1.Text = dataReader2.GetDecimal(0).ToString();
                            txtEscalaFin1.Text = dataReader2.GetDecimal(3).ToString();
                            break;
                        case "2":
                            txtEscalaIni2.Text = dataReader2.GetDecimal(0).ToString();
                            txtEscalaFin2.Text = dataReader2.GetDecimal(3).ToString();
                            txtPorciento1.Text = dataReader2.GetDecimal(2).ToString();
                            break;
                        case "3":
                            txtEscalaIni3.Text = dataReader2.GetDecimal(0).ToString();
                            txtEscalaFin3.Text = dataReader2.GetDecimal(3).ToString();
                            txtPorciento2.Text = dataReader2.GetDecimal(2).ToString();
                            txtExcedente1.Text = dataReader2.GetDecimal(1).ToString();
                            break;
                        case "4":
                            txtEscalaIni4.Text = dataReader2.GetDecimal(0).ToString();
                            txtEscalaFin4.Text = dataReader2.GetDecimal(3).ToString();
                            txtPorciento3.Text = dataReader2.GetDecimal(2).ToString();
                            txtExcedente2.Text = dataReader2.GetDecimal(1).ToString();
                            break;

                    }
                }
            }
        }

        public void insertar_ISR(string escala, string escala1, string porcentaje, string exced)
        {
            conexionbd.Conectar();
            SqlCommand queryInsertarISR = new SqlCommand(@"insert into ISR values ((select coalesce(max(id),0)+1 from ISR), @escala, @exced, @porcentaje, @escala1)", conexionbd.Conectar());
            queryInsertarISR.Parameters.AddWithValue("@escala", Convert.ToDecimal(escala));
            queryInsertarISR.Parameters.AddWithValue("@porcentaje", porcentaje.ToString());
            queryInsertarISR.Parameters.AddWithValue("@exced", Convert.ToDecimal(exced));
            queryInsertarISR.Parameters.AddWithValue("@escala1", Convert.ToDecimal(escala1));
            queryInsertarISR.ExecuteNonQuery();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            lbCargo.Text = "Nuevo cargo";
            MainTable.Datos.activar = 1;
            panel1.Visible = true;
            txtCargo.Focus();
            btnSalir.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button7.Enabled = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand queryConfiguracion = new SqlCommand();
            queryConfiguracion.Connection = conexionbd.Conectar();
            if (MainTable.Datos.activar != 0)
            {
                queryConfiguracion.CommandText = @"insert into categoria values ((select coalesce(MAX(CodigoCategoria), 0) + 1 from categoria), 
                                             @Cargo, @SueldoBruto, 'A')";
            }
            else
            {
                queryConfiguracion.CommandText = @"update categoria set Cargo = @Cargo, SueldoBruto = @SueldoBruto where CodigoCategoria = @CodigoCategoria";
                queryConfiguracion.Parameters.AddWithValue("@CodigoCategoria", TablaConfiguracion.CurrentRow.Cells[0].Value.ToString());
            }
            queryConfiguracion.Parameters.AddWithValue("@Cargo", txtCargo.Text);
            queryConfiguracion.Parameters.AddWithValue("@SueldoBruto", txtSueldoBruto.Text);
            queryConfiguracion.ExecuteNonQuery();
            panel1.Visible = false;
            TablaConfiguracion.DataSource = llenar_grid2();
            Cambiar_titulo_grid2();
            btnSalir.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button7.Enabled = true;
            txtSueldoBruto.Clear();
            txtCargo.Clear();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea cancelar action?",
                 "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                txtSueldoBruto.Clear();
                txtCargo.Clear();
                panel1.Visible = false;
                btnSalir.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button7.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro que desea cambiar el estado del puesto " + TablaConfiguracion.CurrentRow.Cells[1].Value.ToString() + "?",
                 "Cambiar estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                SqlCommand queryVerificar = new SqlCommand();
                queryVerificar.Connection = conexionbd.Conectar();
                queryVerificar.CommandText = @"select CodigoCategoria from empleados where CodigoCategoria = @CodigoCategoria";
                queryVerificar.Parameters.AddWithValue("@CodigoCategoria", TablaConfiguracion.CurrentRow.Cells[0].Value.ToString());
                SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
                if (dataReader0.Read())
                {
                    MessageBox.Show("Error 406: El puesto esta asignado a algun empleado.", "Datos Relacionados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqlCommand queryConfiguracion = new SqlCommand();
                    queryConfiguracion.Connection = conexionbd.Conectar();
                    if (TablaConfiguracion.CurrentRow.Cells[0].Value.ToString() != "1")
                    {
                        if (TablaConfiguracion.CurrentRow.Cells[3].Value.ToString() != "I") { 
                            queryConfiguracion.CommandText = @"update categoria set Estado = 'I' where CodigoCategoria = @CodigoCategoria";
                            queryConfiguracion.Parameters.AddWithValue("@CodigoCategoria", TablaConfiguracion.CurrentRow.Cells[0].Value.ToString());
                            queryConfiguracion.ExecuteNonQuery();
                        }
                        else
                        {
                            queryConfiguracion.CommandText = @"update categoria set Estado = 'A' where CodigoCategoria = @CodigoCategoria";
                            queryConfiguracion.Parameters.AddWithValue("@CodigoCategoria", TablaConfiguracion.CurrentRow.Cells[0].Value.ToString());
                            queryConfiguracion.ExecuteNonQuery();
                            
                        }
                        TablaConfiguracion.DataSource = llenar_grid2();
                        Cambiar_titulo_grid2();
                    }
                    else
                    {
                        MessageBox.Show("Error 402: No se puede eliminar el cargo Administrador...", "¡¡Operacion Cancelada!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            TablaAddAdm.DataSource = llenar_grid3();
            TablaAddAdm.Columns[1].HeaderText = "Nombre";
            
        }

        private void TablaAddAdm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainTable.Datos.activar = 0;
            lbCargo.Text = "Editar cargo";
            txtCargo.Text = TablaConfiguracion.CurrentRow.Cells[1].Value.ToString();
            txtSueldoBruto.Text = TablaConfiguracion.CurrentRow.Cells[2].Value.ToString();
            panel1.Visible = true;
            txtCargo.Focus();
            btnSalir.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button7.Enabled = false;
        }

        private void Configuracion1_Load(object sender, EventArgs e)
        {
            if (MainTable.Datos.CheckBox1 == "true") 
            {
                checkBoxActivos.Checked = true;

            } 
            else 
            {
                checkBoxActivos.Checked = false; 
            }

            if (MainTable.Datos.CheckBox2 == "true")
            {
                checkBoxInactivos.Checked = true;

            }
            else
            {
                checkBoxInactivos.Checked = false;
            }



        }



        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand queryUsuario = new SqlCommand();
            queryUsuario.Connection = conexionbd.Conectar();
            if (MainTable.Datos.activar != 0)
            {                
                queryUsuario.CommandText = @"insert into Usuarios values (@Id, @Usuario, @Contrasenia);";
                queryUsuario.Parameters.AddWithValue("@Id", TablaAddAdm.CurrentRow.Cells[0].Value.ToString());                                           
            }
            else
            {
                queryUsuario.CommandText = @"update usuarios set Usuario = @Usuario, Password = @Contrasenia where IdUsuario = @id";
                queryUsuario.Parameters.AddWithValue("@Id", TablaUsuario.CurrentRow.Cells[0].Value.ToString());
            }

            queryUsuario.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            queryUsuario.Parameters.AddWithValue("@Contrasenia", txtContrasenia.Text);
            if (MainTable.Datos.nombreAdm == "")
            {
                MainTable.Datos.nombreAdm = TablaAddAdm.CurrentRow.Cells[1].Value.ToString();
            }
            queryUsuario.ExecuteNonQuery();
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            btnSalir.Enabled = true;
            panel3.Visible = false;
            txtContrasenia.Clear();
            txtUsuario.Clear();
            TablaUsuario.DataSource = llenar_grid4();
            Cambiar_titulo_grid4();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand queryVerificar = new SqlCommand();
            queryVerificar.Connection = conexionbd.Conectar();
            queryVerificar.CommandText = @"select a.Usuario, a.Password from  Usuarios a where IdUsuario = @IdUsuario";
            queryVerificar.Parameters.AddWithValue("@IdUsuario", TablaUsuario.CurrentRow.Cells[0].Value.ToString());
            SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
            if (dataReader0.Read())
            {
                txtUsuario.Text = dataReader0.GetString(0);
                txtContrasenia.Text = dataReader0.GetString(1);
                lbUsuario.Text = "Editar Usuario";
                MainTable.Datos.activar = 0;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                panel3.Visible = true;
                btnSalir.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand queryVerificar = new SqlCommand();
            queryVerificar.Connection = conexionbd.Conectar();
            queryVerificar.CommandText = @"select IdUsuario from  Usuarios where IdUsuario = @IdUsuario";
            queryVerificar.Parameters.AddWithValue("@IdUsuario", TablaAddAdm.CurrentRow.Cells[0].Value.ToString());
            SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
            if (dataReader0.Read())
            {
                MessageBox.Show("Error 406: Ya tiene un usuario asignado.", "Datos Relacionados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lbUsuario.Text = "Nuevo Usuario";
                MainTable.Datos.activar = 1;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                panel3.Visible = true;
                btnSalir.Enabled = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea cancelar action?",
                 "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                btnSalir.Enabled = true;
                panel3.Visible = false;
                txtContrasenia.Clear();
                txtUsuario.Clear();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea Eliminar el usuario de "+TablaUsuario.CurrentRow.Cells[1].Value.ToString() + "?",
                 "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (MainTable.Datos.nombreAdm != TablaUsuario.CurrentRow.Cells[1].Value.ToString())
                {
                    SqlCommand queryUsuario = new SqlCommand();
                    queryUsuario.Connection = conexionbd.Conectar();
                    queryUsuario.CommandText = @"delete from Usuarios where  IdUsuario = @IdUsuario";
                    queryUsuario.Parameters.AddWithValue("@IdUsuario", TablaUsuario.CurrentRow.Cells[0].Value.ToString());
                    queryUsuario.ExecuteNonQuery();
                    TablaUsuario.DataSource = llenar_grid4();
                    Cambiar_titulo_grid4();
                }
                else
                {
                    MessageBox.Show("Error 407: El usuario actual no puesde ser eliminado.", "Operacion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            SqlCommand queryVerificar = new SqlCommand();
            queryVerificar.Connection = conexionbd.Conectar();
            queryVerificar.CommandText = @"select usuario from usuarios where Usuario = @Usuario";
            queryVerificar.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
            SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
            if (dataReader0.Read())
            {
                MessageBox.Show("Error 408: EL usuario no disponible.", "Redundancia de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Clear();
                txtUsuario.Focus();
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            SqlCommand queryConfiguracion = new SqlCommand();
            queryConfiguracion.Connection = conexionbd.Conectar();
            queryConfiguracion.CommandText = @"update configuracion set AFPEmp = @AFPEmp, SFSEmp = @SFSEmp where  Id = 1";   
            queryConfiguracion.Parameters.AddWithValue("@AFPEmp", txtAFP.Text);
            queryConfiguracion.Parameters.AddWithValue("@SFSEmp", txtSFS.Text);                  
            queryConfiguracion.ExecuteNonQuery();
            queryConfiguracion.Parameters.Clear();
            queryConfiguracion.CommandText = @"delete from ISR";
            queryConfiguracion.ExecuteNonQuery();
            insertar_ISR(txtEscalaIni1.Text, txtEscalaFin1.Text, "0.00", "0.00");
            insertar_ISR(txtEscalaIni2.Text, txtEscalaFin2.Text, txtPorciento1.Text, "0.00");
            insertar_ISR(txtEscalaIni3.Text, txtEscalaFin3.Text, txtPorciento2.Text, txtExcedente1.Text);
            insertar_ISR(txtEscalaIni4.Text, txtEscalaFin4.Text, txtPorciento3.Text, txtExcedente2.Text);
            MessageBox.Show("Datos actualizados correctamente", "Datos de la configuracion actualizados");
            if (MainTable.Datos.llave == 0) {
                MainTable.Datos.llave = 1;
                tabControl1.SelectedIndex = 1;
            }

        }

        private void txtEscala2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBoxActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActivos.Checked == true)
            {
                MainTable.Datos.CheckBox1 = "true";

            }
            else 
            {
                MainTable.Datos.CheckBox1 = "false"; 
            }
        }

        private void checkBoxInactivos_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxInactivos.Checked == true)
            {
                MainTable.Datos.CheckBox2 = "true";

            }
            else
            {
                MainTable.Datos.CheckBox2 = "false";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
        }
    }
}
