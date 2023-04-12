
namespace ClinicaMontefiori
{
    partial class Pacientes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.label2x = new System.Windows.Forms.Label();
            this.text_paterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_materno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_movil = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.text_fecha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.text_sexo = new System.Windows.Forms.TextBox();
            this.text_dni = new System.Windows.Forms.TextBox();
            this.text_telefono = new System.Windows.Forms.TextBox();
            this.text_correo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataTableCliente = new System.Windows.Forms.DataGridView();
            this.bnt_nuevo = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.text_id = new System.Windows.Forms.TextBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenimiento pacientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(122, 116);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(100, 20);
            this.text_nombre.TabIndex = 1;
            // 
            // label2x
            // 
            this.label2x.AutoSize = true;
            this.label2x.Location = new System.Drawing.Point(23, 120);
            this.label2x.Name = "label2x";
            this.label2x.Size = new System.Drawing.Size(44, 13);
            this.label2x.TabIndex = 2;
            this.label2x.Text = "Nombre";
            this.label2x.Click += new System.EventHandler(this.label2_Click);
            // 
            // text_paterno
            // 
            this.text_paterno.Location = new System.Drawing.Point(122, 147);
            this.text_paterno.Name = "text_paterno";
            this.text_paterno.Size = new System.Drawing.Size(100, 20);
            this.text_paterno.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido paterno";
            // 
            // text_materno
            // 
            this.text_materno.Location = new System.Drawing.Point(122, 179);
            this.text_materno.Name = "text_materno";
            this.text_materno.Size = new System.Drawing.Size(100, 20);
            this.text_materno.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Apellido Materno";
            // 
            // text_movil
            // 
            this.text_movil.Location = new System.Drawing.Point(567, 116);
            this.text_movil.Name = "text_movil";
            this.text_movil.Size = new System.Drawing.Size(100, 20);
            this.text_movil.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Numero movil";
            // 
            // text_fecha
            // 
            this.text_fecha.Location = new System.Drawing.Point(567, 147);
            this.text_fecha.Name = "text_fecha";
            this.text_fecha.Size = new System.Drawing.Size(100, 20);
            this.text_fecha.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Correo";
            // 
            // text_sexo
            // 
            this.text_sexo.Location = new System.Drawing.Point(313, 116);
            this.text_sexo.Name = "text_sexo";
            this.text_sexo.Size = new System.Drawing.Size(100, 20);
            this.text_sexo.TabIndex = 1;
            // 
            // text_dni
            // 
            this.text_dni.Location = new System.Drawing.Point(313, 147);
            this.text_dni.Name = "text_dni";
            this.text_dni.Size = new System.Drawing.Size(100, 20);
            this.text_dni.TabIndex = 1;
            // 
            // text_telefono
            // 
            this.text_telefono.Location = new System.Drawing.Point(313, 178);
            this.text_telefono.Name = "text_telefono";
            this.text_telefono.Size = new System.Drawing.Size(100, 20);
            this.text_telefono.TabIndex = 1;
            // 
            // text_correo
            // 
            this.text_correo.Location = new System.Drawing.Point(566, 179);
            this.text_correo.Name = "text_correo";
            this.text_correo.Size = new System.Drawing.Size(100, 20);
            this.text_correo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Sexo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(448, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Fecha de nacimiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Telefono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "DNI";
            // 
            // dataTableCliente
            // 
            this.dataTableCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTableCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableCliente.Location = new System.Drawing.Point(12, 228);
            this.dataTableCliente.Name = "dataTableCliente";
            this.dataTableCliente.ReadOnly = true;
            this.dataTableCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTableCliente.Size = new System.Drawing.Size(776, 210);
            this.dataTableCliente.TabIndex = 3;
            this.dataTableCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTableCliente_CellClick);
            this.dataTableCliente.SelectionChanged += new System.EventHandler(this.dataTableCliente_SelectionChanged);
            // 
            // bnt_nuevo
            // 
            this.bnt_nuevo.Location = new System.Drawing.Point(250, 83);
            this.bnt_nuevo.Name = "bnt_nuevo";
            this.bnt_nuevo.Size = new System.Drawing.Size(75, 23);
            this.bnt_nuevo.TabIndex = 4;
            this.bnt_nuevo.Text = "Nuevo";
            this.bnt_nuevo.UseVisualStyleBackColor = true;
            this.bnt_nuevo.Click += new System.EventHandler(this.bnt_nuevo_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(341, 83);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(75, 23);
            this.btn_editar.TabIndex = 4;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(429, 83);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 4;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Código";
            this.label11.Click += new System.EventHandler(this.label2_Click);
            // 
            // text_id
            // 
            this.text_id.Location = new System.Drawing.Point(122, 84);
            this.text_id.Name = "text_id";
            this.text_id.Size = new System.Drawing.Size(100, 20);
            this.text_id.TabIndex = 1;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(702, 146);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 4;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(702, 178);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 4;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // Pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.bnt_nuevo);
            this.Controls.Add(this.dataTableCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2x);
            this.Controls.Add(this.text_correo);
            this.Controls.Add(this.text_fecha);
            this.Controls.Add(this.text_telefono);
            this.Controls.Add(this.text_movil);
            this.Controls.Add(this.text_dni);
            this.Controls.Add(this.text_materno);
            this.Controls.Add(this.text_sexo);
            this.Controls.Add(this.text_paterno);
            this.Controls.Add(this.text_id);
            this.Controls.Add(this.text_nombre);
            this.Controls.Add(this.label1);
            this.Name = "Pacientes";
            this.Text = "Pacientes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.Label label2x;
        private System.Windows.Forms.TextBox text_paterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_materno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_movil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_fecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_sexo;
        private System.Windows.Forms.TextBox text_dni;
        private System.Windows.Forms.TextBox text_telefono;
        private System.Windows.Forms.TextBox text_correo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataTableCliente;
        private System.Windows.Forms.Button bnt_nuevo;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_id;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_eliminar;
    }
}

