
namespace ClinicaMontefiori
{
    partial class HistorialClinico
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
            this.dataTableHistorial = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCodigo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.cbo1 = new System.Windows.Forms.ComboBox();
            this.cbo2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Consulta historial clínico";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataTableHistorial
            // 
            this.dataTableHistorial.AllowUserToAddRows = false;
            this.dataTableHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableHistorial.Location = new System.Drawing.Point(12, 241);
            this.dataTableHistorial.Name = "dataTableHistorial";
            this.dataTableHistorial.ReadOnly = true;
            this.dataTableHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataTableHistorial.Size = new System.Drawing.Size(776, 197);
            this.dataTableHistorial.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(100, 158);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(220, 59);
            this.textBox3.TabIndex = 23;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(406, 158);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(220, 59);
            this.textBox4.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Diagnostico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tratamiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Paciente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Doctor";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(506, 119);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(448, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Fecha";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(343, 87);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 23);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Editar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(451, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCodigo
            // 
            this.btnCodigo.Location = new System.Drawing.Point(235, 87);
            this.btnCodigo.Name = "btnCodigo";
            this.btnCodigo.Size = new System.Drawing.Size(99, 23);
            this.btnCodigo.TabIndex = 28;
            this.btnCodigo.Text = "Nuevo";
            this.btnCodigo.UseVisualStyleBackColor = true;
            this.btnCodigo.Click += new System.EventHandler(this.btnCodigo_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(673, 194);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 23);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(673, 164);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(99, 23);
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.Text = "Guardar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(30, 95);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 31;
            this.lblCodigo.Text = "Código";
            // 
            // cbo1
            // 
            this.cbo1.FormattingEnabled = true;
            this.cbo1.Location = new System.Drawing.Point(301, 119);
            this.cbo1.Name = "cbo1";
            this.cbo1.Size = new System.Drawing.Size(121, 21);
            this.cbo1.TabIndex = 33;
            // 
            // cbo2
            // 
            this.cbo2.FormattingEnabled = true;
            this.cbo2.Location = new System.Drawing.Point(100, 119);
            this.cbo2.Name = "cbo2";
            this.cbo2.Size = new System.Drawing.Size(121, 21);
            this.cbo2.TabIndex = 34;
            // 
            // HistorialClinico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbo2);
            this.Controls.Add(this.cbo1);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCodigo);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataTableHistorial);
            this.Controls.Add(this.label1);
            this.Name = "HistorialClinico";
            this.Text = "Consulta historial clínico";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataTableHistorial;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCodigo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cbo1;
        private System.Windows.Forms.ComboBox cbo2;
    }
}