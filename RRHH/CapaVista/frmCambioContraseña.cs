using System;

using System.Windows.Forms;
using CapaControlador;
using CapaModelo;

namespace CapaVista
{
    public partial class frmCambioContraseña : Form
    {
        string Usuario = "";
        public frmCambioContraseña()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var key = "b14ca5898a4e4133bbce2ea2315a1916";
            clsEncriptar encriptar = new clsEncriptar();
            clsControladorPerfil controladorPerfil = new clsControladorPerfil();
            if (txtNuevaContraseña.Text == "" || txtConfirmarContraseña.Text == "")
            {
                MessageBox.Show("Los Campos no Deben de Estar Vacios");
            }
            else
            {
                if (txtNuevaContraseña.Text == txtConfirmarContraseña.Text)
                {
                    string password = encriptar.funcEncryptString(key, txtConfirmarContraseña.Text);
                    controladorPerfil.funcModificar_Contraseña(Usuario, password);
                    MessageBox.Show("Contraseña Actualizada Exitozamente");
                    txtNuevaContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Las Contraseñas No Coinciden");
                    txtNuevaContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                }
            }
        }
    }
}
