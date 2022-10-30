using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeHotel
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        

        private void hospedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHospede hospede = new frmHospede();
            hospede.ShowDialog();
        }

        private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncionario funcionario = new frmFuncionario();
            funcionario.ShowDialog();
        }

        private void reservasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReserva reserva = new frmReserva();
            reserva.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
        }
    }
}
