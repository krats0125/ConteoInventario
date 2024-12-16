using ListaAdministracion.Logica;
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
using OfficeOpenXml;

namespace ListaAdministracion.Presentacion
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
            string consulta = @"select Idreferencia as 'ID PRODUCTO',referencia AS PRODUCTO,InventarioMomento AS 'INVENTARIO ACTUAL',InventarioConteo 'INVENTARIO CONTADO',Diferencia AS DIFERENCIA,Contador AS TRABAJADOR ,InventarioBodega 'INVENTARIO EN BODEGA',IdBodega 'BODEGA',Observacion AS OBSERVACIONES,verifico 'VERIFICACIÓN',ModificoInventarioReal 'MODIFICACION A INVENTARIO REAL',observacionesfinales 'OBSERVACIONES FINALES',FechaConteo 'FECHA DE CONTEO'
	                           from VerificacionInventario ";
            DataTable lista = new SentenciasSqlServer().TraerDatos(consulta, conexion.ConexionRibisoft());
            dgvListaConteo.DataSource = lista;
            foreach (DataGridViewColumn col in dgvListaConteo.Columns)
            {
                if (col.Name == "MODIFICACION A INVENTARIO REAL")
                {
                    col.CellTemplate = new DataGridViewCheckBoxCell(); 
                }

            }

            dgvListaConteo.Columns["OBSERVACIONES"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvListaConteo.Columns["OBSERVACIONES FINALES"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvListaConteo.Refresh();

        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }
        public void ExportarExcel()
        {
            using (SqlConnection cn = new SqlConnection(conexion.ConexionRibisoft()))
            {
                string consulta = @"select Idreferencia as 'ID PRODUCTO',referencia AS PRODUCTO,InventarioMomento AS 'INVENTARIO ACTUAL',InventarioConteo 'INVENTARIO CONTADO',Diferencia AS DIFERENCIA,Contador AS TRABAJADOR ,InventarioBodega 'INVENTARIO EN BODEGA',IdBodega 'BODEGA',Observacion AS OBSERVACIONES,verifico 'VERIFICACIÓN',ModificoInventarioReal 'MODIFICACION A INVENTARIO REAL',observacionesfinales 'OBSERVACIONES FINALES',FechaConteo 'FECHA DE CONTEO'
	                           from VerificacionInventario";
                using (SqlCommand cmd = new SqlCommand(consulta, cn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    using (SaveFileDialog savefiledialog = new SaveFileDialog())
                    {
                        savefiledialog.Filter = "Excel Files|*.xlsx";
                        savefiledialog.Title = "Guardar archivo Excel";
                        savefiledialog.FileName = "Reporte de conteo de inventario";

                        if (savefiledialog.ShowDialog() == DialogResult.OK)
                        {
                            using (ExcelPackage excelPackage = new ExcelPackage())
                            {
                                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Resultados");
                                // Cargar los datos en la hoja de Excel a partir de la segunda fila
                                worksheet.Cells["A1"].LoadFromDataTable(table, true);
                                worksheet.Cells.AutoFitColumns();
                                // Guardar el archivo en la ubicación seleccionada
                                FileInfo fileInfo = new FileInfo(savefiledialog.FileName);
                                excelPackage.SaveAs(fileInfo);
                                MessageBox.Show($"Archivo guardado exitosamente", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void dgvListaConteo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaConteo.Columns[e.ColumnIndex].Name == "MODIFICACION A INVENTARIO REAL")
            {
                dgvListaConteo.CommitEdit(DataGridViewDataErrorContexts.Commit); // Confirma el cambio de CheckBox
            }
        }

        public void ActualizarInventario(int idProducto, string columna, bool valor)
        {
            string consulta = "";
       
             if (columna == "MODIFICACION A INVENTARIO REAL")
            {
                consulta = @"UPDATE VerificacionInventario 
                     SET ModificoInventarioReal = @valor
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

                if (columna == "MODIFICACION A INVENTARIO REAL")
                {
                    bool valor = Convert.ToBoolean(dgvListaConteo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    ActualizarInventario(idProducto, columna, valor);
                }
                else if (columna == "OBSERVACIONES FINALES")
                {
                    string observacion = dgvListaConteo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    ActualizarObservaciones(idProducto, observacion);
                }
            }
        }

        public void ActualizarObservaciones(int idProducto, string observacion)
        {
            string consulta = @"UPDATE VerificacionInventario 
                        SET observacionesfinales = @observacion 
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

        private void dgvListaConteo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgvListaConteo.Columns["OBSERVACIONES "].Index)
            //{
            //    dgvListaConteo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }
    }
}
