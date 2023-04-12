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

        void registroDoctor()
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
                cmd.Parameters.AddWithValue("@sexo", text_sexo.Text);
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
            dataTableCliente.DataSource = cargarTable("clienteList");
            if (resultado >= 1)
            {
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



        private void Form1_Load(object sender, EventArgs e)
        {

            dataTableCliente.DataSource = cargarTable("clienteList");

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
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            flagAccion = "Editar";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

            dataTableCliente.DataSource = cargarTable("doctorList");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            registroDoctor();
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
                dataTableCliente.DataSource = cargarTable("clienteList");

                if (resultado >= 1)
                {
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
            ActualizarControl(text_sexo, "sexo");
            ActualizarControl(text_fecha, "fecha_nacimiento");
            ActualizarControl(text_telefono, "telefono");
            ActualizarControl(text_nombre, "numero_movil");
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
    }
}
