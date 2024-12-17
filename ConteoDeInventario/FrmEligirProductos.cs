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
    public partial class FrmEligirProductos : Form
    {
        CONEXION Conexion = new CONEXION();
        VerificacionRepository repo=new VerificacionRepository();
        ItemConteo oConteo;
        Principal ppal = null;
        public FrmEligirProductos(ItemConteo oConteo, Principal ppal)
        {
            InitializeComponent();
            this.oConteo = oConteo;
            this.ppal = ppal;
        }

        private async void FrmEligirProductos_Load(object sender, EventArgs e)
        {
           await mostrarlista();
        }

        public async Task mostrarlista()
        {
            DataTable dt = await repo.cargarProductos(oConteo);

            dgvListaProductos.DataSource = dt;
            dgvListaProductos.Columns["Saldo"].Visible = false;
        }

        //public void mostrarlista()
        //{
        //    DataTable dt = repo.cargarProductos(oConteo);

        //    dgvListaProductos.DataSource = dt;
        //    dgvListaProductos.Columns["Saldo"].Visible = false;
        //}

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            // Creamos una lista de productos seleccionados
            List<Producto> productosSeleccionados = new List<Producto>();

            // Recorremos las filas seleccionadas del DataGridView
            foreach (DataGridViewRow row in dgvListaProductos.SelectedRows)
            {
                int idReferencia = Convert.ToInt32(row.Cells["IdReferencia"].Value);
                string referencia = row.Cells["Referencia"].Value.ToString();
                string idBodega= row.Cells["IdBodega"].Value.ToString();
                // Agregamos el producto seleccionado a la lista
                productosSeleccionados.Add(new Producto
                {
                    IdReferencia = idReferencia,
                    Referencia = referencia,
                    idBodega = idBodega
                    
                });
            }

            // Ahora llamamos al método para insertar los productos en VerificacionInventario
            if (productosSeleccionados.Count > 0)
            {
                repo.InsertarPorductos(productosSeleccionados,oConteo);
                ppal.mostrarProductos();
                this.Close();   
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún producto.");
            }
        }

        private async void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            // Obtén los datos originales desde la base de datos
            //DataTable dt = repo.cargarProductos(oConteo);
            DataTable dt = await repo.cargarProductos(oConteo);

            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    var filasFiltradas = dt.AsEnumerable()
                        .Where(row =>
                            (row.Field<string>("Referencia")?.ToLower().Contains(filtro) ?? false) || // Filtro por Referencia
                            row.Field<int>("IdReferencia").ToString().Contains(filtro))              // Filtro por IdReferencia
                        .ToList();

                    // Convierte las filas filtradas de nuevo a un DataTable
                    if (filasFiltradas.Any())
                    {
                        dgvListaProductos.DataSource = filasFiltradas.CopyToDataTable();
                    }
                    else
                    {
                        dgvListaProductos.DataSource = dt.Clone(); // Si no hay resultados, muestra una tabla vacía
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al filtrar: {ex.Message}");
                }
            }
        }
    }
}
