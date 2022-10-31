using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaEmpleados
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.Hide();

            Empleados form4 = new Empleados();
            form4.Show();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            this.Hide();

            Configuracion1 form5 = new Configuracion1();
            form5.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea regresar?",
                  "Volver a atras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) {

                Login login = new Login();
                this.Hide();
                login.Show();
                
            }
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            this.Hide();

            ControlPagos ControlPagos = new ControlPagos();
            ControlPagos.Show();
        }

        private void Lobby_Shown(object sender, EventArgs e)
        {
            lbUsuario.Text = MainTable.Datos.nombreAdm;
            if (MainTable.Datos.firstRun != "Default")
            {
                btnEmpleados.Enabled = true;
                btnControl.Enabled = true;                
            }
            else
            {
                MessageBox.Show("Favor Completar los datos en la pestaña Seguridad Social del apartado Configuracion.");
                btnEmpleados.Enabled = false;
                btnControl.Enabled = false;
            }
            if (lbUsuario.Text == "")
            {
                btnControl.Enabled = false;
            }
            else
            {
                btnControl.Enabled = true;
            }

        }

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            if (lbUsuario.Text == "")
            {
                btnControl.Enabled = false;
            }
            else
            {
                btnControl.Enabled = true;
            }
        }
    }
}
