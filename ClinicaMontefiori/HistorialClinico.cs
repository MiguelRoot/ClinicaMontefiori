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
    public partial class HistorialClinico : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        string flagAccion = "";
        public HistorialClinico()
        {
            InitializeComponent();
        }

        private DataTable ListarHistorial()
        {
            SqlDataAdapter da = new SqlDataAdapter("historialClinicoList", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        void formLimpiar()
        {
            textBox1.Text = "";
            cboxDoctor.SelectedIndex = 0;
            //textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }


        void formInitDefault()
        {
            textBox3.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            cboxPaciente.SelectedIndex = 0;
            cboxDoctor.SelectedIndex = 0;
        }

        void habilitarCajasTexto(Boolean valor)
        {
            
            textBox1.Enabled = valor;
            cboxPaciente.Enabled = valor;
            cboxDoctor.Enabled = valor;
            textBox4.Enabled = valor;
            dataTableHistorial.Enabled = valor;
            textBox3.Enabled = valor;
            dateTimePicker1.Enabled = valor;
        }

        void habilitarBotones(Boolean valor)
        {
          
            dataTableHistorial.Enabled = valor;
            btnUpdate.Enabled = valor;
            btnDelete.Enabled = valor;

          
            btnNuevo.Enabled = !valor;
        }



       

        private void Form1_Load(object sender, EventArgs e)
        {


            habilitarCajasTexto(false);

           
            btnNuevo.Enabled = false;

        }
        private void btnCodigo_Click(object sender, EventArgs e)
        {

            flagAccion = "Nuevo";

            formInitDefault();
          
            //formLimpiar();

          
            habilitarCajasTexto(true);

                  
            habilitarBotones(false);

            
            textBox1.Focus();
          


            obtenerSecuenciaHistorial();
        }

        private DataTable cargarTable(string name_usp)
        {
            SqlDataAdapter da = new SqlDataAdapter(name_usp, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void Form6_Load(object sender, EventArgs e)

        {
            dataTableHistorial.DataSource = cargarTable("historialClinicoList");
            cboxDoctor.DataSource = listarDoctores();
            cboxDoctor.DisplayMember = "nombre";
            cboxDoctor.ValueMember = "id";


            cboxPaciente.DataSource = listarPacientes();
            cboxPaciente.DisplayMember = "nombre";
            cboxPaciente.ValueMember = "id";


        }

             DataTable listarDoctores()
        {
            SqlDataAdapter da = new SqlDataAdapter("Lista_doctor_cbo", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

            DataTable listarPacientes()
        {
            SqlDataAdapter da = new SqlDataAdapter("Lista_paciente_cbo", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        void navegarHistorial()
        {
            if (dataTableHistorial.CurrentRow != null)
            {
                textBox1.Text = dataTableHistorial.CurrentRow.Cells[0].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataTableHistorial.CurrentRow.Cells[3].Value.ToString());
                textBox3.Text = dataTableHistorial.CurrentRow.Cells[4].Value.ToString();
                textBox4.Text = dataTableHistorial.CurrentRow.Cells[5].Value.ToString();
                //cbo1.SelectedIndex = cbo1.FindStringExact(dataTableHistorial.CurrentRow.Cells[6].Value.ToString());
                //cboxPaciente.SelectedIndex = cbo2.FindStringExact(dataTableHistorial.CurrentRow.Cells[7].Value.ToString());
                cboxDoctor.SelectedValue = int.Parse(dataTableHistorial.CurrentRow.Cells[1].Value.ToString());
                cboxPaciente.SelectedValue = int.Parse(dataTableHistorial.CurrentRow.Cells[2].Value.ToString());
            }


        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            flagAccion = "Editar";

            
            habilitarCajasTexto(true);

            
            btnNuevo.Enabled = true;
              btnDelete.Enabled = false;
              textBox1.Focus();
        }

        void obtenerSecuenciaHistorial()
        {
            int secuencia = 0;
            
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("generar_id_historialClinico", cn);
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

            textBox1.Text = secuencia.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            formLimpiar();
            dataTableHistorial.DataSource = cargarTable("historialClinicoList");

            habilitarCajasTexto(false);

            habilitarBotones(true);

            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            if (flagAccion.Equals("Nuevo"))
            {
              
                registrarHistorial();

            }
            else
            {
             
               
                actualizarHistorial();

            }

            
            formLimpiar();

            
            habilitarCajasTexto(false);

            
            habilitarBotones(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("¿Esta seguro de eliminar el registro(s) seleccionado(s)?",
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

                    

                    SqlCommand cmd = new SqlCommand("delete_historialClinico", cn, trx);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
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

           

                dataTableHistorial.DataSource = ListarHistorial();



            

                if (resultado >= 1)

                    MessageBox.Show(resultado.ToString() + " registro(s) eliminado(s)",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else

                    MessageBox.Show("Eliminación no realizada",

                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }

            
        }

        void registrarHistorial()
        {
            int resultado = 0;
           
            cn.Open();
     
            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
             
                SqlCommand cmd = new SqlCommand("add_historialClinico", cn, trx);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_cliente", cboxPaciente.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@id_doctor", cboxDoctor.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@fecha_hora", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@diagnostico", textBox3.Text);
                cmd.Parameters.AddWithValue("@tratamiento", textBox4.Text);



            
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
           
            dataTableHistorial.DataSource = ListarHistorial();

            
            if (resultado >= 1)
                MessageBox.Show("Historial Agregado",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Registro no realizado",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void actualizarHistorial()
        {

            int resultado = 0;

       

            cn.Open();

          

            SqlTransaction trx = cn.BeginTransaction(IsolationLevel.Serializable);



            try

            {


                SqlCommand cmd = new SqlCommand("update_historialClinico", cn, trx);

                cmd.CommandType = CommandType.StoredProcedure;



             


                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_cliente", cboxPaciente.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@id_doctor", cboxDoctor.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@fecha_hora", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@diagnostico", textBox3.Text);
                cmd.Parameters.AddWithValue("@tratamiento", textBox4.Text);


              

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

       

            dataTableHistorial.DataSource = ListarHistorial();



            

            if (resultado >= 1)

                MessageBox.Show(resultado.ToString() + " Historial actualizado",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else

                MessageBox.Show("Actualización no realizada",

                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataTableHistorial_SelectionChanged(object sender, EventArgs e)
        {
            navegarHistorial();
        }

        private void dataTableHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            navegarHistorial();
        }
    }
}