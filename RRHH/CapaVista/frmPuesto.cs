using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmPuesto : Form
    {
        clsControladorPerfil Controlador = new clsControladorPerfil();
        public frmPuesto()
        {
            InitializeComponent();
            CenterToScreen();
        }
        public void inicio()
        {
            txtPerfil.Enabled = false;
            txtAplicacion.Enabled = false;
            btnAplicación.Enabled = false;
            txtAplicacion.Text = "";
            txtCodApp.Text = "";
            chkIngreso.Checked = false;
            chkModificar.Checked = false;
            chkEliminar.Checked = false;
            chkConsultar.Checked = false;
            chkImprimir.Checked = false;
        }

        int Permisos1;
        int Permisos2;
        int Permisos3;
        int Permisos4;
        int Permisos5;
        int cc;
        public void checkbox()
        {
            if (chkIngreso.Checked == true)
            {
                Permisos1 = 1;
            }
            else
            {
                Permisos1 = 0;
            }
            if (chkModificar.Checked == true)
            {
                Permisos2 = 1;
            }
            else
            {
                Permisos2 = 0;
            }
            if (chkEliminar.Checked == true)
            {
                Permisos3 = 1;
            }
            else
            {
                Permisos3 = 0;
            }
            if (chkConsultar.Checked == true)
            {
                Permisos4 = 1;
            }
            else
            {
                Permisos4 = 0;
            }
            if (chkImprimir.Checked == true)
            {
                Permisos5 = 1;
            }
            else
            {
                Permisos5 = 0;
            }
        }
        int CodAplicacion;
        string CodPerfil;
        private void btnAplicación_Click(object sender, EventArgs e)
        {
            frmDiasTrabajados agregarAplicacion = new frmDiasTrabajados();
            if (agregarAplicacion.ShowDialog() == DialogResult.OK)
            {
                CodAplicacion = agregarAplicacion.dgvAplicaciones.Rows[agregarAplicacion.dgvAplicaciones.CurrentRow.Index].Cells[0].Selected.GetHashCode();
                txtAplicacion.Text = agregarAplicacion.dgvAplicaciones.Rows[agregarAplicacion.dgvAplicaciones.CurrentRow.Index].Cells[1].Value.ToString();

            }

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            frmDesarrolloDeCarrera consultarPerfil = new frmDesarrolloDeCarrera();
            if (consultarPerfil.ShowDialog() == DialogResult.OK)
            {
                CodPerfil = consultarPerfil.dgvPerfilDisponibles.Rows[consultarPerfil.dgvPerfilDisponibles.CurrentRow.Index].Cells[0].Value.ToString();
                txtCodApp.Text = CodPerfil;
                txtPerfil.Text = consultarPerfil.dgvPerfilDisponibles.Rows[consultarPerfil.dgvPerfilDisponibles.CurrentRow.Index].Cells[1].Value.ToString();
                if (txtPerfil.Text != "")
                {
                    btnAplicación.Enabled = true;
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (Controlador.insertarpermisosPerfil(CodAplicacion, Permisos1, Permisos2, Permisos3, Permisos4, Permisos5) == null)
                {
                    MessageBox.Show("NO se pudo Guardar los datos Contacte al encargado de sistemas");
                }
                else
                {
                    MessageBox.Show("Datos guardados");
                    inicio();

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnPerfil.Enabled = true;
            btnAplicación.Enabled = true;
        }
        public bool Validar()
        {
            checkbox();
            if (txtPerfil.Text == "")
            {
                MessageBox.Show("Debe de seleccionar un Perfil");
                return false;
            }
            if (txtAplicacion.Text == "")
            {
                MessageBox.Show("Debe de seleccionar una Áplicació");
                return false;
            }
            return true;
        }

        private void frmAsignarAplicacionAPerfiles_Load(object sender, EventArgs e)
        {

        }
    }
}
