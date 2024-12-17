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
        public partial class Principal : Form
        {
            CONEXION Conexion = new CONEXION();
            VerificacionRepository repo=new VerificacionRepository();
            ItemConteo oConteo=new ItemConteo();
            Verificacion oVerificacion=new Verificacion();
        
        
        
        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
        
            mostrarProductos();
            rbBodegaExterna.Visible = false;
            rbBodegaInterna.Visible = false;
            rbElegirProductos.Visible = false;
            rbEmpleado.Checked = true;
            cbNombre.SelectedIndex = -1;
        
        
        }
        private bool ValidarBodegaSeleccionada()
        {
            if (!rbBodegaExterna.Checked && !rbBodegaInterna.Checked)
            {
                MessageBox.Show("Elija una bodega para continuar");
                return false;
            }
            return true;
        }


        private void btnAsignar_Click(object sender, EventArgs e)
            {
            if (cbNombre.SelectedValue != null)
            {
                oConteo.IdTrabajador = Convert.ToString(cbNombre.SelectedValue);
                oConteo.Trabajador = Convert.ToString(cbNombre.Text);
                oConteo.Bodegainterna = Convert.ToBoolean(rbBodegaInterna.Checked);

                if (rbEmpleado.Checked)
                {
                    if (rbElegirProductos.Visible == false)
                    {
                        if (oConteo.Rol == 3)
                        {
                            if (!ValidarBodegaSeleccionada()) return;
                            bool Seasignop = repo.asignarProductosEmpleados(oConteo);
                            if (Seasignop) mostrarProductos();
                        }
                        else
                        {
                            bool Seasigno = repo.asignarProductosEmpleados(oConteo);
                            if (Seasigno) mostrarProductos();
                        }
                    }

                    if (rbElegirProductos.Visible == true && rbElegirProductos.Checked)
                    {
                        if (oConteo.Rol == 3 && !ValidarBodegaSeleccionada()) return;
                        FrmEligirProductos elegir = new FrmEligirProductos(oConteo, this);
                        elegir.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Por favor seleccione el botón para elegir los productos");
                    }
                }
                else if (rbMercaderista.Checked)
                {
                    bool Seasigno = repo.asignarProductosMercaderistas(oConteo);
                    if (Seasigno) mostrarProductos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un trabajador antes de asignar productos.");
            }

            //if (cbNombre.SelectedValue != null)
            //{

            //    oConteo.IdTrabajador = Convert.ToString(cbNombre.SelectedValue);
            //    oConteo.Trabajador = Convert.ToString(cbNombre.Text);
            //    oConteo.Bodegainterna = Convert.ToBoolean(rbBodegaInterna.Checked);

            //    if (rbEmpleado.Checked)
            //    {
            //        if (rbElegirProductos.Visible == false)
            //        {
            //            if(oConteo.Rol==3)
            //            {

            //                if (!rbBodegaExterna.Checked && !rbBodegaInterna.Checked)
            //                {
            //                    MessageBox.Show("Elija una bodega para continuar");
            //                }
            //                else
            //                {
            //                    bool Seasignop = repo.asignarProductosEmpleados(oConteo);
            //                    if (Seasignop)
            //                    {
            //                        mostrarProductos();
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                bool Seasigno = repo.asignarProductosEmpleados(oConteo);
            //                if (Seasigno)
            //                {
            //                    mostrarProductos();
            //                }
            //            }


            //        }
            //        if (rbElegirProductos.Visible == true)
            //        {

            //            if (rbElegirProductos.Checked)
            //            {
            //                if(oConteo.Rol==3)
            //                {
            //                    if (!rbBodegaExterna.Checked && !rbBodegaInterna.Checked)
            //                    {
            //                        MessageBox.Show("Elija una bodega para continuar");
            //                    }
            //                    else
            //                    {
            //                        FrmEligirProductos elegir = new FrmEligirProductos(oConteo, this);
            //                        elegir.ShowDialog();
            //                    }
            //                }
            //                else if(oConteo.Rol!=3)
            //                {
            //                    FrmEligirProductos elegir = new FrmEligirProductos(oConteo, this);
            //                    elegir.ShowDialog();
            //                }

            //            }

            //        }

            //    }
            //    if (rbMercaderista.Checked)
            //    {
            //        bool Seasigno = repo.asignarProductosMercaderistas(oConteo);
            //        if (Seasigno)
            //        {
            //            mostrarProductos();
            //        }

            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Seleccione un trabajador antes de asignar productos.");
            //}


        }


            public void mostrarProductos()
            {
                List<ItemConteo> conteo = repo.ListarItemConteo();

                // Limpiar cualquier control previo
                flpProductos.Controls.Clear();

                foreach (var item in conteo)
                {
                    // Crear un panel para cada ItemConteo
                    FlowLayoutPanel panelItem = new FlowLayoutPanel
                    {
                        Width = 551, // Establecer el tamaño del panel
                        Height = 75, // Ajusta el tamaño según lo necesites
                        BorderStyle = BorderStyle.FixedSingle, // Agregar borde para distinguir cada sección
                        Padding = new Padding(10),
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        MaximumSize = new Size(551, 0)
                    };

                    // Crear un Label para mostrar el nombre del Contador
                    Label labelContador = new Label
                    {
                        Text = item.Trabajador, // El nombre del contador
                        Width = 550, // Ajustar el tamaño
                        TextAlign = ContentAlignment.MiddleCenter, // Centrar el texto
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.White
                    };

                    // Añadir el Label al Panel
                    panelItem.Controls.Add(labelContador);

                    // Crear los botones para los productos
                    for (int i = 0; i < item.Productos.Count; i++)
                    {
                        Producto producto = item.Productos[i];

                        // Crear un botón para cada producto
                        Button buttonProducto = new Button
                        {
                            Text = $"{producto.IdReferencia} - {producto.Referencia}", // Mostrar IdReferencia y Referencia
                            Width = 255, // Ajustar el tamaño
                            Height = 35,
                            Cursor = Cursors.Hand,
                            //Top = 40 + (i * 40), // Para colocar los botones debajo del Label
                            Tag = producto.IdReferencia, // Guardamos el IdReferencia como tag para usarlo en el evento Click
                            ForeColor = Color.White,

                        };

                        // Asignar el evento Click para cada botón
                        buttonProducto.Click += (sender, e) =>
                        {
                            Button clickedButton = (Button)sender;
                            int idReferencia = (int)clickedButton.Tag; // Obtener el IdReferencia del botón
                            ActualizarItemInventario(idReferencia,buttonProducto); // Llamar al método con el IdReferencia
                        };

                        if(producto.Contado == true)
                        {
                            buttonProducto.Enabled = false;

                        }   

                        // Añadir el botón al Panel
                        panelItem.Controls.Add(buttonProducto);
                    }

                    // Añadir el Panel a un contenedor principal (por ejemplo, un Panel o FlowLayoutPanel en el formulario)
                    flpProductos.Controls.Add(panelItem);
                }
            }

            private void ActualizarItemInventario(int idReferencia,Button buttonProducto)
            {
               FrmCantidad cantidad=new FrmCantidad(idReferencia,buttonProducto);
                cantidad.Show();
            }

   

            private void rbEmpleado_CheckedChanged(object sender, EventArgs e)
            {
            
                string consulta = "select IdTrabajador,nombre from TRABAJADORES where estado=1 ORDER BY nombre ASC";
                DataTable lista = new SentenciasSqlServer().TraerDatos(consulta, Conexion.ConexionLaBodegaDeNacho());
                cbNombre.DataSource = lista;
                cbNombre.DisplayMember = "nombre";
                cbNombre.ValueMember = "IdTrabajador";
                rbBodegaInterna.Visible = false;
                rbBodegaExterna.Visible = false;
            }

            private void rbMercaderista_CheckedChanged(object sender, EventArgs e)
            {
           
                if (rbMercaderista.Checked)
                {
               

                    string consulta = @"SELECT 
                                   IIF(rp.Nit IS NULL, '', rp.Nit) AS Nit,
                                   IIF(p.RazonSocial IS NULL, '', p.RazonSocial) AS RazonSocial
                                   FROM 
                                       Referencias r
                                   FULL JOIN 
                                       Referencias_Proveedores rp 
                                       ON rp.IdReferencia = r.IdReferencia
                                   LEFT JOIN 
                                       Proveedores p 
                                       ON p.Nit = rp.Nit
                                   WHERE 
                                       r.Estado = 1 and RazonSocial!=''
                                   GROUP BY 
                                   RazonSocial,rp.Nit
                                   ORDER BY 
                                       p.RazonSocial ASC;";
                    DataTable lista = new SentenciasSqlServer().TraerDatos(consulta, Conexion.ConexionRibisoft());
                    cbNombre.DataSource = lista;
                    cbNombre.DisplayMember = "RazonSocial";
                    cbNombre.ValueMember = "Nit";
                    rbBodegaExterna.Visible = false;
                    rbBodegaInterna.Visible = false;

                }
            }

            private void txtLeerCodigo_TextChanged(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(txtLeerCodigo.Text.Trim()))
                {
                    oConteo.codigo = txtLeerCodigo.Text.Trim();

                    bool SeValido = repo.verificarcodigo(oConteo);

                    if (SeValido)
                    {
                        rbElegirProductos.Visible = true;
                        txtLeerCodigo.Clear(); 
                    }


                }
            }
    

        private void cbNombre_SelectedValueChanged(object sender, EventArgs e)
            {
       

            if (cbNombre.SelectedValue != null)
            {

                rbElegirProductos.Visible = false;

                oConteo.IdTrabajador = Convert.ToString(cbNombre.SelectedValue);
                int rol = repo.ObtenerRolTrabajador(oConteo);
                if (rol == 3)
                {

                    rbBodegaInterna.Visible = true;
                    rbBodegaExterna.Visible = true;

                }
                oConteo.Rol = rol;
                if (rol != 3)
                {
                    rbBodegaExterna.Visible = false;
                    rbBodegaInterna.Visible = false;
                }

            }


        }

  
    }
}
