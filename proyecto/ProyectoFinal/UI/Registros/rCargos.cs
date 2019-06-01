using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal.Entidades;
using ProyectoFinal.BLL;


namespace ProyectoFinal.UI.Registros
{
    public partial class rCargos : Form
    {
        public rCargos()
        {
            InitializeComponent();
        }

        private void IDdomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

       

            private void Buscarbutton_Click(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            IDnumericUpDown1.Value = 0;
            DescripciontextBox.Text = string.Empty;
            MyErrorProvider.Clear();
        }

        private void NuevoButton_Click(object sender , EventArgs e)
        
        {
            Limpiar();
        }
        private bool validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (DescripciontextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripciontextBox, "El campo Descripcion no puede estar vacio");
                DescripciontextBox.Focus();
                paso = false;
            }
            
            return paso;
        }

        private Cargos LlenarClase()

        {
            Cargos cargo = new Cargos();
            cargo.CargoId = Convert.ToInt32(IDnumericUpDown1.Value);
            cargo.Descripcion = DescripciontextBox.Text;


            return cargo;

        }
        private bool ExisteEnLaBaseDeDatos()

        {
            Cargos cargos = CargoBLL.Buscar((int)IDnumericUpDown1.Value);
            return (cargos != null);
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
            {
                Cargos Cargo;
                bool paso = false;
                if (!validar())
                    return;
                Cargo = LlenarClase();
                //Limpiar();
                if (IDnumericUpDown1.Value == 0)
                {
                    paso = CargoBLL.Guardar(Cargo);
                    MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (!ExisteEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No se puede modificar un usuario que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    paso = CargoBLL.Modificar(Cargo);
                }
            
        }
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IDnumericUpDown1.Text, out id);

            Limpiar();
            if (CargoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDnumericUpDown1, "No se puede eliminar un usuario que no existe");
        }


    }
}
