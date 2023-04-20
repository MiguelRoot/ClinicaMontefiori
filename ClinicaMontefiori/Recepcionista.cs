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
using static System.Net.Mime.MediaTypeNames;

namespace ClinicaMontefiori
{
    public partial class Recepcionista : Form
    {
        string flagAccion = "";
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public Recepcionista()
        {
            InitializeComponent();
        }

        private DataTable ListarRecepcionista()
        {
            SqlDataAdapter da = new SqlDataAdapter("RecepcionistaList", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        void habilitarCajasTexto(Boolean valor)
        {
            //Cuando valor = false -->Deshabilitamos las cajas de texto, los combo box y los datetimepicker
            //Cuando valor = true  -->Habilitamos las cajas de texto, los combo box y los datetimepicker
            txtCodigo.Enabled = valor;
            txtNombre.Enabled = valor;
            txtApellidoPaterno.Enabled = valor;
            txtApellidoMaterno.Enabled = valor;
            txtDNI.Enabled = valor;
            txtnumero_movil.Enabled = valor;

        }
        void habilitarBotones(Boolean valor)
        {
            //Cuando valor = false -->Deshabilitamos el DataGridView y los botones Editar y Eliminar 
            //Cuando valor = true  -->Habilitamos el DataGridView y los botones Editar y Eliminar
            dgvRecepcionista.Enabled = valor;
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
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtDNI.Text = "";
            txtnumero_movil.Text = "";
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            dgvRecepcionista.DataSource = ListarRecepcionista();
        }


        void navegarEmpleados()
        {
            if (dgvRecepcionista.CurrentRow != null)
            {
                txtCodigo.Text = dgvRecepcionista.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvRecepcionista.CurrentRow.Cells[1].Value.ToString();
                txtApellidoPaterno.Text = dgvRecepcionista.CurrentRow.Cells[2].Value.ToString();
                txtApellidoMaterno.Text = dgvRecepcionista.CurrentRow.Cells[3].Value.ToString();
                txtDNI.Text = dgvRecepcionista.CurrentRow.Cells[4].Value.ToString();
                txtnumero_movil.Text = dgvRecepcionista.CurrentRow.Cells[5].Value.ToString();


            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
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

        private void bntEditar_Click(object sender, EventArgs e)
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

        private void dgvRecepcionista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            navegarEmpleados();
        }

        private void dgvRecepcionista_SelectionChanged(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("generar_id_recepcionista", cn);
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
                SqlCommand cmd = new SqlCommand("add_recepcionista", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agregamos los parámetros
                cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_paterno", txtApellidoPaterno.Text);
                cmd.Parameters.AddWithValue("@apellido_materno", txtApellidoMaterno.Text);
                cmd.Parameters.AddWithValue("@dni", txtDNI.Text);
                cmd.Parameters.AddWithValue("@numeromovil", txtnumero_movil.Text);


                //Ejecutamos el SqlCommand
                resultado = cmd.ExecuteNonQuery();
                //Confirmamos la transacción en la base de datos
                trx.Commit();
            }
            catch (SqlException ex)
            {

                string message = "";
                if (ex.Number == 8114)
                {
                    message = "Valores del formulario invalidos, por favor revise los campos";
                }
                else
                {
                    message = ex.Message;
                }

                MessageBox.Show(message);
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }
            //Mostramos la lista de clientes en el DataGridView

            dgvRecepcionista.DataSource = ListarRecepcionista();
            //Evaluamos el resultado
            if (resultado >= 1)
            {

                MessageBox.Show("Empleado Agregado",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

                SqlCommand cmd = new SqlCommand("update_recepcionista", cn, trx);

                cmd.CommandType = CommandType.StoredProcedure;




                //Agregamos los parámetros
                cmd.Parameters.AddWithValue("@id", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_paterno", txtApellidoPaterno.Text);
                cmd.Parameters.AddWithValue("@apellido_materno", txtApellidoMaterno.Text);
                cmd.Parameters.AddWithValue("@dni", txtDNI.Text);
                cmd.Parameters.AddWithValue("@numeromovil", txtnumero_movil.Text);



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

            dgvRecepcionista.DataSource = ListarRecepcionista();



            //Evaluamos el resultado

            if (resultado >= 1)

                MessageBox.Show(resultado.ToString() + " Empleado(s) actualizado(s)",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else

                MessageBox.Show("Actualización no realizada",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                    SqlCommand cmd = new SqlCommand("datele_recepcionista", cn, trx);

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

                dgvRecepcionista.DataSource = ListarRecepcionista();



                //Evaluamos el resultado

                if (resultado >= 1)

                    MessageBox.Show(resultado.ToString() + " registro(s) eliminado(s)",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else

                    MessageBox.Show("Eliminación no realizada",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}

