using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    class ConexionMatriz
    {
        public static SqlConnection ObtenerConexion()
        {
           // SqlConnection con = new SqlConnection(@"Data Source=LA-DIVERTIDA; Initial Catalog = LENGUAJE; Server=LA-DIVERTIDA\SQLEXPRESS; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-EF1M9DTE; Initial Catalog = LENGUAJE; Server=LAPTOP-EF1M9DTE\KINGBRADLEY; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            //SqlConnection con = new SqlConnection(@"Data Source=localhost; Initial Catalog = LENGUAJE; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            //SqlConnection con = new SqlConnection(@"Data Source=HERNANDEZ109; Initial Catalog = LENGUAJE; Server=HERNANDEZ109\SQLEXPRESS; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            // SqlConnection con = new SqlConnection(@"Data Source=localhost; Initial Catalog = LENGUAJE; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            con.Open();
            return (con);
        }
    }
}
