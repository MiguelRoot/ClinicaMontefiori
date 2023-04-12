using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaMontefiori
{
    public partial class Portada : Form
    {
        public Portada()
        {
            InitializeComponent();
        }

        private void manToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pacientes formulario01 = new Pacientes();
            formulario01.MdiParent = this;
            formulario01.Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoctor formularioDoctor = new FormDoctor();
            formularioDoctor.MdiParent = this;
            formularioDoctor.Show();
        }

        private void recepcionistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recepcionista formRecepcionista = new Recepcionista();
            formRecepcionista.MdiParent = this;
            formRecepcionista.Show();
        }

        private void historialClínicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialClinico formHistorialClinico = new HistorialClinico();
            formHistorialClinico.MdiParent = this;
            formHistorialClinico.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CitasMedicas formCitasMedicas = new CitasMedicas();
            formCitasMedicas.MdiParent = this;
            formCitasMedicas.Show();
        }

        private void triajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Triaje formTriaje = new Triaje();
            formTriaje.MdiParent = this;
            formTriaje.Show();
        }
    }
}
