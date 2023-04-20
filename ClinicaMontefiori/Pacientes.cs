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
    public partial class Pacientes : Form
    {
        string flagAccion = "";
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public Pacientes()
        {
            InitializeComponent();
        }


        void formLimpiar()
        {
            text_nombre.Text = "";
            text_paterno.Text = "";
            text_materno.Text = "";
            text_fecha.Value = DateTime.Today;
            text_telefono.Text = "";
            text_nombre.Text = "";
            text_correo.Text = "";
            text_dni.Text = "";
            text_movil.Text = "";
            boxSex.SelectedValue = "M";
        }

        private DataTable cargarTable(string name_usp)
        {
            SqlDataAdapter da = new SqlDataAdapter(name_usp, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        void generaId()
        {
            int idnewDoctor = 0;
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("generar_id_cliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                idnewDoctor = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            text_id.Text = idnewDoctor.ToString();
        }

        void registroPaciente()
        {
            int resultado = 0;
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                SqlCommand cmd = new SqlCommand("add_cliente", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", text_id.Text);
                cmd.Parameters.AddWithValue("@id_recepcionista", 1);
                cmd.Parameters.AddWithValue("@nombre", text_nombre.Text);
                cmd.Parameters.AddWithValue("@apellido_paterno", text_paterno.Text);
                cmd.Parameters.AddWithValue("@apellido_materno", text_materno.Text);
                cmd.Parameters.AddWithValue("@dni", text_dni.Text);
                cmd.Parameters.AddWithValue("@sexo", boxSex.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@fecha_nacimiento", text_fecha.Value);
                cmd.Parameters.AddWithValue("@telefono", text_telefono.Text);
                cmd.Parameters.AddWithValue("@numero_movil", text_movil.Text);
                cmd.Parameters.AddWithValue("@correo", text_correo.Text);

                resultado = cmd.ExecuteNonQuery();
                trx.Commit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }
            if (resultado >= 1)
            {
            dataTableCliente.DataSource = cargarTable("clienteList");
                MessageBox.Show("Doctor Agregado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //statusFormDefaulot();
            }
            else
            {
                MessageBox.Show("Registro no realizado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void updatePaciente()
        {
            int resultado = 0;
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                SqlCommand cmd = new SqlCommand("update_cliente", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", text_id.Text);
                cmd.Parameters.AddWithValue("@id_recepcionista", 1);
                cmd.Parameters.AddWithValue("@nombre", text_nombre.Text);
                cmd.Parameters.AddWithValue("@apellido_paterno", text_paterno.Text);
                cmd.Parameters.AddWithValue("@apellido_materno", text_materno.Text);
                cmd.Parameters.AddWithValue("@dni", text_dni.Text);
                cmd.Parameters.AddWithValue("@sexo", boxSex.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@fecha_nacimiento", text_fecha.Text);
                cmd.Parameters.AddWithValue("@telefono", text_telefono.Text);
                cmd.Parameters.AddWithValue("@numero_movil", text_movil.Text);
                cmd.Parameters.AddWithValue("@correo", text_correo.Text);

                resultado = cmd.ExecuteNonQuery();
                trx.Commit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                trx.Rollback();
            }
            finally
            {
                cn.Close();
            }

            if (resultado >= 1)
            {
                dataTableCliente.DataSource = cargarTable("clienteList");
                MessageBox.Show("Paciente actulizado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //statusFormDefaulot();
            }
            else
            {
                MessageBox.Show("Registro no realizado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        void statusFormDefaulot()
        {
            btn_cancelar.Enabled = false;
            btn_guardar.Enabled = false;
            btn_nuevo.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;

            text_id.Enabled = false;
            text_nombre.Enabled = false;
            text_paterno.Enabled = false;
            text_materno.Enabled = false;
            text_fecha.Enabled = false;
            text_telefono.Enabled = false;
            text_nombre.Enabled = false;
            text_correo.Enabled = false;
            text_dni.Enabled = false;
            text_movil.Enabled = false;
            boxSex.Enabled = false;

            dataTableCliente.Enabled = true;
        }

        void statusBtnNuevo()
        {
            btn_cancelar.Enabled = true;
            btn_guardar.Enabled = true;
            btn_nuevo.Enabled = false;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;

            text_id.Enabled = true;
            text_nombre.Enabled = true;
            text_paterno.Enabled = true;
            text_materno.Enabled = true;
            text_fecha.Enabled = true;
            text_telefono.Enabled = true;
            text_nombre.Enabled = true;
            text_correo.Enabled = true;
            text_dni.Enabled = true;
            text_movil.Enabled = true;
            boxSex.Enabled = true;

            dataTableCliente.Enabled = false;
        }

        void statusBtnEdit()
        {
            btn_cancelar.Enabled = true;
            btn_guardar.Enabled = true;
            btn_nuevo.Enabled = true;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;

            text_id.Enabled = true;
            text_nombre.Enabled = true;
            text_paterno.Enabled = true;
            text_materno.Enabled = true;
            text_fecha.Enabled = true;
            text_telefono.Enabled = true;
            text_nombre.Enabled = true;
            text_correo.Enabled = true;
            text_dni.Enabled = true;
            text_movil.Enabled = true;
            boxSex.Enabled = true;

            dataTableCliente.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            List<object> opciones = new List<object>();
            opciones.Add(new { Text = "Hombre", Value = "M" });
            opciones.Add(new { Text = "Mujer", Value = "F" });
            boxSex.DataSource = opciones;
            boxSex.DisplayMember = "Text";
            boxSex.ValueMember = "Value";



            dataTableCliente.DataSource = cargarTable("clienteList");
            statusFormDefaulot();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bnt_nuevo_Click(object sender, EventArgs e)
        {
            flagAccion = "Nuevo";
            generaId();
            formLimpiar();
            statusBtnNuevo();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            flagAccion = "Editar";
            statusBtnEdit();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

            dataTableCliente.DataSource = cargarTable("clienteList");
            statusFormDefaulot();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (flagAccion.Equals("Nuevo"))
            {
                registroPaciente();
            }
            else
            {
                updatePaciente();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Esta seguro de eliminar el proyecto seleccionado?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                int resultado = 0;
                cn.Open();
                SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);

                try
                {
                    SqlCommand cmd = new SqlCommand("datele_cliente", cn, trx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", text_id.Text);
                    resultado = cmd.ExecuteNonQuery();
                    trx.Commit();

                }

                catch (SqlException ex)

                {
                    MessageBox.Show(ex.Message);
                    trx.Rollback();

                }

                finally
                {
                    cn.Close();

                }
               

                if (resultado >= 1)
                {
                    dataTableCliente.DataSource = cargarTable("clienteList");
                    MessageBox.Show(resultado.ToString() + " Paciente eliminado",
                          "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Eliminación no realizada",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        void ActualizarControl(Control control, string columna)
        {
            if (dataTableCliente.CurrentRow == null)
            {
                return;
            }
            var valorCelda = dataTableCliente.CurrentRow.Cells[columna].Value;
            var propiedad = control.GetType().GetProperty("Text");
            propiedad.SetValue(control, Convert.ToString(valorCelda));
        }

        void navegaTable()
        {
            ActualizarControl(text_id, "id");
            ActualizarControl(text_nombre, "nombre");
            ActualizarControl(text_paterno, "apellido_paterno");
            ActualizarControl(text_materno, "apellido_materno");
            boxSex.SelectedValue = dataTableCliente.CurrentRow.Cells["sexo"].Value;
            ActualizarControl(text_dni, "dni");
            text_fecha.Value = Convert.ToDateTime(dataTableCliente.CurrentRow.Cells[7].Value.ToString());
            //ActualizarControl(text_fecha, "fecha_nacimiento");
            ActualizarControl(text_telefono, "telefono");
            ActualizarControl(text_movil, "numero_movil");
            ActualizarControl(text_correo, "correo");
        }

        private void dataTableCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            navegaTable();
        }

        private void dataTableCliente_SelectionChanged(object sender, EventArgs e)
        {
            navegaTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
