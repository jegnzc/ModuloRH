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
    public partial class frmPrestacionesLaborales : Form
    {
        clsControladorAplicacion conAplicacion = new clsControladorAplicacion();
        public frmPrestacionesLaborales()
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
                conAplicacion.modificarAplicacion(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), " ");
                MessageBox.Show("Modificacion realizada");
                funLimpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"");
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

        /*
        private void btnEliminar()
        {
            conAplicacion.eliminarAplicacion(textBox1.Text);
            MessageBox.Show("Eliminacion realizada");
            funLimpiar();
        }
        */
        /*
        private void btnInsertar()
        {
            
            /*
            try
            {
                    conAplicacion.buscarAplicacion(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), " ");
                    
                    conAplicacion.modificarAplicacion(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), " ");
                    MessageBox.Show("Modificacion realizada");
                    funLimpiar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            */
    }
        


    
}
