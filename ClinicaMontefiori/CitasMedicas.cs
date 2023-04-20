using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace ClinicaMontefiori
{
    public partial class CitasMedicas : Form
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        //Definimos un flag para realizar la inserción o actualización
        string flagAccion = "";
        public CitasMedicas()
        {
            InitializeComponent();
        }

        private DataTable ListarCita()
        {
            SqlDataAdapter da = new SqlDataAdapter("clitasList", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        void habilitarCajasTexto(Boolean valor)
        {
            //Cuando valor = false -->Deshabilitamos las cajas de texto, los combo box y los datetimepicker
            //Cuando valor = true  -->Habilitamos las cajas de texto, los combo box y los datetimepicker
            txtCodigo.Enabled = valor;
            boxPacientes.Enabled = valor;
            boxRecepcionistas.Enabled = valor;
            boxDoctor.Enabled = valor;
            dtpfecha.Enabled = valor;
            dtphora.Enabled = valor;
           txtDuracion.Enabled = valor;
        }
        void habilitarBotones(Boolean valor)
        {
            //Cuando valor = false -->Deshabilitamos el DataGridView y los botones Editar y Eliminar 
            //Cuando valor = true  -->Habilitamos el DataGridView y los botones Editar y Eliminar
            dgvCitas.Enabled = valor;
            btnEditar.Enabled = valor;
            btnEliminar.Enabled = valor;

            //Cuando valor = false --> Hacemos la negacion de false --> Habilitamos el boton Guardar(true)
            //Cuando valor = true  --> Hacemos la negacion de true  --> Deshabilitamos el boton Guardar(false)
            btnGuardar.Enabled = !valor;
        }
        void limpiar()
        {
            //Limpiamos las cajas de texto e inicializamos los combo box y datetimepicker 

            txtCodigo.Text = "";
            boxPacientes.SelectedIndex = 0;
            boxRecepcionistas.SelectedIndex = 0;
            boxDoctor.SelectedIndex = 0;
            dtpfecha.Value = DateTime.Today;
            dtphora.Value = DateTime.Today;
            txtDuracion.Text = "";
        }
         private void Form4_Load(object sender, EventArgs e)
        {
            dgvCitas.DataSource = ListarCita();
            dgvCitas.Columns["id_cliente"].Visible = false;
            dgvCitas.Columns["id_doctor"].Visible = false;
            dgvCitas.Columns["id_recepcionista"].Visible = false;

            boxPacientes.DataSource = getProcedureName("Lista_paciente_cbo");
            boxPacientes.DisplayMember = "nombre";
            boxPacientes.ValueMember = "id";

            boxRecepcionistas.DataSource = getProcedureName("Lista_recepcionista_cbo");
            boxRecepcionistas.DisplayMember = "nombre";
            boxRecepcionistas.ValueMember = "id";

            boxDoctor.DataSource = getProcedureName("Lista_doctor_cbo");
            boxDoctor.DisplayMember = "nombre";
            boxDoctor.ValueMember = "id";

        }

        DataTable getProcedureName(string procedureName)
        {
            SqlDataAdapter da = new SqlDataAdapter(procedureName, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        void navegarEmpleados()
        {
            if (dgvCitas.CurrentRow != null)
            {
                txtCodigo.Text = dgvCitas.CurrentRow.Cells[0].Value.ToString();
                //txtCliente.Text = dgvCitas.CurrentRow.Cells[1].Value.ToString();
                //txtRecepcionista.Text = dgvCitas.CurrentRow.Cells[2].Value.ToString();
                //txtDoctor.Text = dgvCitas.CurrentRow.Cells[3].Value.ToString();

                dtpfecha.Value = Convert.ToDateTime(dgvCitas.CurrentRow.Cells[4].Value.ToString());
                dtphora.Value = Convert.ToDateTime(dgvCitas.CurrentRow.Cells[5].Value.ToString());

                boxPacientes.SelectedValue = int.Parse(dgvCitas.CurrentRow.Cells["id_cliente"].Value.ToString());
                boxDoctor.SelectedValue = int.Parse(dgvCitas.CurrentRow.Cells["id_doctor"].Value.ToString());
                boxRecepcionistas.SelectedValue = int.Parse(dgvCitas.CurrentRow.Cells["id_recepcionista"].Value.ToString());

                txtDuracion.Text = dgvCitas.CurrentRow.Cells[6].Value.ToString();

            }
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            flagAccion = "Nuevo";

            //Limpiamos las cajas de texto e inicializamos los combo box y datetimepicker
            limpiar();

            //Cuando valor = true  -->Habilitamos las cajas de texto, los combo box y los datetimepicker
            habilitarCajasTexto(true);

            //Cuando valor = false -->Deshabilitamos el DataGridView y los botones Editar y Eliminar  
            //                     -->Hacemos la negacion de false(true) para Habilitar el boton Guardar(true)         
            habilitarBotones(false);

            //Seleccionamos el Focus del control TextBox txtCodigo
            txtCodigo.Focus();
            //////////////////////////////////////////


            obtenerSecuenciaEmpleado();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            flagAccion = "Editar";

            //Cuando valor = true  -->Habilitamos las cajas de texto, los combo box y los datetimepicker
            habilitarCajasTexto(true);

            //Habilitamos el boton Guardar --> True
            btnGuardar.Enabled = true;

            //Deshabilitamos el boton Eliminar --> False
            btnEliminar.Enabled = false;

            //Seleccionamos el Focus del control TextBox txtNombre
            txtCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Limpiamos las cajas de texto e inicializamos los combo box y datetimepicker
            limpiar();

            //Cuando valor = false -->Deshabilitamos las cajas de texto, los combo box y los datetimepicker
            habilitarCajasTexto(false);

            //Cuando valor = true -->Habilitamos el DataGridView y los botones Editar y Eliminar  
            //                    -->Hacemos la negacion de true (false) para deshabilitar el boton Guardar(false)  
            habilitarBotones(true);

            navegarEmpleados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (flagAccion.Equals("Nuevo"))
            {
                //Programamos el registro de empleado
                registrarEmpleado();

            }
            else
            {
                //Programamos la actualización de empleado
                actualizarEmpleado();


            }

            //Limpiamos las cajas de texto e inicializamos los combo box y datetimepicker
            limpiar();

            //Cuando valor = false -->Deshabilitamos las cajas de texto, los combo box y los datetimepicker
            habilitarCajasTexto(false);

            //Cuando valor = true -->Habilitamos el DataGridView y los botones Editar y Eliminar  
            //                    -->Hacemos la negacion de true (false) para deshabilitar el boton Guardar(false)  
            habilitarBotones(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Esta seguro de eliminar el registro(s) seleccionado(s)?",
                                                           "Confirmación",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                //Programamos la eliminación del registro seleccionado           
                int resultado = 0;

                //Abrir conexión

                cn.Open();

                //Se define la transacción

                SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);



                try
                {

                    //Definimos el SqlCommand, le asignamos la transacción y definimos el CommandType

                    SqlCommand cmd = new SqlCommand("usp_deleteCitas", cn, trx);

                    cmd.CommandType = CommandType.StoredProcedure;



                    //Agregamos los parámetros

                    cmd.Parameters.AddWithValue("@id", txtCodigo.Text);



                    //Ejecutamos el SqlCommand

                    resultado = cmd.ExecuteNonQuery();



                    //Confirmamos la transacción en la base de datos

                    trx.Commit();

                }

                catch (SqlException ex)

                {

                    MessageBox.Show(ex.Message);

                    //Revertimos la transacción en la base de datos

                    trx.Rollback();

                }

                finally

                {

                    cn.Close();

                }

                //Mostramos la lista de clientes en el DataGridView

                dgvCitas.DataSource = ListarCita();



                //Evaluamos el resultado

                if (resultado >= 1)

                    MessageBox.Show(resultado.ToString() + " registro(s) eliminado(s)",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else

                    MessageBox.Show("Eliminación no realizada",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);





            }
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            navegarEmpleados();
        }

        private void dgvCitas_SelectionChanged(object sender, EventArgs e)
        {
            navegarEmpleados();
        }
        void obtenerSecuenciaEmpleado()
        {
            int secuencia = 0;
            //Abrir conexión
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("generar_id_Citas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                secuencia = (int)cmd.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                cn.Close();
            }

            txtCodigo.Text = secuencia.ToString();
        }
        void registrarEmpleado()
        {
            int resultado = 0;
            //Abrir conexión
            cn.Open();
            //Se define la transacción
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                //Definimos el SqlCommand, le asignamos la transacción y definimos el CommandType
                SqlCommand cmd = new SqlCommand("add_Citas", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agregamos los parámetros
                cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@id_recepcionista", boxRecepcionistas.SelectedValue);
                cmd.Parameters.AddWithValue("@id_cliente", boxPacientes.SelectedValue);
                cmd.Parameters.AddWithValue("@id_doctor", boxDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha", dtpfecha.Value);
                cmd.Parameters.AddWithValue("@fecha_hora", dtphora.Value);
                cmd.Parameters.AddWithValue("@duracion", txtDuracion.Text);


                //Ejecutamos el SqlCommand
                resultado = cmd.ExecuteNonQuery();
                //Confirmamos la transacción en la base de datos
                trx.Commit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                //Revertimos la transacción en la base de datos
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }
            //Mostramos la lista de clientes en el DataGridView
            dgvCitas.DataSource = ListarCita();

            //Evaluamos el resultado
            if (resultado >= 1)
                MessageBox.Show("Empleado Agregado",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Registro no realizado",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void actualizarEmpleado()
        {

            int resultado = 0;

            //Abrir conexión

            cn.Open();

            //Se define la transacción

            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);



            try

            {

                //Definimos el SqlCommand, le asignamos la transacción y definimos el CommandType

                SqlCommand cmd = new SqlCommand("update_Citas", cn, trx);

                cmd.CommandType = CommandType.StoredProcedure;



                //Agregamos los parámetros


                cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@id_recepcionista", boxRecepcionistas.SelectedValue);
                cmd.Parameters.AddWithValue("@id_cliente", boxPacientes.SelectedValue);
                cmd.Parameters.AddWithValue("@id_doctor", boxDoctor.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha", dtpfecha.Value);
                cmd.Parameters.AddWithValue("@fecha_hora", dtphora.Value);
                cmd.Parameters.AddWithValue("@duracion", txtDuracion.Text);


                //Ejecutamos el SqlCommand

                resultado = cmd.ExecuteNonQuery();

                //Confirmamos la transacción en la base de datos

                trx.Commit();

            }

            catch (SqlException ex)

            {

                MessageBox.Show(ex.Message);

                //Revertimos la transacción en la base de datos

                trx.Rollback();

            }

            finally

            {

                cn.Close();

            }

            //Mostramos la lista de clientes en el DataGridView

            dgvCitas.DataSource = ListarCita();



            //Evaluamos el resultado

            if (resultado >= 1)

                MessageBox.Show(resultado.ToString() + " Empleado(s) actualizado(s)",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else

                MessageBox.Show("Actualización no realizada",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCitas.Columns[e.ColumnIndex].Name == "fecha_hora")
            {
                if (e.Value != null)
                {
                    DateTime fecha = (DateTime)e.Value;
                    e.Value = fecha.ToString("HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtphora_MouseDown(object sender, MouseEventArgs e)
        {
            dtphora.CustomFormat = "HH:mm";
        }
    }
}
