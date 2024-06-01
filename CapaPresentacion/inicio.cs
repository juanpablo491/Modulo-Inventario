using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public inicio(Usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else
                usuarioActual = objusuario;
            usuarioActual = objusuario;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }
            lblusuario.Text = usuarioActual.NombreCompleto;
        }
        private void abrirformulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;
            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void menuusuarios_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void submenucategoria_Click(object sender, EventArgs e)
        {
            abrirformulario(menumantenedor, new frmCategoria());
        }
        private void submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            abrirformulario(menucompras, new frmDetalleventa());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            abrirformulario(menuventas, new frmVentas());
        }

        private void submenuproducto_Click(object sender, EventArgs e)
        {
            abrirformulario(menumantenedor, new frmProducto());
        }

        private void submenuverdetalleventa_Click_1(object sender, EventArgs e)
        {
            abrirformulario(menuventas, new frmDetalleventa());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            abrirformulario(menucompras, new frmCompras());
        }

        private void submenuverdetallecompra_Click(object sender, EventArgs e)
        {
            abrirformulario(menucompras, new frmDetallecompra());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmProveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmReportes());
        }
    }
}
