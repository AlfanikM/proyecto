using PrimerParcialAlfanik.BLL;
using PrimerParcialAlfanik.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcialAlfanik.UI.Registro
{
    public partial class RegistroProducto : Form
    {
        public RegistroProducto()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaNumericUpDown.Value = 0;
            CostoNumericUpDown.Value = 0;           
            ValorInvTextBox.Text = string.Empty;
            errorProvider.Clear();
        }

        private Producto LlenaClase()
        {
            Producto producto = new Producto();
            producto.ProductoId = Convert.ToInt32(IdNumericUpDown.Value);
            producto.Descripcion = DescripcionTextBox.Text;
            producto.Costo = Convert.ToDecimal(CostoNumericUpDown.Value);
            producto.Existencia = Convert.ToInt32(ExistenciaNumericUpDown.Value);
            producto.ValorInventario = Convert.ToDecimal(ValorInvTextBox.Text);
            return producto;
        }

        private void LlenaCampo(Producto producto)
             
        {
            IdNumericUpDown.Value = producto.ProductoId;
            DescripcionTextBox.Text = producto.Descripcion;
            ExistenciaNumericUpDown.Value = producto.Existencia;
            CostoNumericUpDown.Value = producto.Costo;
            ValorInvTextBox.Text = producto.ValorInventario.ToString();
        }

        private bool ValidarGuardar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (DescripcionTextBox.Text == string.Empty)
            {
                errorProvider.SetError(DescripcionTextBox, "El Campo esta vacio.");
                DescripcionTextBox.Focus();
                paso = false;
            }           

            if (CostoNumericUpDown.Value == 0)
            {
                errorProvider.SetError(CostoNumericUpDown, "El Campo esta vacio.");
                CostoNumericUpDown.Focus();
                paso = false;
            }
            if (ExistenciaNumericUpDown.Value == 0)
            {
                errorProvider.SetError(ExistenciaNumericUpDown, "El Campo esta vacio.");
                ExistenciaNumericUpDown.Focus();
                paso = false;
            }           

            return paso;
        }

        private bool ValidarEliminar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (IdNumericUpDown.Value == 0)
            {
                errorProvider.SetError(IdNumericUpDown, "Debe selecionar un Id.");
                IdNumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }

        private bool Existe()
        {
            Producto producto = ProductoBLL.Buscar((int)IdNumericUpDown.Value);

            return (producto != null);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistroProducto_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
          
              bool paso = false;
            if (!ValidarGuardar())
                return;

            if (IdNumericUpDown.Value == 0)
                paso = BLL.ProductoBLL.Guardar(LlenaClase());
            else
                if(!Existe())
            {
                MessageBox.Show("No se encontro el producto", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            paso = BLL.ProductoBLL.Modificar(LlenaClase());


            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!ValidarEliminar())
                return;

            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (ProductoBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider.SetError(IdNumericUpDown, "Producto no existe");
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Producto producto = new Producto();
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            producto = ProductoBLL.Buscar(id);

            if (producto != null)
            {
                LlenaCampo(producto);
                MessageBox.Show("Producto Encontrado!!!");
                
            }
            else
                MessageBox.Show("Producto no encontrado!!!");
        }

        private void ValorInvTextBox_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void CostoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CostoNumericUpDown.Value > 0 && ExistenciaNumericUpDown.Value > 0)
                ValorInvTextBox.Text = Convert.ToString(CostoNumericUpDown.Value * ExistenciaNumericUpDown.Value);

        
            if (CostoNumericUpDown.Value > 0 && ExistenciaNumericUpDown.Value == 0)
                ValorInvTextBox.Text = "0";

            if (CostoNumericUpDown.Value == 0 && ExistenciaNumericUpDown.Value > 0)
                ValorInvTextBox.Text = "0";

            if (CostoNumericUpDown.Value == 0 && ExistenciaNumericUpDown.Value == 0)
                ValorInvTextBox.Text = "0";
        }

        private void ExistenciaNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CostoNumericUpDown.Value > 0 && ExistenciaNumericUpDown.Value > 0)
                ValorInvTextBox.Text = Convert.ToString(CostoNumericUpDown.Value * ExistenciaNumericUpDown.Value);

                      if (CostoNumericUpDown.Value > 0 && ExistenciaNumericUpDown.Value == 0)
                ValorInvTextBox.Text = "0";

            if (CostoNumericUpDown.Value == 0 && ExistenciaNumericUpDown.Value > 0)
                ValorInvTextBox.Text = "0";

            if (CostoNumericUpDown.Value == 0 && ExistenciaNumericUpDown.Value == 0)
                ValorInvTextBox.Text = "0";
        }

        private void probando_TextChanged(object sender, EventArgs e)
        {

        }

        private void DescripcionTextBox_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void DescripcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
