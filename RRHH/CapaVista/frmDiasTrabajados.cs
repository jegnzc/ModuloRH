using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class frmDiasTrabajados : Form
    {
        clsControladorPerfil Controlador = new clsControladorPerfil();
        public frmDiasTrabajados()
        {
            InitializeComponent();
            LlenarDgv();
            CenterToScreen();
        }
        DataTable Dt = new DataTable();
        public void LlenarDgv()
        {
            dgvAplicaciones.Rows.Clear();
            Dt.Columns.Add("Codigo", typeof(string));
            Dt.Columns.Add("Nombre", typeof(string));
            OdbcDataReader mostrar = Controlador.funcConsulta("aplicacion", "estado");
            try
            {
                while (mostrar.Read())
                {
                    DataRow row;
                    row = Dt.NewRow();
                    row["Codigo"] = mostrar.GetString(0);
                    row["Nombre"] = mostrar.GetString(1);
                    Dt.Rows.Add(row);
                }
                dgvAplicaciones.DataSource = Dt;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvAplicaciones.Rows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar la Aplicación deseada");
                // return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dgvAplicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
