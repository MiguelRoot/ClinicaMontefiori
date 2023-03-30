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
    
    public partial class Doctor : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public Doctor()
        {
            InitializeComponent();
        }


        private DataTable cargarTable(string name_usp)
        {
            // comentario test
            SqlDataAdapter da = new SqlDataAdapter(name_usp, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataTableDoctor.DataSource = cargarTable("doctorList");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
