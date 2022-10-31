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
    public partial class MostrarEmpleados : Form
    {
        int LineaImpresion = 0, Contador = 0;
        int ContadorPagina = 0, EncabezadoY = 50;

        public MostrarEmpleados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea regresar?",
                 "Volver a atras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (MainTable.Datos.activarAscenderEmpleado == 0)
                {
                    variableGlobal.varVisualizar = 0;
                    HistoricoNomina historicoNomina = new HistoricoNomina();                   
                    historicoNomina.Show();
                    this.Close();
                }
                else if (MainTable.Datos.activarAscenderEmpleado == 2)
                {
                    variableGlobal.varVisualizar = 0;
                    Empleados empleados = new Empleados();
                    empleados.Show();
                    this.Close();


                }
                else
                {
                    Configuracion1 Configuracion1 = new Configuracion1();
                    Configuracion1.Show();
                    variableGlobal.varVisualizar = 0;
                    this.Close();
                }
            }
        }

        private void MostrarEmpleados_Shown(object sender, EventArgs e)
        {
           
            conexionbd.Conectar();

            SqlCommand queryMostrarE = new SqlCommand(@"select a.Id, a.NombreCompleto, a.Cedula, a.FechaNac, a.TelefonoEmpleado, a.Correo, a.CodigoCategoria, c.Cargo, c.SueldoBruto
                                                      from categoria as c
                                                      inner join empleados as a on c.CodigoCategoria = a.CodigoCategoria
                                                      where Id = @Id ", conexionbd.Conectar());
            queryMostrarE.Parameters.AddWithValue("@Id", MainTable.Datos.Id);
            SqlDataReader dataReaderCargo = queryMostrarE.ExecuteReader();
            if (dataReaderCargo.Read())
            {
                lbCargo.Text = "";
                lbSueldo.Text = "";
                lbNombre.Text = dataReaderCargo.GetString(1);
                lbCedula.Text = dataReaderCargo.GetString(2);
                lbFecha.Text = dataReaderCargo.GetDateTime(3).ToString();
                lbTelefono.Text = dataReaderCargo.GetString(4);
                lbCorreo.Text = dataReaderCargo.GetString(5);
                MainTable.Datos.codigCategoria = Convert.ToString(dataReaderCargo.GetInt32(6)-1);
                lbCargo.Text = dataReaderCargo.GetString(7);
                lbSueldo.Text = dataReaderCargo.GetDecimal(8).ToString();                 
            }
            TablaMostrar.DataSource = llenar_grid4();
            Cambiar_titulo_grid4();           
            variableGlobal.varVisualizar = 0;
            if (MainTable.Datos.activarAscenderEmpleado == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        public void Cambiar_titulo_grid4()
        {//select a.CodigoNomina, a.fechaCorrida , a.descripcion, c.SueldoBruto, c.SFSEmp, c.AFPEmp, c.ISR, c.Descuento,  c.SueldoNeto
            TablaMostrar.Columns[0].HeaderText = "No. Nomina";
            TablaMostrar.Columns[1].HeaderText = "Fecha Corrida";           
            TablaMostrar.Columns[2].HeaderText = "Descripcion";
            TablaMostrar.Columns[8].HeaderText = "Sueldo Neto";
            TablaMostrar.Columns[3].HeaderText = "Sueldo Bruto";
            TablaMostrar.Columns[5].HeaderText = "AFP";
            TablaMostrar.Columns[4].HeaderText = "SFS";

        }

        private void comBoxCargo_Click(object sender, EventArgs e)
        {                     
        }

        private void comBoxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
 
        public DataTable llenar_grid4()
        {
            conexionbd.Conectar();
            DataTable datatable = new DataTable();
            SqlCommand queryMostrarE = new SqlCommand(@"select a.CodigoNomina, a.fechaCorrida , a.descripcion, c.SueldoBruto, c.SFSEmp, c.AFPEmp, c.ISR, c.Descuento,  c.SueldoNeto
                                                    from detallenomina as c
                                                    inner join nomina as a on c.NumeroNomina = a.CodigoNomina
                                                    where c.CodigoEmpleado = @Id", conexionbd.Conectar());
            queryMostrarE.Parameters.AddWithValue("@Id", MainTable.Datos.Id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryMostrarE);
            dataAdapter.Fill(datatable);
            return datatable;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
                              
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*panel3.Visible = false;
            txtUsuario.Clear();
            txtContrasenia.Clear();
            btnSalir.Enabled = true;
            button1.Enabled = true;*/

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public static class variableGlobal
        {
            public static int varVisualizar = 0;         
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRegistroPago_Click(object sender, EventArgs e)
        {
            LineaImpresion = 0; 
            Contador = 0;
            ContadorPagina = 0;
            PrintPreviewDialogRegistroPago.Document = PrintDocumentRegistroPago;
            PrintPreviewDialogRegistroPago.ShowDialog();

        }

        private void PrintDocumentRegistroPago_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font TituloDatosPersonales = new Font("Arial", 30,FontStyle.Bold);
            Font FormatoTitulosPersonales = new Font("Arial", 12, FontStyle.Bold);
            Font FormatoTitulos = new Font("Arial", 20, FontStyle.Bold);
            Font FormatoRaya = new Font("Arial", 12, FontStyle.Bold);
            Font FormatoDatos = new Font("Arial", 12);          
            int ancho = 300, y = EncabezadoY, AlturaPagina = EncabezadoY, AnchoPagina = 20;
            //string FechaCorta = "", ContenedorFecha = "";

            ContadorPagina += 1;

            if (ContadorPagina <= 1)
            {
                conexionbd.Conectar();
                DataTable datatable = new DataTable();
                SqlCommand queryConfiguracion = new SqlCommand(@"select a.NombreEmpresa, a.Direccion, a.Correo, a.TelefonoEmpresa, 
                                                          a.RNC from configuracion a where a.Id = 1", conexionbd.Conectar());
                SqlDataReader dataReader2 = queryConfiguracion.ExecuteReader();
                if (dataReader2.Read())
                {
                    e.Graphics.DrawString(dataReader2.GetString(0), TituloDatosPersonales, Brushes.Black, new RectangleF(20, y, ancho + 300, 50));
                    e.Graphics.DrawString("RNC: " + dataReader2.GetString(4), FormatoTitulos, Brushes.Black, new RectangleF(20, y += 50, ancho + 300, 50));
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 30, ancho + 500, 20));
                    e.Graphics.DrawString("DIRECCION: " + dataReader2.GetString(1), FormatoTitulos, Brushes.Black, new RectangleF(20, y += 35, ancho + 300, 50));
                    e.Graphics.DrawString("CORREO: " + dataReader2.GetString(2), FormatoTitulos, Brushes.Black, new RectangleF(20, y += 35, ancho + 300, 50));
                    e.Graphics.DrawString("TELEFONO: " + dataReader2.GetString(3), FormatoTitulos, Brushes.Black, new RectangleF(20, y += 35, ancho + 300, 50));
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 30, ancho + 500, 20));
                }
                e.Graphics.DrawString("DATOS EMPLEADO", FormatoTitulos, Brushes.Black, new RectangleF(300, y += 35, ancho + 300, 50));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 30, ancho + 500, 20));
                e.Graphics.DrawString("DATOS PERSONALES", FormatoTitulos, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                e.Graphics.DrawImage(pictureBox2.Image, 18, y += 50, 160, 150);
                e.Graphics.DrawString("NOMBRE:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(170, y, ancho + 300, 50));
                e.Graphics.DrawString(lbNombre.Text, FormatoDatos, Brushes.Black, new RectangleF(360, y, ancho + 300, 50));
                e.Graphics.DrawString("FECHA REGISTRO:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(170, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(lbFecha.Text, FormatoDatos, Brushes.Black, new RectangleF(360, y, ancho + 300, 50));
                e.Graphics.DrawString("CEDULA:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(170, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(lbCedula.Text, FormatoDatos, Brushes.Black, new RectangleF(360, y, ancho + 300, 50));
                e.Graphics.DrawString("TELEFONO:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(170, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(lbTelefono.Text, FormatoDatos, Brushes.Black, new RectangleF(360, y, ancho + 300, 50));
                e.Graphics.DrawString("CORREO:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(170, y += 30, ancho + 300, 50));
                e.Graphics.DrawString(lbCorreo.Text, FormatoDatos, Brushes.Black, new RectangleF(360, y, ancho + 300, 50));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
                e.Graphics.DrawString("DATOS LABORALES", FormatoTitulos, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
                e.Graphics.DrawString("CARGO:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(40, y += 50, ancho + 300, 50));
                e.Graphics.DrawString(lbCargo.Text, FormatoDatos, Brushes.Black, new RectangleF(120, y, ancho + 300, 50));
                e.Graphics.DrawString("SUELDO:", FormatoTitulosPersonales, Brushes.Black, new RectangleF(520, y, ancho + 300, 50));
                e.Graphics.DrawString(lbSueldo.Text, FormatoDatos, Brushes.Black, new RectangleF(605, y, ancho + 300, 50));
                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
                e.Graphics.DrawString("REGISTRO DE PAGOS", FormatoTitulos, Brushes.Black, new RectangleF(20, y += 30, ancho + 300, 50));
            }
            e.Graphics.DrawString("", FormatoDatos, Brushes.Black, new RectangleF(30, y += 10, ancho + 300, 50));            
            e.Graphics.DrawString("Nomina", FormatoTitulosPersonales, Brushes.Black, new RectangleF(30, y += 30, ancho + 300, 50));
            e.Graphics.DrawString("Fecha Corrida", FormatoTitulosPersonales, Brushes.Black, new RectangleF(120, y, ancho + 300, 50));//
            e.Graphics.DrawString("Sueldo Bruto", FormatoTitulosPersonales, Brushes.Black, new RectangleF(330, y, ancho + 300, 50));
            e.Graphics.DrawString("Descuento", FormatoTitulosPersonales, Brushes.Black, new RectangleF(520, y, ancho + 300, 50));
            e.Graphics.DrawString("Sueldo Neto", FormatoTitulosPersonales, Brushes.Black, new RectangleF(680, y, ancho + 300, 50));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));

            

            if (TablaMostrar.Rows.Count > 0)
            {
                while (LineaImpresion < TablaMostrar.Rows.Count)
                {//select a.CodigoNomina, a.fechaCorrida , a.descripcion, c.SueldoBruto, c.SFSEmp, c.AFPEmp, c.ISR, c.Descuento,  c.SueldoNeto
                    if (y > e.MarginBounds.Bottom) 
                    {                  
                        e.HasMorePages = true;
                        EncabezadoY = e.MarginBounds.Top;
                        break;
                    }
                    e.Graphics.DrawString((String)TablaMostrar.Rows[LineaImpresion].Cells[0].Value.ToString(), FormatoDatos, Brushes.Black, new RectangleF(50, y += 30, ancho + 300, 50));
                    e.Graphics.DrawString(TablaMostrar.Rows[LineaImpresion].Cells[1].Value.ToString(), FormatoDatos, Brushes.Black, new RectangleF(90, y, ancho + 300, 50));
                    e.Graphics.DrawString(TablaMostrar.Rows[LineaImpresion].Cells[3].Value.ToString(), FormatoDatos, Brushes.Black, new RectangleF(335, y, ancho + 300, 50));
                    e.Graphics.DrawString(TablaMostrar.Rows[LineaImpresion].Cells[7].Value.ToString(), FormatoDatos, Brushes.Black, new RectangleF(525,y, ancho + 300, 50));
                    e.Graphics.DrawString(TablaMostrar.Rows[LineaImpresion].Cells[8].Value.ToString(), FormatoDatos, Brushes.Black, new RectangleF(685, y, ancho + 300, 50));
                    if ((String)TablaMostrar.Rows[LineaImpresion].Cells[0].Value.ToString() != "")
                    {
                        e.Graphics.DrawString("Descripcion: " + TablaMostrar.Rows[LineaImpresion].Cells[2].Value.ToString(), FormatoDatos, Brushes.Black, new RectangleF(50, y += 30, ancho + 300, 50));
                        e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------", FormatoRaya, Brushes.Black, new RectangleF(20, y += 20, ancho + 500, 20));
                        
                    }
                    LineaImpresion += 1;


                }
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
