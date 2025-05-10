using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml.Linq;

namespace WindowsFormsApp1.Conexiones
{
    public class Conexion
{
    private static string cadenaConexion = "server=localhost;database=SchoolBD;uid=root;pwd=;";

    public static MySqlConnection Conectar()
    {
        try
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al conectar: " + ex.Message);
            throw;
        }
    }
}
}