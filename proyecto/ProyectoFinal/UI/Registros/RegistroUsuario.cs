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
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            UsuarioIDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            NivelUsuariotextBox.Text = string.Empty;
            UsuariotextBox.Text = string.Empty;
            ClavetextBox.Text = string.Empty;
            FechaIngresodateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();
        }
     private Usuarios LlenarClase()

        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioID = Convert.ToInt32(UsuarioIDnumericUpDown.Value);
            usuario.Nombres = NombrestextBox.Text;
            usuario.Email = EmailtextBox.Text;
            usuario.NivelUsuario = NivelUsuariotextBox.Text;
            usuario.Usuario = UsuariotextBox.Text;
            usuario.Clave = ClavetextBox.Text;
            usuario.FechaIngreso = FechaIngresodateTimePicker.Value;

           return usuario;

        }

        private bool ExisteEnLaBaseDeDatos()

        {
            Usuarios usuario = UsuarioBLL.Buscar((int)UsuarioIDnumericUpDown.Value);
            return (usuario != null);
        }

        private void LlenarCampo(Usuarios usuario)

        {
            UsuarioIDnumericUpDown.Value = usuario.UsuarioID;
             NombrestextBox.Text = usuario.Nombres;
             EmailtextBox.Text = usuario.Email;
            NivelUsuariotextBox.Text = usuario.NivelUsuario;
             UsuariotextBox.Text = usuario.Usuario;
             ClavetextBox.Text = usuario.Clave;
             FechaIngresodateTimePicker.Value = usuario.FechaIngreso;

        }

        private bool validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();
            if (NombrestextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombrestextBox, "El campo Nombre no puede estar vacio");
                NombrestextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NivelUsuariotextBox.Text))
            {
               MyErrorProvider.SetError(NivelUsuariotextBox, "El campo NivelUsuario no puede estar vacio");
                NivelUsuariotextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(UsuariotextBox.Text))
            {
                MyErrorProvider.SetError(UsuariotextBox, "El campo Usuario no puede estar vacio");
                UsuariotextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ClavetextBox.Text))
            {
                MyErrorProvider.SetError(ClavetextBox, " El campo Clave no puede estar vacio");
                ClavetextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Usuarios usuario;
            bool paso = false;
            if (!validar())
                return;
            usuario = LlenarClase();
            //Limpiar();
            if (UsuarioIDnumericUpDown.Value == 0)
            {
                paso = UsuarioBLL.Guardar(usuario);
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
                

            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UsuarioBLL.Modificar(usuario);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            int id;
            int.TryParse(UsuarioIDnumericUpDown.Text, out id);

            Limpiar();
            if (UsuarioBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(UsuarioIDnumericUpDown, "No se puede eliminar un usuario que no existe");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            {

                int id;
                Usuarios usuario = new Usuarios();
                int.TryParse(UsuarioIDnumericUpDown.Text, out id);

                Limpiar();
                usuario = UsuarioBLL.Buscar(id);
                if (usuario != null)
                {
                    MessageBox.Show("Usuario Encontrado");
                    LlenarCampo(usuario);
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }

            }
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
