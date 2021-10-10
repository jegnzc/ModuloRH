using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador;



namespace CapaVista
{
    public partial class frmAgregarEmpleado : Form
    {
        clsControladorPerfil conAplicacion = new clsControladorPerfil();
        public frmAgregarEmpleado()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            //funInsertar();
            //funBuscar();
            //funLimpiar();
            //funEliminar();
            //funModificar();


            
            try
            {
                if (btnHabilitado.Checked == true)
                {
                    
                    conAplicacion.insertarPerfil(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
                    MessageBox.Show("Inserción realizada");
                    funLimpiar();
                }
                else if (btnInhabilitado.Checked == true)
                {
                    
                    conAplicacion.insertarPerfil(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
                    MessageBox.Show("Inserción realizada");
                    funLimpiar();
                }
                else
                {
                    MessageBox.Show("No ha seleccionado estado!");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

            
        }

        public void funLimpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            btnHabilitado.Checked = false;
            btnInhabilitado.Checked = false;
            textBox3.Text = "";
            
        }

        private void btnHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "1";
        }

        private void btnInhabilitado_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Text = "0";
        }

        private void labelIdaplicacion_Click(object sender, EventArgs e)
        {

        }

        private void frmMantenimientoPerfil_Load(object sender, EventArgs e)
        {

        }
    }
}
