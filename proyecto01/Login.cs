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
    public partial class Login : Form
    {
        public static int Users;
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("server = DESKTOP-3EEPLP3; database = nominadb; integrated security = true;");
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            
            if (MainTable.Datos.firstRun != "Default") {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select IdUsuario from Usuarios", cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dta = new DataTable();
                sda.Fill(dta);

                if (dta.Rows.Count > 0)
                {
                    logear(this.txtUsuario.Text, this.txtPassword.Text);
                }
                else
                {
                    Lobby lobby = new Lobby();
                    this.Hide();
                    lobby.Show();
                }
            }
            else
            {
                Lobby lobby = new Lobby();
                this.Hide();
                lobby.Show();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro que desea Salir?",
                  "Salir de la aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes) Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public void logear(string usuario, string contrasena)
        {
            try
            {
                //cn.Open();
                SqlCommand cmd = new SqlCommand("select a.NombreCompleto, b.Usuario, b.Password from Usuarios as b inner join empleados as a on a.Id = b.IdUsuario where b.Usuario = @Usuario and b.Password = @Password and a.Estado = 'A'", cn);
                cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dta = new DataTable();
                sda.Fill(dta);

                if (dta.Rows.Count > 0)
                {
                    MessageBox.Show("Bienvenido " + dta.Rows[0][0].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainTable.Datos.nombreAdm = dta.Rows[0][0].ToString();
                    Lobby lobby = new Lobby();
                    this.Hide();
                    lobby.Show();
                }

                else
                {
                    MessageBox.Show("Nombre de Usuario o Contraseña Incorrectos",
                    "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                cn.Close();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
