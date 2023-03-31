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

    public partial class FormDoctor : Form
    {
        string flagAccion = "";
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public FormDoctor()
        {
            InitializeComponent();
        }

        //cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@id", textId.Text);
        //        cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
        //        cmd.Parameters.AddWithValue("@apellido_paterno", textPaterno.Text);
        //        cmd.Parameters.AddWithValue("@apellido_materno", textMaterno.Text);
        //        cmd.Parameters.AddWithValue("@dni", textDni.Text);
        //        cmd.Parameters.AddWithValue("@especialidad", textEspecialidad.Text);

        void formLimpiar()
        {
            textNombre.Text = "";
            textPaterno.Text = "";
            textMaterno.Text = "";
            textDni.Text = "";
            textEspecialidad.Text = "";
        }

        void statusFormDefaulot()
        {
            btn_cancelar.Enabled = false;
            btn_guardar.Enabled = false;
            btn_nuevo.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = true;

            textId.Enabled = false;
            textNombre.Enabled = false;
            textPaterno.Enabled = false;
            textMaterno.Enabled = false;
            textDni.Enabled = false;
            textEspecialidad.Enabled = false;
            dataTableDoctor.Enabled = true;
        }


        void statusFormNuevo()
        {
            btn_cancelar.Enabled = true;
            btn_guardar.Enabled = true;
            btn_nuevo.Enabled = true;
            btn_editar.Enabled = false;
            btn_eliminar.Enabled = false;

            textId.Enabled = true;
            textNombre.Enabled = true;
            textPaterno.Enabled = true;
            textMaterno.Enabled = true;
            textDni.Enabled = true;
            textEspecialidad.Enabled = true;
            dataTableDoctor.Enabled = false;
        }


        void statusFormEditar()
        {
            btn_cancelar.Enabled = true;
            btn_guardar.Enabled = true;
            btn_nuevo.Enabled = true;
            btn_editar.Enabled = true;
            btn_eliminar.Enabled = false;

            textId.Enabled = true;
            textNombre.Enabled = true;
            textPaterno.Enabled = true;
            textMaterno.Enabled = true;
            textDni.Enabled = true;
            textEspecialidad.Enabled = true;
            dataTableDoctor.Enabled = false;
        }


        void generaId()
        {
            int idnewDoctor = 0;
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("generar_id_doctor", cn);
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

            textId.Text = idnewDoctor.ToString();
        }


        void registroDoctor()
        {
            int resultado = 0;
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                SqlCommand cmd = new SqlCommand("add_doctor", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", textId.Text);
                cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_paterno", textPaterno.Text);
                cmd.Parameters.AddWithValue("@apellido_materno", textMaterno.Text);
                cmd.Parameters.AddWithValue("@dni", textDni.Text);
                cmd.Parameters.AddWithValue("@especialidad", textEspecialidad.Text);

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
            dataTableDoctor.DataSource = cargarTable("doctorList");
            if (resultado >= 1)
            {
                MessageBox.Show("Doctor Agregado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusFormDefaulot();
            }
            else
            {
                MessageBox.Show("Registro no realizado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }




        private DataTable cargarTable(string name_usp)
        {
            // comentario test
            SqlDataAdapter da = new SqlDataAdapter(name_usp, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        void updateDoctor()
        {
            int resultado = 0;
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {

                SqlCommand cmd = new SqlCommand("update_doctor", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", textId.Text);
                cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
                cmd.Parameters.AddWithValue("@apellido_paterno", textPaterno.Text);
                cmd.Parameters.AddWithValue("@apellido_materno", textMaterno.Text);
                cmd.Parameters.AddWithValue("@dni", textDni.Text);
                cmd.Parameters.AddWithValue("@especialidad", textEspecialidad.Text);

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

            dataTableDoctor.DataSource = cargarTable("doctorList");

            if (resultado >= 1)
            {
                MessageBox.Show("Proyecto actualizado",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusFormDefaulot();
            }

            else
            {
                MessageBox.Show("No se pudo Actulizar",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataTableDoctor.DataSource = cargarTable("doctorList");
            statusFormDefaulot();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flagAccion.Equals("Nuevo"))
            {
                registroDoctor();
            }
            else
            {
                updateDoctor();
            }
            dataTableDoctor.DataSource = cargarTable("doctorList");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flagAccion = "Nuevo";
            statusFormNuevo();
            generaId();
            formLimpiar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flagAccion = "Editar";
            statusFormEditar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            statusFormDefaulot();
            dataTableDoctor.DataSource = cargarTable("doctorList");
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
                    SqlCommand cmd = new SqlCommand("datele_doctor", cn, trx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", textId.Text);
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
                dataTableDoctor.DataSource = cargarTable("doctorList");

                if (resultado >= 1)
                {
                    MessageBox.Show(resultado.ToString() + " proyecto eliminado",
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
            if (dataTableDoctor.CurrentRow == null)
            {
                return;
            }
            var valorCelda = dataTableDoctor.CurrentRow.Cells[columna].Value;
            var propiedad = control.GetType().GetProperty("Text");
            propiedad.SetValue(control, Convert.ToString(valorCelda));
        }


        void navegaTable()
        {
            ActualizarControl(textId, "id");
            ActualizarControl(textNombre, "nombre");
            ActualizarControl(textPaterno, "apellido_paterno");
            ActualizarControl(textMaterno, "apellido_materno");
            ActualizarControl(textDni, "dni");
            ActualizarControl(textEspecialidad, "especialidad");
        }

        private void dataTableDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            navegaTable();
        }

        private void dataTableDoctor_SelectionChanged(object sender, EventArgs e)
        {
            navegaTable();
        }
    }
}
