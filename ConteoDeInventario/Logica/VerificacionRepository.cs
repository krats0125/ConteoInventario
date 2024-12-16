using ConteoDeInventario.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoDeInventario.Logica
{
    public class VerificacionRepository
    {
        CONEXION Conexion = new CONEXION();
        ItemConteo oConteo= new ItemConteo();   
        Verificacion oVerificacion=new Verificacion();
        Producto oProducto=new Producto();

        public int ObtenerRolTrabajador(ItemConteo oConteo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ConexionLaBodegaDeNacho()))
                {
                    cn.Open();
                    string consulta = "select Rol from InventarioRol where idTrabajador=@idTrabajador";
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@idTrabajador", oConteo.IdTrabajador);
                        var resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            oConteo.Rol = Convert.ToInt32(resultado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el rol: {ex.Message}");
            }
            return oConteo.Rol;
        }


        public bool asignarProductosEmpleados(ItemConteo oConteo)
        {
            bool respuesta= false;

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_GestionarInventario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contador", oConteo.Trabajador);
                        cmd.Parameters.AddWithValue("@Rol", oConteo.Rol);
                        cmd.Parameters.AddWithValue("@BodegaInterna", oConteo.Bodegainterna);
                        cmd.ExecuteNonQuery();

                        respuesta = true;
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return respuesta;
            }

            return respuesta;

        }


        public void InsertarPorductos(List<Producto> productos, ItemConteo oConteo)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
            {
                cn.Open();

                foreach (var producto in productos)
                {
                    string consulta = @"INSERT INTO VerificacionInventario (Idreferencia, referencia, Contador, Ciclo, Idbodega)
                                VALUES(@Idreferencia, @referencia, @Contador, (SELECT MAX(IdCiclo) FROM CicloInventario), @Idbodega)";

                    SqlCommand command = new SqlCommand(consulta, cn);
                    command.Parameters.AddWithValue("@Contador", oConteo.Trabajador);
                    command.Parameters.AddWithValue("@IdReferencia", producto.IdReferencia);
                    command.Parameters.AddWithValue("@Referencia", producto.Referencia);
                    command.Parameters.AddWithValue("@Idbodega", producto.idBodega);

                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task<DataTable> cargarProductos(ItemConteo oConteo)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
                {
                    await cn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GestionarInventarioEscogido", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contador", oConteo.Trabajador);
                        cmd.Parameters.AddWithValue("@Rol", oConteo.Rol);
                        cmd.Parameters.AddWithValue("@BodegaInterna", oConteo.Bodegainterna);
                        

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }

                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }

            return dt;

        }

        //public DataTable cargarProductos(ItemConteo oConteo)
        //{
        //    DataTable dt = new DataTable(); 

            //    try
            //    {
            //        using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
            //        {
            //            cn.Open();

            //            using (SqlCommand cmd = new SqlCommand("sp_GestionarInventarioEscogido", cn))
            //            {
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Parameters.AddWithValue("@Contador", oConteo.Trabajador);
            //                cmd.Parameters.AddWithValue("@Rol", oConteo.Rol);
            //                cmd.Parameters.AddWithValue("@BodegaInterna", oConteo.Bodegainterna);
            //                cmd.ExecuteNonQuery();

            //                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            //                {
            //                    adapter.Fill(dt);
            //                }

            //            }


            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error: {ex.Message}");

            //    }

            //    return dt;

            //}

        public bool asignarProductosMercaderistas(ItemConteo oConteo)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("GestionarInventarioMercaderistas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RazonSocial", oConteo.Trabajador);
                        cmd.ExecuteNonQuery();

                        respuesta = true;
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return respuesta;
            }

            return respuesta;

        }
        public List<ItemConteo> ListarItemConteo()
        {
            List<ItemConteo> lista = new List<ItemConteo>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
                {
                    cn.Open();
                    // Consulta ajustada para obtener los campos Contador, Idreferencia y Referencia
                    string consulta = "SELECT Contador, IdReferencia, Referencia,Contado FROM VerificacionInventario WHERE CAST(FechaConteo AS DATE) = CAST(GETDATE() AS DATE) OR FechaConteo=''  order by Contado asc";
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Diccionario para agrupar productos por contador
                            Dictionary<string, ItemConteo> dictContadores = new Dictionary<string, ItemConteo>();

                            while (reader.Read())
                            {
                                string contador = reader["Contador"] != DBNull.Value ? reader["Contador"].ToString() : string.Empty;
                                int idReferencia = reader["IdReferencia"] != DBNull.Value ? Convert.ToInt32(reader["IdReferencia"]) : 0;  // Asignar un valor por defecto si es DBNull
                                string referencia = reader["Referencia"] != DBNull.Value ? reader["Referencia"].ToString() : string.Empty;
                                bool contado = reader["Contado"] != DBNull.Value ? Convert.ToBoolean(reader["Contado"]) : false;  // Asignar un valor por defecto si es DBNull


                                // Si el contador no está en el diccionario, lo agregamos
                                if (!dictContadores.ContainsKey(contador))
                                {
                                    dictContadores[contador] = new ItemConteo
                                    {
                                        Trabajador = contador,
                                        Productos = new List<Producto>()
                                    };
                                }

                                // Agregamos el producto a la lista del contador correspondiente
                                dictContadores[contador].Productos.Add(new Producto
                                {
                                    IdReferencia = idReferencia,
                                    Referencia = referencia,
                                    Contado= contado
                                });
                            }

                            // Convertir los valores del diccionario a una lista
                            lista = dictContadores.Values.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine(ex.Message); // Para ver el error
            }
            return lista;
        }

        public bool InsertarCantidad(Verificacion oVerificacion,int IdReferencia)
        {
            bool respuesta=false;
            try 
            {  
                using (SqlConnection cn=new SqlConnection(Conexion.ConexionRibisoft()))
                {
                    cn.Open();
                
                    using (SqlCommand cmd=new SqlCommand("InsertarCantidades", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InventarioConteo",oVerificacion.InventarioConteo);
                        cmd.Parameters.AddWithValue("@IdReferencia", IdReferencia);
                        cmd.ExecuteNonQuery();
                        respuesta=true;
                    }
                }

            } 
            catch(Exception e) { }
            return respuesta;
        }


        public bool verificarcodigo(ItemConteo oConteo)
        {
            bool respuesta = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.ConexionRibisoft()))
                {
                    cn.Open();
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Estado = 1 AND usrclaveencriptada = @usrclaveencriptada";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@usrclaveencriptada", oConteo.codigo);
                        int count = (int)cmd.ExecuteScalar();


                        respuesta = count > 0;
                    }
                }

            }
            catch (Exception ex) { }
            return respuesta; 
        }
    



    }
}
