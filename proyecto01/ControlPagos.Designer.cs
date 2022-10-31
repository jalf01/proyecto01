namespace NominaEmpleados
{
    partial class ControlPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comBoxMes = new System.Windows.Forms.ComboBox();
            this.lbAnio = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.fechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressB = new System.Windows.Forms.ProgressBar();
            this.lbCargando = new System.Windows.Forms.Label();
            this.TablaEmpleados = new System.Windows.Forms.DataGridView();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoSueldoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpleadoSFS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpleadoAFP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpleadoISR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadoSueldoNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comBoxMes);
            this.panel1.Controls.Add(this.lbAnio);
            this.panel1.Controls.Add(this.btnPagar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.fechaInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 152);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Teal;
            this.button2.Location = new System.Drawing.Point(987, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(308, 54);
            this.button2.TabIndex = 17;
            this.button2.Text = "&Mostrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(45, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(44, 51);
            this.txtDescripcion.MaxLength = 100;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(714, 30);
            this.txtDescripcion.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Teal;
            this.button3.Location = new System.Drawing.Point(591, 110);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 33);
            this.button3.TabIndex = 13;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(483, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comBoxMes
            // 
            this.comBoxMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxMes.FormattingEnabled = true;
            this.comBoxMes.Items.AddRange(new object[] {
            "Seleccione",
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio ",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.comBoxMes.Location = new System.Drawing.Point(115, 99);
            this.comBoxMes.Name = "comBoxMes";
            this.comBoxMes.Size = new System.Drawing.Size(299, 33);
            this.comBoxMes.TabIndex = 10;
            this.comBoxMes.SelectedIndexChanged += new System.EventHandler(this.comBoxMes_SelectedIndexChanged);
            // 
            // lbAnio
            // 
            this.lbAnio.AutoSize = true;
            this.lbAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbAnio.Location = new System.Drawing.Point(520, 115);
            this.lbAnio.Name = "lbAnio";
            this.lbAnio.Size = new System.Drawing.Size(60, 25);
            this.lbAnio.TabIndex = 9;
            this.lbAnio.Text = "2021";
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.Teal;
            this.btnPagar.Location = new System.Drawing.Point(987, 79);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(139, 61);
            this.btnPagar.TabIndex = 8;
            this.btnPagar.Text = "&Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Teal;
            this.btnSalir.Location = new System.Drawing.Point(1152, 79);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(143, 61);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // fechaInicio
            // 
            this.fechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaInicio.Location = new System.Drawing.Point(472, 12);
            this.fechaInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(217, 30);
            this.fechaInicio.TabIndex = 2;
            this.fechaInicio.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(522, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(39, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mes:";
            // 
            // progressB
            // 
            this.progressB.Location = new System.Drawing.Point(50, 603);
            this.progressB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressB.Name = "progressB";
            this.progressB.Size = new System.Drawing.Size(279, 35);
            this.progressB.TabIndex = 2;
            // 
            // lbCargando
            // 
            this.lbCargando.AutoSize = true;
            this.lbCargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCargando.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbCargando.Location = new System.Drawing.Point(341, 610);
            this.lbCargando.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCargando.Name = "lbCargando";
            this.lbCargando.Size = new System.Drawing.Size(104, 20);
            this.lbCargando.TabIndex = 3;
            this.lbCargando.Text = "Cargando...";
            // 
            // TablaEmpleados
            // 
            this.TablaEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TablaEmpleados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaEmpleados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empleado,
            this.empleadoNombre,
            this.empleadoCargo,
            this.empleadoSueldoBruto,
            this.EmpleadoSFS,
            this.EmpleadoAFP,
            this.EmpleadoISR,
            this.empleadoDescuento,
            this.empleadoSueldoNeto});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TablaEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            this.TablaEmpleados.Location = new System.Drawing.Point(4, 163);
            this.TablaEmpleados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TablaEmpleados.Name = "TablaEmpleados";
            this.TablaEmpleados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TablaEmpleados.RowHeadersVisible = false;
            this.TablaEmpleados.RowHeadersWidth = 62;
            this.TablaEmpleados.Size = new System.Drawing.Size(1315, 426);
            this.TablaEmpleados.TabIndex = 4;
            this.TablaEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // empleado
            // 
            this.empleado.HeaderText = "NO.";
            this.empleado.MinimumWidth = 8;
            this.empleado.Name = "empleado";
            this.empleado.ReadOnly = true;
            // 
            // empleadoNombre
            // 
            this.empleadoNombre.HeaderText = "Nombre Completo";
            this.empleadoNombre.MinimumWidth = 8;
            this.empleadoNombre.Name = "empleadoNombre";
            this.empleadoNombre.ReadOnly = true;
            // 
            // empleadoCargo
            // 
            this.empleadoCargo.HeaderText = "Cargo";
            this.empleadoCargo.MinimumWidth = 8;
            this.empleadoCargo.Name = "empleadoCargo";
            this.empleadoCargo.ReadOnly = true;
            // 
            // empleadoSueldoBruto
            // 
            this.empleadoSueldoBruto.HeaderText = "Sueldo Bruto";
            this.empleadoSueldoBruto.MinimumWidth = 8;
            this.empleadoSueldoBruto.Name = "empleadoSueldoBruto";
            this.empleadoSueldoBruto.ReadOnly = true;
            // 
            // EmpleadoSFS
            // 
            this.EmpleadoSFS.HeaderText = "SFS";
            this.EmpleadoSFS.MinimumWidth = 8;
            this.EmpleadoSFS.Name = "EmpleadoSFS";
            this.EmpleadoSFS.ReadOnly = true;
            // 
            // EmpleadoAFP
            // 
            this.EmpleadoAFP.HeaderText = "AFP";
            this.EmpleadoAFP.MinimumWidth = 8;
            this.EmpleadoAFP.Name = "EmpleadoAFP";
            this.EmpleadoAFP.ReadOnly = true;
            // 
            // EmpleadoISR
            // 
            this.EmpleadoISR.HeaderText = "ISR";
            this.EmpleadoISR.MinimumWidth = 8;
            this.EmpleadoISR.Name = "EmpleadoISR";
            this.EmpleadoISR.ReadOnly = true;
            // 
            // empleadoDescuento
            // 
            this.empleadoDescuento.HeaderText = "Descuento";
            this.empleadoDescuento.MinimumWidth = 8;
            this.empleadoDescuento.Name = "empleadoDescuento";
            this.empleadoDescuento.ReadOnly = true;
            // 
            // empleadoSueldoNeto
            // 
            this.empleadoSueldoNeto.HeaderText = "Sueldo Neto";
            this.empleadoSueldoNeto.MinimumWidth = 8;
            this.empleadoSueldoNeto.Name = "empleadoSueldoNeto";
            this.empleadoSueldoNeto.ReadOnly = true;
            // 
            // ControlPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1322, 654);
            this.Controls.Add(this.TablaEmpleados);
            this.Controls.Add(this.lbCargando);
            this.Controls.Add(this.progressB);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControlPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Pagos";
            this.Load += new System.EventHandler(this.ControlPagos_Load);
            this.Shown += new System.EventHandler(this.ControlPagos_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechaInicio;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ProgressBar progressB;
        private System.Windows.Forms.Label lbCargando;
        private System.Windows.Forms.DataGridView TablaEmpleados;
        private System.Windows.Forms.Label lbAnio;
        private System.Windows.Forms.ComboBox comBoxMes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoSueldoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpleadoSFS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpleadoAFP;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpleadoISR;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadoSueldoNeto;
    }
}