using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Vista
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            FrmEstudiante frm = new FrmEstudiante();
            frm.ShowDialog();

     
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReporteTop5 frm = new FrmReporteTop5();
            frm.ShowDialog();

        }
    }
}
