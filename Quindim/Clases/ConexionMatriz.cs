using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quindim.Clases
{
    class ConexionMatriz
    {
        public static SqlConnection ObtenerConexion(string serverName)
        {
           // SqlConnection con = new SqlConnection("Data Source=" + System.Environment.MachineName + "; Initial Catalog = LENGUAJE; Server=" + System.Environment.MachineName + "\\" + serverName + " ;Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            SqlConnection con=new SqlConnection("Data Source=" + System.Environment.MachineName + "; Initial Catalog = PROTOLENGUAJE; Server=" + System.Environment.MachineName + "\\"+serverName+" ;Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            // SqlConnection con = new SqlConnection(@"Data Source=localhost; Initial Catalog = LENGUAJE; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            con.Open();
            return (con);
        }
        public static bool ProbarConexion(string serverName)
        {
           // SqlConnection con = new SqlConnection("Data Source=" + System.Environment.MachineName + "\\" + serverName + "; Initial Catalog = LENGUAJE; Server=" + System.Environment.MachineName + "\\" + serverName + " ;Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            SqlConnection con = new SqlConnection("Data Source=" + System.Environment.MachineName +  "\\" + serverName+ "; Initial Catalog = PROTOLENGUAJE; Server=" + System.Environment.MachineName + "\\" + serverName + " ;Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            try
            {
                con.Open();
                if(con.State==System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                   
            }
            catch
            {
                return false;
            }
        }
    }
}
