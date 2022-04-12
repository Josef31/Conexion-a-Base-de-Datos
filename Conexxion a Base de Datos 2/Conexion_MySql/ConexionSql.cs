using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexxion_a_Base_de_Datos_2.Conexion_MySql
{
    class ConexionSql
    {

        public static MySqlConnection conexion()
        {
            

            try
            {
                MySqlConnection conexionBD = new MySqlConnection("server=127.0.0.1; database=example; Uid=root; pwd=");
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
              
    }
}
