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
    public partial class ControlPagos : Form
    {
        public ControlPagos()
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

        private void btnPagar_Click(object sender, EventArgs e)
        {
            int comprobarPago = 1;
            decimal aux0 = 0, aux1 = 0;
            string fechaCorta = "";
            for (int i = 0; i < 9; i++)
            {
                fechaCorta += fechaInicio.Value.ToString()[i];
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text) || comBoxMes.SelectedIndex == 0) {
                MessageBox.Show("Campo emblaco");
            }
            else { 
                lbCargando.Show();
                progressB.Show();
                MainTable.Datos.totalDescuentos = 0;
                MainTable.Datos.totalPagado = 0;
                MainTable.Datos.totalSueldoBruto = 0;
                lbCargando.Text = "Cargando";
                progressB.Value += 5;
                conexionbd.Conectar();
                int cantidadEmpleado = 0, minimo = 0;
                lbCargando.Text += ".  ";
                progressB.Value += 5;
                SqlCommand queryVerificar = new SqlCommand();
                queryVerificar.Connection = conexionbd.Conectar();
                lbCargando.Text += ".  ";
                progressB.Value += 5;
                queryVerificar.CommandText = @"select anio, mes from nomina where anio = @anoi and mes = @mes";
                lbCargando.Text += ".  ";
                progressB.Value += 5;
                queryVerificar.Parameters.AddWithValue("@mes", comBoxMes.SelectedIndex.ToString());
                queryVerificar.Parameters.AddWithValue("@anoi", lbAnio.Text);
                lbCargando.Text = "Cargando";
                progressB.Value += 5;
                SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
                if (dataReader0.Read())
                {                    
                    DialogResult r = MessageBox.Show("Ya existe una nomina en la fecha seleccionada, Desea continuar con el pago.??", "Fecha duplicada.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (r == DialogResult.No)
                    {
                        comprobarPago = 0;
                    }
                }                
                if (comprobarPago != 0){
                    lbCargando.Text += ".  ";
                    progressB.Value += 5;
                    SqlCommand queryRegistrarPago = new SqlCommand();
                    queryRegistrarPago.Connection = conexionbd.Conectar();
                    queryRegistrarPago.CommandText = @"select COUNT(Id) from empleados where Estado = 'A'";
                    lbCargando.Text += ".  ";
                    progressB.Value += 5;
                    SqlDataReader dataReader1 = queryRegistrarPago.ExecuteReader();
                    dataReader0.Close();
                    lbCargando.Text += ".  ";
                    progressB.Value += 5;
                    if (dataReader1.Read())
                    {
                        cantidadEmpleado = dataReader1.GetInt32(0);
                        lbCargando.Text = "Cargando";
                        progressB.Value += 5;
                        MainTable.Datos.cantidadEmpleado = 0;
                        while (cantidadEmpleado > minimo)
                        {
                            MainTable.Datos.cantidadEmpleado += 1;
                            queryRegistrarPago.Parameters.Clear();
                            queryRegistrarPago.CommandText = @"insert into detallenomina values((select coalesce(MAX(CodigoNomina), 0) + 1 from nomina ), 
                                                             (select coalesce(MAX(CodigoDetalleN), 0) + 1 from detallenomina), @CodigoEmpleado, 1, @Descuento, 
                                                             @SueldoNeto, @SueldoBruto, @ISR, @SFS, @AFP)";
                            lbCargando.Text += ".  ";
                            //MessageBox.Show(minimo.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@Descuento", (string)TablaEmpleados.Rows[minimo].Cells[5].Value.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@SueldoNeto", (string)TablaEmpleados.Rows[minimo].Cells[6].Value.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@CodigoEmpleado", (string)TablaEmpleados.Rows[minimo].Cells[0].Value.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@SueldoBruto", (string)TablaEmpleados.Rows[minimo].Cells[3].Value.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@ISR", (string)TablaEmpleados.Rows[minimo].Cells[6].Value.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@SFS", (string)TablaEmpleados.Rows[minimo].Cells[4].Value.ToString());
                            queryRegistrarPago.Parameters.AddWithValue("@AFP", (string)TablaEmpleados.Rows[minimo].Cells[5].Value.ToString());
                            MainTable.Datos.totalDescuentos += Convert.ToDecimal(TablaEmpleados.Rows[minimo].Cells[5].Value.ToString());
                            MainTable.Datos.totalPagado += Convert.ToDecimal(TablaEmpleados.Rows[minimo].Cells[6].Value.ToString());
                            MainTable.Datos.totalSueldoBruto += Convert.ToDecimal(TablaEmpleados.Rows[minimo].Cells[3].Value.ToString());
                            dataReader1.Close();
                            lbCargando.Text += ".  ";
                            queryRegistrarPago.ExecuteNonQuery();
                            minimo++;
                            lbCargando.Text += ".  ";
                            progressB.Value = 80;

                        }
                        queryRegistrarPago.Parameters.Clear();
                        queryRegistrarPago.CommandText = @"insert into nomina values ((select coalesce(MAX(CodigoNomina),0)+1 from nomina), 1, @totalDescuento,
                                                         @cantidadEmpleado, @TotalSueldoBruto, @totalsueldoneto, @mes, @fechaCorrida, @descripcion, @anio, @AFP, 
                                                         @SFS, @Infotep, @TotalPagado, @aministrador)";
                        queryRegistrarPago.Parameters.AddWithValue("@fechaCorrida", Convert.ToDateTime(fechaCorta));
                        lbCargando.Text = "Cargando";
                        progressB.Value = 85;
                        aux0 = MainTable.Datos.totalSueldoBruto * MainTable.Datos.porAFPOrg / 100;
                        aux1 += aux0;
                        queryRegistrarPago.Parameters.AddWithValue("@AFP", Convert.ToString(aux0));
                        queryRegistrarPago.Parameters.AddWithValue("@aministrador", MainTable.Datos.nombreAdm);
                        aux0 = MainTable.Datos.totalSueldoBruto * MainTable.Datos.porSFSOrg / 100;
                        aux1 += aux0;
                        queryRegistrarPago.Parameters.AddWithValue("@SFS", Convert.ToString(aux0));
                        aux0 = MainTable.Datos.totalSueldoBruto * MainTable.Datos.porInfotep / 100;
                        aux1 += aux0;
                        queryRegistrarPago.Parameters.AddWithValue("@Infotep", Convert.ToString(aux0));
                        queryRegistrarPago.Parameters.AddWithValue("@anio", lbAnio.Text);
                        queryRegistrarPago.Parameters.AddWithValue("@mes", Convert.ToString(comBoxMes.SelectedIndex));
                        queryRegistrarPago.Parameters.AddWithValue("@totalsueldoneto", MainTable.Datos.totalPagado);
                        lbCargando.Text += ".  ";
                        progressB.Value = 95;
                        queryRegistrarPago.Parameters.AddWithValue("@totalDescuento", MainTable.Datos.totalDescuentos);
                        queryRegistrarPago.Parameters.AddWithValue("@TotalSueldoBruto", MainTable.Datos.totalSueldoBruto);
                        queryRegistrarPago.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                        queryRegistrarPago.Parameters.AddWithValue("@cantidadEmpleado", MainTable.Datos.cantidadEmpleado);
                        aux0 = MainTable.Datos.totalSueldoBruto + aux1;                        
                        queryRegistrarPago.Parameters.AddWithValue("@TotalPagado", Convert.ToString(aux0));
                        queryRegistrarPago.ExecuteNonQuery();
                        lbCargando.Text += ".  ";
                        progressB.Value = 100;
                        MessageBox.Show("Datos del empleado almacenados", "Pago realizado exitosamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                lbCargando.Hide();
                progressB.Hide();
                progressB.Value = 0;
            }
        }

        private void ControlPagos_Shown(object sender, EventArgs e)
        {
            decimal aux = 0, aux1 = 0;
            comBoxMes.SelectedIndex = 0;
            lbCargando.Hide();
            progressB.Hide();
            conexionbd.Conectar();
            int index;
            string queryTXT = "select Id, Cedula, TelefonoEmpleado, Correo, NombreCompleto, CodigoCategoria, FechaNac from empleados where Estado = 'A'";
            SqlCommand queryPagarNomina = new SqlCommand(queryTXT, conexionbd.Conectar());
            SqlCommand queryCommand = new SqlCommand();
            queryCommand.Connection = conexionbd.Conectar();
            SqlDataReader dataReader1 = queryPagarNomina.ExecuteReader();
            queryTXT = @"select AFPEmp, SFSEmp, AFPOrg, SFSOrg, Infotep from configuracion";
            queryCommand.CommandText = queryTXT;
            SqlDataReader dataReader2 = queryCommand.ExecuteReader();
            if (dataReader2.Read())
            {
                MainTable.Datos.porCiento = dataReader2.GetDecimal(0);
                MainTable.Datos.porCiento2 = dataReader2.GetDecimal(1);
                MainTable.Datos.porAFPOrg = dataReader2.GetDecimal(2);
                MainTable.Datos.porSFSOrg = dataReader2.GetDecimal(3);
                MainTable.Datos.porInfotep = dataReader2.GetDecimal(4);
            }
            if (dataReader1.HasRows)
            {
                while (dataReader1.Read())
                {
                    MainTable.Datos.cantidadEmpleado += 1;
                    index = TablaEmpleados.Rows.Add();
                    queryCommand.Parameters.Clear();
                    dataReader2.Close();
                    MainTable.Datos.codigCategoria = dataReader1.GetInt32(5).ToString();
                    TablaEmpleados.Rows[index].Cells[0].Value = dataReader1.GetInt32(0).ToString();
                    queryCommand.Parameters.Clear();
                    queryTXT = @"select CodigoCategoria, Cargo, SueldoBruto from categoria where CodigoCategoria = @CodigoCategoria";
                    queryCommand.CommandText = queryTXT;
                    queryCommand.Parameters.AddWithValue("@CodigoCategoria", MainTable.Datos.codigCategoria);
                    dataReader2 = queryCommand.ExecuteReader();
                    TablaEmpleados.Rows[index].Cells[1].Value = dataReader1.GetString(4);
                    if (dataReader2.Read())
                    {
                        MainTable.Datos.totalPagado += dataReader2.GetDecimal(2);
                        MainTable.Datos.sueldoBruto = dataReader2.GetDecimal(2);
                        TablaEmpleados.Rows[index].Cells[3].Value = dataReader2.GetDecimal(2);
                        TablaEmpleados.Rows[index].Cells[2].Value = dataReader2.GetString(1);

                        TablaEmpleados.Rows[index].Cells[5].Value = Math.Round((MainTable.Datos.sueldoBruto * MainTable.Datos.porCiento) / 100, 2);
                        TablaEmpleados.Rows[index].Cells[4].Value = Math.Round((MainTable.Datos.sueldoBruto * MainTable.Datos.porCiento2) / 100, 2);
                        
                    }
                    //Console.WriteLine("{0}", dataReader1.GetInt32(0));
                    //Console.WriteLine(MainTable.Datos.nombreEmpleado +" "+ MainTable.Datos.codigCategoria +" "+ MainTable.Datos.sueldoBruto +" "+ MainTable.Datos.cargoEmpleado);                                     
                    TablaEmpleados.Rows[index].Cells[7].Value = Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[4].Value.ToString()) + Convert.ToDecimal( TablaEmpleados.Rows[index].Cells[5].Value.ToString());
                    TablaEmpleados.Rows[index].Cells[8].Value = Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[3].Value.ToString()) - Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[7].Value.ToString());
                    aux1 = Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[8].Value.ToString());
                    MainTable.Datos.montoAnual = aux1 * 12;
                    queryTXT = @"select escala, excedente, porciento, Escala1, id from ISR";
                    queryCommand.Parameters.Clear();
                    queryCommand.CommandText = queryTXT;
                    dataReader2.Close();                  
                    dataReader2 = queryCommand.ExecuteReader();
                    TablaEmpleados.Rows[index].Cells[1].Value = dataReader1.GetString(4);

                    if (dataReader2.HasRows)
                    {
                        while (dataReader2.Read())
                        {
                            if (((dataReader2.GetInt32(4) != 4)) && (MainTable.Datos.montoAnual >= dataReader2.GetDecimal(0)) && (MainTable.Datos.montoAnual <= dataReader2.GetDecimal(3)))
                            {
                                aux = MainTable.Datos.montoAnual - dataReader2.GetDecimal(0);
                                aux1 = (aux * dataReader2.GetDecimal(2)) / 100;                                
                                aux = aux1 + dataReader2.GetDecimal(1);  
                                aux1 = Math.Round(aux / 12, 2);
                                TablaEmpleados.Rows[index].Cells[6].Value = aux1;
                            }
                            if (MainTable.Datos.montoAnual >= dataReader2.GetDecimal(0) && (dataReader2.GetInt32(4) == 4))
                            {
                                aux = MainTable.Datos.montoAnual - dataReader2.GetDecimal(0);
                                aux1 = (aux * dataReader2.GetDecimal(2)) / 100;
                                aux = aux1 + dataReader2.GetDecimal(1);
                                aux1 = Math.Round(aux / 12, 2);
                                TablaEmpleados.Rows[index].Cells[6].Value = aux1;   
                            }
                        }
                        TablaEmpleados.Rows[index].Cells[7].Value = Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[7].Value.ToString()) + Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[6].Value.ToString());
                        TablaEmpleados.Rows[index].Cells[8].Value = Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[3].Value.ToString()) - Convert.ToDecimal(TablaEmpleados.Rows[index].Cells[7].Value.ToString());
                    }              
                }

            }
            else
            {
                Console.WriteLine("Error 402: El pago no es valido...");
            }
            dataReader1.Close();
        }

        public void Cambiar_titulo_grid()
        {
            //tablaEmpleados.Columns[4].HeaderText = "Telefono";
        }

        private void TablaEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ControlPagos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int porciento = Convert.ToInt32(lbAnio.Text) - 1;
            lbAnio.Text = porciento.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int porciento = Convert.ToInt32(lbAnio.Text) + 1;
            lbAnio.Text = porciento.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HistoricoNomina historicoNomina = new HistoricoNomina();
            SqlCommand queryVerificar = new SqlCommand();
            queryVerificar.Connection = conexionbd.Conectar();
            queryVerificar.CommandText = @"select CodigoNomina from nomina";
            SqlDataReader dataReader0 = queryVerificar.ExecuteReader();
            if (dataReader0.Read())
            {
                this.Hide();
                historicoNomina.ShowDialog();
            }else
            {
                MessageBox.Show("Error 404: No hay nomina registrada por el momento.", "Parametros invalidos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(comBoxMes.SelectedIndex));
        }
    }
}
