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
    public partial class Form6 : Form
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public Form6()
        {
            InitializeComponent();
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {

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
        }
    }
}
