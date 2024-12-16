using ConteoDeInventario.Logica;
using ConteoDeInventario.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConteoDeInventario
{
    public partial class FrmCantidad : Form
    {
        int idReferencia=0;
        Button buttonProducto = null;
        public FrmCantidad(int idReferencia, Button buttonProducto)
        {
            InitializeComponent();
            this.idReferencia = idReferencia;
            this.buttonProducto = buttonProducto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Verificacion oVerificacion=new Verificacion();
            oVerificacion.InventarioConteo=Convert.ToInt32(txtCantidad.Text);
            lbIdReferencia.Text=idReferencia.ToString();
            

            bool seActualizo=new VerificacionRepository().InsertarCantidad(oVerificacion,idReferencia);
            if(seActualizo)
            {
                MessageBox.Show("Se ha insertado la cantidad correctamente.");
                buttonProducto.Enabled = false;
                this.Close();
            }

          

        }
    }
}
