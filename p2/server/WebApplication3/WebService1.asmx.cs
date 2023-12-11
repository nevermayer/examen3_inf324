using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication3
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet ListaEstudiante() {
            // Cadena de conexión a la base de datos MySQL
            string connectionString = "Server=localhost;Database=midb_ramos;Uid=root;Pwd=;";

            // Consulta SQL
            string query  = "select id_persona, nombres, paterno, materno, sexo, fec_nac from personas where id_persona in (select id_persona from estudiante)";

            // Crear la conexión a la base de datos
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Crear el adaptador de datos
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                // Crear y llenar el DataSet
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
        }
        [WebMethod]
        public string CreaEstudiante(string id, string nombre, string paterno, string materno, string fec_nac, string sexo)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string connectionString = "Server=localhost;Database=midb_ramos;Uid=root;Pwd=;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a MySQL.");

                    string consultaSQL = "INSERT INTO personas (id_persona,nombres,paterno,materno,fec_nac,sexo) VALUES ('" + id + "','" + nombre + "','" + paterno + "','" + materno + "','" + fec_nac + "','" + sexo + "')";
                    using (MySqlCommand cmd1 = new MySqlCommand(consultaSQL, connection))
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    consultaSQL = "INSERT INTO estudiante (id_persona) VALUES ('" + id + "')";
                    using (MySqlCommand cmd2 = new MySqlCommand(consultaSQL, connection))
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    
                    connection.Close();
                    return "registro creado";
                }
                catch (MySqlException ex)
                {
                    return "Error al conectar a MySQL: " + ex.Message;
                }
            }
            return "no realizado";
        }
        [WebMethod]
        public string eliminaEstudiante(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string connectionString = "Server=localhost;Database=midb_ramos;Uid=root;Pwd=;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a MySQL.");

                    string consultaSQL = "DELETE FROM estudiante WHERE id_persona = '" + id + "'";
                    //MySqlCommand cmd = new MySqlCommand(consultaSQL, connection);
                    using (MySqlCommand cmd1 = new MySqlCommand(consultaSQL, connection))
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    consultaSQL = "DELETE FROM personas WHERE id_persona = '" + id + "'";
                    using (MySqlCommand cmd2 = new MySqlCommand(consultaSQL, connection))
                    {
                        cmd2.ExecuteNonQuery();
                    }

                    connection.Close();
                    return "registro eliminado";
                }
                catch (MySqlException ex)
                {
                    return "Error al conectar a MySQL: " + ex.Message;
                }
            }
            return "no realizado";
        }
        [WebMethod]
        public string editaEstudiante(string id, string nombre, string paterno, string materno, string fec_nac, string sexo)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string connectionString = "Server=localhost;Database=midb_ramos;Uid=root;Pwd=;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a MySQL.");
                    string consultaSQL = "UPDATE personas SET nombres = '" + nombre + "', paterno = '" + paterno + "', materno = '" + materno + "', fec_nac = '" + fec_nac + "', sexo = '" + sexo + "' WHERE id_persona = '" + id + "'";

                    using (MySqlCommand cmd1 = new MySqlCommand(consultaSQL, connection))
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    connection.Close();
                    return "registro actualizado";
                }
                catch (MySqlException ex)
                {
                    return "Error al conectar a MySQL: " + ex.Message;
                }
            }
            return "no realizado";
        }
    }
}
