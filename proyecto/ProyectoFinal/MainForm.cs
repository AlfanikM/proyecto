using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal.UI.Registros;

namespace ProyectoFinal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void RegistroUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroUsuario reg = new RegistroUsuario();
            reg.Show();
        }

        private void RegistroCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCargos reg = new rCargos();
            reg.Show();
        }
    }
}
