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
using System.Drawing.Printing;


namespace NominaEmpleados
{
    public partial class HistoricoNomina : Form
    {
        int LineaImpresion = 0, Contador = 0;
        int ContadorPagina = 0, EncabezadoY = 50;
        public HistoricoNomina()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            tablaNomina.DataSource = llenar_grid1();
            Cambiar_titulo_grid1();
            tablaDetalleNomina.DataSource = llenar_grid2();
            Cambiar_titulo_grid2();
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryConfiguracion = new SqlCommand(@"select a.NombreEmpresa, a.Direccion, a.Correo, a.TelefonoEmpresa, 
                                                      a.RNC from configuracion a where a.Id = 1", conexionbd.Conectar());
            SqlDataReader dataReader2 = queryConfiguracion.ExecuteReader();
            if (dataReader2.Read())
            {
                lbNombreEmpresa.Text = dataReader2.GetString(0);
                lbDireccion.Text = dataReader2.GetString(1);
                lbCorreo.Text = dataReader2.GetString(2);
                lbTelefono.Text = dataReader2.GetString(3);
                lbRNC.Text = dataReader2.GetString(4);
            }
            llenar_campos();
        }

        public void Cambiar_titulo_grid1()
        {
            tablaNomina.Columns[0].HeaderText = "No. Nomina";
            tablaNomina.Columns[1].HeaderText = "Fech. Corrida";
            tablaNomina.Columns[2].HeaderText = "Total Sueldo Bruto";
            tablaNomina.Columns[3].HeaderText = "Total Sueldo Decuento";
            tablaNomina.Columns[4].HeaderText = "Total Sueldo Neto";
            tablaNomina.Columns[8].HeaderText = "Total Pagado";
        }
        public void Cambiar_titulo_grid2()
        {
            tablaDetalleNomina.Columns[1].HeaderText = "Nombre";
            tablaDetalleNomina.Columns[2].HeaderText = "Sueldo Bruto";
            tablaDetalleNomina.Columns[4].HeaderText = "Sueldo Neto";
        }
        public DataTable llenar_grid1()
        {
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryMostrarE = new SqlCommand(@"select CodigoNomina,  fechaCorrida, TotalSueldoBruto, TotalDescontado, totalsueldoneto, AFP, SFS, Infotep, TotalPagado  from nomina order by 1 desc", conexionbd.Conectar());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryMostrarE);
            dataAdapter.Fill(datatable);
            return datatable;
        }
        public DataTable llenar_grid2()
        {          
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryMostrarE = new SqlCommand(@"select a.Id, a.NombreCompleto, c.SueldoBruto, c.Descuento, c.SueldoNeto
                                                    from detallenomina as c
                                                    inner join empleados as a on c.CodigoEmpleado = a.Id
                                                    where c.NumeroNomina = @NumeroNomina", conexionbd.Conectar());
            queryMostrarE.Parameters.AddWithValue("@NumeroNomina", (string)tablaNomina.CurrentRow.Cells[0].Value.ToString());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryMostrarE);
            dataAdapter.Fill(datatable);
            return datatable;            
        }

        public void llenar_campos()
        {
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand querynomina = new SqlCommand(@"select a.Descripcion, a.Mes, a.Anio, a.CantidadEmpleados, aministrador from nomina a where a.CodigoNomina = @CodigoNomina", conexionbd.Conectar());
            querynomina.Parameters.AddWithValue("@CodigoNomina", (string)tablaNomina.CurrentRow.Cells[0].Value.ToString());
            SqlDataReader dataReader2 = querynomina.ExecuteReader();
            if (dataReader2.Read())
            {
                lbDescripcion.Text = dataReader2.GetString(0);               
                switch (dataReader2.GetString(1).ToString())
                {
                    case "1": lbMes.Text = "Enero"; break;
                    case "2": lbMes.Text = "Febrero"; break;
                    case "3": lbMes.Text = "Marzo"; break;
                    case "4": lbMes.Text = "Abril"; break;
                    case "5": lbMes.Text = "Mayo"; break;
                    case "6": lbMes.Text = "Junio"; break;
                    case "7": lbMes.Text = "Julio"; break;
                    case "8": lbMes.Text = "Agoosto"; break;
                    case "9": lbMes.Text = "Septiembre"; break;
                    case "10": lbMes.Text = "Octubre"; break;
                    case "11": lbMes.Text = "Noviembre"; break;
                    case "12": lbMes.Text = "Diciembre"; break;
                }
                lbanio.Text = dataReader2.GetString(2);
                lbCantidad.Text = dataReader2.GetInt32(3).ToString();
                lbNombreAdm.Text = dataReader2.GetString(4).ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea regresar?",
                  "Volver a atras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                ControlPagos controlPagos = new ControlPagos();
                controlPagos.Show();
                this.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tablaNomina.DataSource = llenar_grid1();
            Cambiar_titulo_grid1();
            tablaDetalleNomina.DataSource = llenar_grid2();
            Cambiar_titulo_grid2();
            llenar_campos();
        }

        private void tablaNomina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tablaNomina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tablaDetalleNomina.DataSource = llenar_grid2();
            Cambiar_titulo_grid2();
            llenar_campos();
        }

        private void tablaDetalleNomina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaDetalleNomina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarEmpleados MostrarEmpleados = new MostrarEmpleados();
            MainTable.Datos.Id = tablaDetalleNomina.CurrentRow.Cells[0].Value.ToString();
            MainTable.Datos.activarAscenderEmpleado = 0;
            MostrarEmpleados.Show();
            this.Close();
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            LineaImpresion = 0;
            Contador = 0;
            ContadorPagina = 0;
            VistaDocumento.Document = ImprimirDocumento;
            VistaDocumento.ShowDialog();
           




            
        }

        private void ImprimirDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            Font TituloEmpresa = new Font("Arial", 30);
            Font CuerpoReporte = new Font("Arial", 15);
            int ancho = 300, y = EncabezadoY, AlturaPagina = EncabezadoY, AnchoPagina = 20;
            string FechaCorta = "";

            ContadorPagina += 1;

            if (ContadorPagina <= 1)
            {

                for (int i = 0; i < 9; i++)
                {
                    FechaCorta += tablaNomina.CurrentRow.Cells[1].Value.ToString()[i];
                }






                e.Graphics.DrawString(lbNombreEmpresa.Text, TituloEmpresa, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 50));
                e.Graphics.DrawString("RNC: " + lbRNC.Text, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 50));
                e.Graphics.DrawString("Fecha De Impresion : " + DateTime.Now.ToShortDateString(), CuerpoReporte, Brushes.Black, new RectangleF(515, y, ancho + 300, 50));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
                e.Graphics.DrawString("Telefono: " + lbTelefono.Text, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 50));
                e.Graphics.DrawString("Correo: " + lbCorreo.Text, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                e.Graphics.DrawString("Direccion: " + lbDireccion.Text, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                e.Graphics.DrawString("No. Nomina: " + tablaNomina.CurrentRow.Cells[0].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                e.Graphics.DrawString("Fecha Corrida: " + FechaCorta, CuerpoReporte, Brushes.Black, new RectangleF(275, y, ancho + 300, 50));
                e.Graphics.DrawString("No. Empleado Pagado: " + lbCantidad.Text, CuerpoReporte, Brushes.Black, new RectangleF(575, y, ancho + 300, 50));
                e.Graphics.DrawString("Descripcion: " + lbDescripcion.Text, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 60, ancho + 500, 20));
            }
            e.Graphics.DrawString("ID", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 20, ancho + 300, 50));
            e.Graphics.DrawString("Nombre Empleado", CuerpoReporte, Brushes.Black, new RectangleF(65, y, ancho + 300, 50));
            e.Graphics.DrawString("Sueldo Bruto", CuerpoReporte, Brushes.Black, new RectangleF(337, y, ancho + 300, 50));
            e.Graphics.DrawString("Descuentos", CuerpoReporte, Brushes.Black, new RectangleF(510, y, ancho + 300, 50));
            e.Graphics.DrawString("Sueldo Neto", CuerpoReporte, Brushes.Black, new RectangleF(680, y, ancho + 300, 50));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));

            if(tablaDetalleNomina.Rows.Count > 0)
            {
                while (LineaImpresion < tablaDetalleNomina.Rows.Count)
                {
                    if (y > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        EncabezadoY = e.MarginBounds.Top;
                        break;
                    }

                    e.Graphics.DrawString((String)tablaDetalleNomina.Rows[LineaImpresion].Cells[0].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                    e.Graphics.DrawString((String)tablaDetalleNomina.Rows[LineaImpresion].Cells[1].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(65, y, ancho + 300, 50));
                    e.Graphics.DrawString((String)tablaDetalleNomina.Rows[LineaImpresion].Cells[2].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(337, y, ancho + 300, 50));
                    e.Graphics.DrawString((String)tablaDetalleNomina.Rows[LineaImpresion].Cells[3].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(510, y, ancho + 300, 50));
                    e.Graphics.DrawString((String)tablaDetalleNomina.Rows[LineaImpresion].Cells[4].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(680, y, ancho + 300, 50));

                    LineaImpresion += 1;
                }
            }
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
            if (y > e.MarginBounds.Bottom-200)
            {

            }
            else
            {
                e.Graphics.DrawString("Total Sueldo Bruto :", CuerpoReporte, Brushes.Black, new RectangleF(380, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(tablaNomina.CurrentRow.Cells[2].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(660, y, ancho + 300, 50));
                e.Graphics.DrawString("Total Sueldo Descuento :", CuerpoReporte, Brushes.Black, new RectangleF(380, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(tablaNomina.CurrentRow.Cells[3].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(660, y, ancho + 300, 50));
                e.Graphics.DrawString("Total Sueldo Neto :", CuerpoReporte, Brushes.Black, new RectangleF(380, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(tablaNomina.CurrentRow.Cells[4].Value.ToString(), CuerpoReporte, Brushes.Black, new RectangleF(660, y, ancho + 300, 50));
                e.Graphics.DrawString("--------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(370, y += 30, ancho + 500, 20));
            }



















            /* string Var_NumeroNomina = "", Var_FechaCorrida = "", Var_TotalSueldoBruto = "", Var_TotalSueldoDescuento = "", Var_TotalSueldoNeto = "", Var_AFP = "", Var_SFS = "", Var_Infotep = "", Var_TotalPagado = "", Var_NombreEmpresa = "";

             e.Graphics.DrawString(Var_NombreEmpresa, TituloEmpresa, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 50));
             e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
             e.Graphics.DrawString(Var_NumeroNomina, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_FechaCorrida, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_TotalSueldoBruto, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_TotalSueldoDescuento, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_TotalSueldoNeto, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_AFP, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_SFS, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_Infotep, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString(Var_TotalPagado, CuerpoReporte, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 30));
             e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", CuerpoReporte, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
     */






        }
    }
}
