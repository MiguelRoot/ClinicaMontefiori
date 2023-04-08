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
        public CitasMedicas()
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

        private void Form4_Load(object sender, EventArgs e)
        {
            dataTableCitaMedica.DataSource = cargarTable("clienteList");
        }

       
    }
}
