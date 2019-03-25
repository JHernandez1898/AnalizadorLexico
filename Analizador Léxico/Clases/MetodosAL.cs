using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    public class MetodosAL
    {
        public static void ObtenerToken(string Palabra, ref List<string> tokens)
        {
            int intEstadoActual = 0;
            bool bandera = false;
            foreach (char c in Palabra)
            {
                intEstadoActual = NuevoEstado(c, intEstadoActual, ref bandera);
                if (bandera)
                {
                    tokens.Add(ObtenerToken(intEstadoActual));
                    intEstadoActual = 0;
                    bandera = false;
                }
            }
            intEstadoActual = NuevoEstado(' ', intEstadoActual, ref bandera);
            tokens.Add(ObtenerToken(intEstadoActual));
        }

        public static int NuevoEstado(char c, int intEstadoActual, ref bool bandera)
        {
            int Estado = 0;
            using (SqlConnection con = ConexionMatriz.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("EXEC NUEVOESTADO '" + c + "'," + intEstadoActual + "",con);
                SqlDataReader estado = comando.ExecuteReader();
                if (estado.Read()) if (!estado.IsDBNull(0)) Estado = estado.GetInt32(0);
                comando = new SqlCommand("SELECT TOKEN FROM TRANSICION WHERE ESTADO = " + Estado, con);
                estado = comando.ExecuteReader();
                if (estado.Read()) if (!estado.IsDBNull(0)) bandera = true;
            }
            return Estado;
        }
        public static string ObtenerToken(int intEstadoActual)
        {
            string token = "";
            using (SqlConnection con = ConexionMatriz.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("select token from transicion where estado = " + intEstadoActual, con);
                SqlDataReader tok = comando.ExecuteReader();
                if (tok.Read()) if (!tok.IsDBNull(0)) token = tok.GetString(0);
            }
            return token;
        }

    }
}
