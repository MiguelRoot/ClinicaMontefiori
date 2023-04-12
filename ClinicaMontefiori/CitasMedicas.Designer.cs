
namespace ClinicaMontefiori
{
    partial class CitasMedicas
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.dtphora = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCodigo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRecepcionista = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mantenimiento citas medicas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(92, 82);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(48, 20);
            this.txtCodigo.TabIndex = 3;
            // 
            // dtpfecha
            // 
            this.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha.Location = new System.Drawing.Point(92, 153);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(122, 20);
            this.dtpfecha.TabIndex = 4;
            // 
            // dtphora
            // 
            this.dtphora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtphora.Location = new System.Drawing.Point(314, 153);
            this.dtphora.Name = "dtphora";
            this.dtphora.Size = new System.Drawing.Size(120, 20);
            this.dtphora.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IdCodigo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hora";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Duración";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(601, 82);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(682, 81);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(59, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCodigo
            // 
            this.btnCodigo.Location = new System.Drawing.Point(524, 81);
            this.btnCodigo.Name = "btnCodigo";
            this.btnCodigo.Size = new System.Drawing.Size(71, 23);
            this.btnCodigo.TabIndex = 14;
            this.btnCodigo.Text = "Nuevo";
            this.btnCodigo.UseVisualStyleBackColor = true;
            this.btnCodigo.Click += new System.EventHandler(this.btnCodigo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(671, 151);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 23);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(671, 117);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(99, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(233, 119);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(122, 20);
            this.txtDuracion.TabIndex = 18;
            // 
            // dgvCitas
            // 
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Location = new System.Drawing.Point(28, 196);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersWidth = 56;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(728, 216);
            this.dgvCitas.TabIndex = 41;
            this.dgvCitas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCitas_CellClick);
            this.dgvCitas.SelectionChanged += new System.EventHandler(this.dgvCitas_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "IdRecepcionista";
            // 
            // txtRecepcionista
            // 
            this.txtRecepcionista.Location = new System.Drawing.Point(233, 83);
            this.txtRecepcionista.Name = "txtRecepcionista";
            this.txtRecepcionista.Size = new System.Drawing.Size(42, 20);
            this.txtRecepcionista.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "IdCliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(335, 83);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCliente.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "idDoctor";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(92, 114);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(55, 20);
            this.txtDoctor.TabIndex = 47;
            // 
            // CitasMedicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRecepcionista);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCodigo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtphora);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Name = "CitasMedicas";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.DateTimePicker dtphora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCodigo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRecepcionista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDoctor;
    }
}