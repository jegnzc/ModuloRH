using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;
using CapaControlador;

namespace CapaVista
{
    public partial class frmDesarrolloDeCarrera : Form
    {
        clsControladorPerfil Controlador = new clsControladorPerfil();
        public frmDesarrolloDeCarrera()
        {
            InitializeComponent();
            LlenarDgv();
            CenterToScreen();
        }
        DataTable Dt = new DataTable();
        public void LlenarDgv()
        {
            dgvPerfilDisponibles.Rows.Clear();
            Dt.Columns.Add("Codigo", typeof(string));
            Dt.Columns.Add("Nombre_Perfil", typeof(string));
            OdbcDataReader mostrar = Controlador.funcConsulta("perfil", "estado");
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["Codigo"] = mostrar.GetString(0);
                    row["Nombre_Perfil"] = mostrar.GetString(1);
                    Dt.Rows.Add(row);
                }
                dgvPerfilDisponibles.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvPerfilDisponibles.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la Aplicación deseada");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}