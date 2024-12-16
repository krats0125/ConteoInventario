using ListaDeConteo.Logica;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ListaDeConteo
{
    public partial class FrmReporte : Form
    {
        CONEXION conexion=new CONEXION();
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            ListarConteo();
        }
        public void ListarConteo()
        {
            string consulta = @"select Idreferencia as 'ID PRODUCTO',referencia AS PRODUCTO,InventarioMomento AS 'INVENTARIO ACTUAL',InventarioConteo 'INVENTARIO CONTADO',Diferencia AS DIFERENCIA,Contador AS TRABAJADOR ,verifico 'VERIFICACIÓN',InventarioBodega 'INVENTARIO EN BODEGA',IdBodega 'BODEGA',FechaConteo 'FECHA DE CONTEO',Observacion AS OBSERVACIONES
                                from VerificacionInventario
                                where inventarioconteo>=0 AND CONVERT(DATE,FechaConteo)=CONVERT(DATE,GETDATE())";
            DataTable lista = new SentenciasSqlServer().TraerDatos(consulta, conexion.ConexionRibisoft());
            dgvListaConteo.DataSource = lista;
            foreach (DataGridViewColumn col in dgvListaConteo.Columns)
            {
                if (col.Name == "VERIFICACIÓN")
                {
                    col.CellTemplate = new DataGridViewCheckBoxCell();
                }

            }
            dgvListaConteo.Columns["OBSERVACIONES"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvListaConteo.Refresh();

        }

        private void dgvListaConteo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow fila=dgvListaConteo.Rows[e.RowIndex];
            if (e.RowIndex >= 0 && (dgvListaConteo.Columns[e.ColumnIndex].Name == "VERIFICACIÓN"))
            {
                dgvListaConteo.CommitEdit(DataGridViewDataErrorContexts.Commit); // Confirma el cambio de CheckBox
            }

        }

        public void ActualizarInventario(int idProducto, string columna, bool valor)
        {
            string consulta = "";
            if (columna == "VERIFICACIÓN")
            {
                consulta = @"UPDATE VerificacionInventario 
                     SET verifico = @valor
                     WHERE Idreferencia = @idProducto";
            }
            using (SqlConnection conn = new SqlConnection(conexion.ConexionRibisoft()))
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            ListarConteo();
        }

        private void dgvListaConteo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columna = dgvListaConteo.Columns[e.ColumnIndex].Name;
                int idProducto = Convert.ToInt32(dgvListaConteo.Rows[e.RowIndex].Cells["ID PRODUCTO"].Value);

                if (columna == "VERIFICACIÓN")
                {
                    bool valor = Convert.ToBoolean(dgvListaConteo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    ActualizarInventario(idProducto, columna, valor);
                }
                else if (columna == "OBSERVACIONES")
                {
                    string observacion = dgvListaConteo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    ActualizarObservaciones(idProducto, observacion);
                }
            }
        }

        public void ActualizarObservaciones(int idProducto, string observacion)
        {
            string consulta = @"UPDATE VerificacionInventario 
                        SET Observacion = @observacion 
                        WHERE Idreferencia = @idProducto";

            using (SqlConnection conn = new SqlConnection(conexion.ConexionRibisoft()))
            {
                SqlCommand cmd = new SqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
