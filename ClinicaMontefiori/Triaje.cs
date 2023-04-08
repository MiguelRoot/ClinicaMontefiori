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
    public partial class Triaje : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        //Definimos un flag para realizar la inserción o actualización
        string flagAccion = "";
        public Triaje()
        {
            InitializeComponent();
        }


        private DataTable ListarTriaje()
        {
            SqlDataAdapter da = new SqlDataAdapter("triajeList", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        void habilitarCajasTexto(Boolean valor)
        {
            //Cuando valor = false -->Deshabilitamos las cajas de texto, los combo box y los datetimepicker
            //Cuando valor = true  -->Habilitamos las cajas de texto, los combo box y los datetimepicker
            txtIdCodigo.Enabled = valor;
            txtIdCliente.Enabled = valor;
            dtpFecha.Enabled = valor;
            txtTemperatura.Enabled = valor;
            txtPeso.Enabled = valor;
            txtFrecuenciaCardiaca.Enabled = valor;
            txtPresionarterial.Enabled = valor;
        }
        void habilitarBotones(Boolean valor)
        {
            //Cuando valor = false -->Deshabilitamos el DataGridView y los botones Editar y Eliminar 
            //Cuando valor = true  -->Habilitamos el DataGridView y los botones Editar y Eliminar
            dgvTriaje.Enabled = valor;
            btnEditar.Enabled = valor;
            btnEliminar.Enabled = valor;

            //Cuando valor = false --> Hacemos la negacion de false --> Habilitamos el boton Guardar(true)
            //Cuando valor = true  --> Hacemos la negacion de true  --> Deshabilitamos el boton Guardar(false)
            btnGuardar.Enabled = !valor;
        }
        void limpiar()
        {
            //Limpiamos las cajas de texto e inicializamos los combo box y datetimepicker 

            txtIdCodigo.Text = "";
            txtIdCliente.Text = "";
            dtpFecha.Value = DateTime.Today;
            txtTemperatura.Text = "";
            txtPeso.Text = "";
            txtFrecuenciaCardiaca.Text = "";
            txtPresionarterial.Text = "";

        }
        private void Form5_Load(object sender, EventArgs e)
        {

            dgvTriaje.DataSource = ListarTriaje();
        }
        void navegarEmpleados()
        {
            if (dgvTriaje.CurrentRow != null)
            {
                txtIdCodigo.Text = dgvTriaje.CurrentRow.Cells[0].Value.ToString();
                txtIdCliente.Text = dgvTriaje.CurrentRow.Cells[1].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(dgvTriaje.CurrentRow.Cells[2].Value.ToString());
                txtTemperatura.Text = dgvTriaje.CurrentRow.Cells[3].Value.ToString();
                txtPeso.Text = dgvTriaje.CurrentRow.Cells[4].Value.ToString();
                txtFrecuenciaCardiaca.Text = dgvTriaje.CurrentRow.Cells[5].Value.ToString();
                txtPresionarterial.Text = dgvTriaje.CurrentRow.Cells[6].Value.ToString();

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
            txtIdCodigo.Focus();
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
            txtIdCodigo.Focus();
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

                    SqlCommand cmd = new SqlCommand("usp_deleteTriaje", cn, trx);

                    cmd.CommandType = CommandType.StoredProcedure;



                    //Agregamos los parámetros

                    cmd.Parameters.AddWithValue("@id", txtIdCodigo.Text);



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

                dgvTriaje.DataSource = ListarTriaje();



                //Evaluamos el resultado

                if (resultado >= 1)

                    MessageBox.Show(resultado.ToString() + " registro(s) eliminado(s)",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else

                    MessageBox.Show("Eliminación no realizada",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);





            }
        }
    
        
        private void dgvTriaje_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            navegarEmpleados();
        }

        private void dgvTriaje_SelectionChanged(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("generar_id_Triaje", cn);
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

            txtIdCodigo.Text = secuencia.ToString();
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
                SqlCommand cmd = new SqlCommand("add_Triaje", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agregamos los parámetros
                cmd.Parameters.AddWithValue("@id", txtIdCodigo.Text);
                cmd.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text);
                cmd.Parameters.AddWithValue("@fecha", dtpFecha.Text);
                cmd.Parameters.AddWithValue("@temperatura", txtTemperatura.Text);
                cmd.Parameters.AddWithValue("@peso", txtPeso.Text);
                cmd.Parameters.AddWithValue("@presion_arterial", txtPresionarterial.Text);
                cmd.Parameters.AddWithValue("@frecuencia_cardiaca", txtFrecuenciaCardiaca.Text);


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
            dgvTriaje.DataSource = ListarTriaje();

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

                SqlCommand cmd = new SqlCommand("update_Triaje", cn, trx);

                cmd.CommandType = CommandType.StoredProcedure;



                //Agregamos los parámetros


                cmd.Parameters.AddWithValue("@id", txtIdCodigo.Text);
                cmd.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text);
                cmd.Parameters.AddWithValue("@fecha", dtpFecha.Text);
                cmd.Parameters.AddWithValue("@temperatura", txtTemperatura.Text);
                cmd.Parameters.AddWithValue("@peso", txtPeso.Text);
                cmd.Parameters.AddWithValue("@presion_arterial", txtPresionarterial.Text);
                cmd.Parameters.AddWithValue("@frecuencia_cardiaca", txtFrecuenciaCardiaca.Text);


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

            dgvTriaje.DataSource = ListarTriaje();



            //Evaluamos el resultado

            if (resultado >= 1)

                MessageBox.Show(resultado.ToString() + " Empleado(s) actualizado(s)",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else

                MessageBox.Show("Actualización no realizada",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}

