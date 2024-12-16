using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConteoDeInventario.Logica
{
    public class CONEXION
    {
        public string ConexionRibisoft()
        {
            string servidor = @"SERVIDOR-PC\SQLEXPRESS";
            string NombreBaseDatos = "Administrativo";
            string usuario = "sa";
            string contraseña = "abcd.1234";
            string cadena = $"Data Source={servidor};Initial Catalog={NombreBaseDatos};User ID={usuario};Password={contraseña};";

            return cadena;

        }

        public string ConexionLaBodegaDeNacho()
        {
            string servidor = @"SERVIDOR-PC\SQLEXPRESS";
            string NombreBaseDatos = "LABODEGADENACHO";
            string usuario = "sa";
            string contraseña = "abcd.1234";
            string cadena = $"Data Source={servidor};Initial Catalog={NombreBaseDatos};User ID={usuario};Password={contraseña};";

            return cadena;

        }
     
    }
}
