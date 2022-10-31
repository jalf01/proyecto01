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

namespace NominaEmpleados
{
    public partial class FCarga : Form
    {
        public FCarga()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FCarga_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            progressB.Visible = false;
            porcentaje.Visible = false;
            controladorProgressB.Enabled = false;
            controladorProgressB.Stop();           
            conexionbd.Conectar();
            SqlCommand cmd = new SqlCommand("select a.NombreEmpresa from configuracion a", conexionbd.Conectar());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dta = new DataTable();
            sda.Fill(dta);
            if (dta.Rows.Count > 0)
            {
                if (dta.Rows[0][0].ToString() != "Default")
                {
                    lbEmpresa.Text = dta.Rows[0][0].ToString();
                }
                MainTable.Datos.firstRun = dta.Rows[0][0].ToString();
            }

            timerControl.Enabled = true;
            timerControl.Start();
        }

        private void controladorProgressB_Tick(object sender, EventArgs e)
        {
            if (progressB.Value < 280)
            {
                progressB.Value += 20;
                variableGlobal.acumulador += 20;

                variableGlobal.varPorcentaje = (variableGlobal.acumulador * 100) / 278;
                porcentaje.Text = variableGlobal.varPorcentaje.ToString() + " %";
            }
            else
            {
                progressB.Value += 10;
                controladorProgressB.Stop();
                controladorProgressB.Enabled = false;
                this.Hide();
                Login login = new Login();
                login.ShowDialog();

            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           // this.Hide();
           // Configuracion1 form5 = new Configuracion1();
            //form5.Show();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timerControl_Tick(object sender, EventArgs e)
        {                    
            pictureBox1.Visible = false;
            label1.Visible = true;
            progressB.Visible = true;
            porcentaje.Visible = true;
            progressB.Value += 20; // El nombre de la progresbar es progresB. 
            conexionbd conexion = new conexionbd();
            conexionbd.Conectar();
            progressB.Value = 50;
            porcentaje.Text = "23 %"; // El nombre del label que indica el porciento se llama porcentaje
            conexionbd.Conectar();
            progressB.Value = 10;
            //variableGlobal.acumulador = 80;
            porcentaje.Text = "0 %";
            controladorProgressB.Enabled = true; // El nombre del taimes controladorProgressB.
            controladorProgressB.Start();
            timerControl.Stop();
            timerControl.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Lobby lobby = new Lobby();
            lobby.Show();
        }
    }
}
    public static class variableGlobal
    {
        public static int varPorcentaje = 100;
        public static int acumulador;
        public static int varFinTimer = 0;

    }

    
    

