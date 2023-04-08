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
    public partial class Recepcionista : Form
    {
        string flagAccion = "";
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public Recepcionista()
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

        private void Form3_Load(object sender, EventArgs e)
        {
            dataTableRecepcionista.DataSource = cargarTable("recepcionistaList");
        }


        void generaId()
        {
            int idnewRecepcionista = 0;
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("generar_id_recepcionista", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                idnewRecepcionista = (int)cmd.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            txtcodigo.Text = idnewRecepcionista.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            flagAccion = "Nuevo";
            //statusFormNuevo();
            generaId();
            //formLimpiar();

        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
