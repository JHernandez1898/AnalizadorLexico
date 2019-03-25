using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenguaje
{
    public abstract class ConexionBD
    {
        /*Metodos para crear la matriz
        public static int ContarEstados()
        {
            int numeroEstados = 0;
            using (SqlConnection con  = ObtenerConexionAutenticadaWindows())
            {
                con.Close();
                con.Open();                
                SqlCommand comando = new SqlCommand("SELECT COUNT(estado) FROM TRANSICION",con);
                SqlDataReader Mostrar =  comando.ExecuteReader();
                while (Mostrar.Read()) numeroEstados = Mostrar.GetInt32(0);
            }
            return numeroEstados;
        }*/

        /*public static void IngresarPalabra(string strPalabra, string strToken, SqlConnection unaConexion)
        {
            unaConexion.Close();
            unaConexion.Open();
            SqlCommand comando;
            int intEstadoActual = 0;
            int intContador = 0;
            foreach (char unCaracter in strPalabra.ToArray())
            {
                intContador++;
                if (OmitirDuplicados(unCaracter, unaConexion,  intEstadoActual) > -1)
                {
                    if (intContador != strPalabra.ToArray().Length)
                    {
                        intEstadoActual = OmitirDuplicados(unCaracter, unaConexion, intEstadoActual);
                        if (OmitirDuplicados(strPalabra.ToArray()[intContador], unaConexion, intEstadoActual) == -1)
                        {
                            comando = new SqlCommand("UPDATE TRANSICION SET " + strPalabra.ToArray()[intContador] + "= "+ContarEstados().ToString()+" WHERE estado = " + intEstadoActual, unaConexion);
                            comando.ExecuteNonQuery();
                            if(intContador != strPalabra.Length - 1)
                            {
                                SqlCommand comandoCreacion = new SqlCommand("INSERT INTO TRANSICION (estado) VALUES (" + ContarEstados().ToString() + ")", unaConexion);
                                comandoCreacion.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    if (ContarEstados() > 0 && intEstadoActual == 0)
                    {                       
                        comando = new SqlCommand("UPDATE TRANSICION SET " + unCaracter.ToString() + " = "+ContarEstados().ToString()+"  WHERE estado = " + intEstadoActual, unaConexion);
                        comando.ExecuteNonQuery();
                        intEstadoActual = ContarEstados();
                    }
                    else
                    {
                        comando = new SqlCommand("INSERT INTO TRANSICION (estado," + unCaracter.ToString() + ") VALUES((SELECT COUNT(estado) FROM TRANSICION), (SELECT COUNT(estado) + 1 FROM TRANSICION))", unaConexion);
                        comando.ExecuteNonQuery();
                        intEstadoActual = ContarEstados();
                    }                    
                }               
            }
            comando = new SqlCommand("INSERT INTO TRANSICION (estado, del) VALUES((SELECT COUNT(estado) FROM TRANSICION), (SELECT COUNT(estado) + 1 FROM TRANSICION))", unaConexion);
            comando.ExecuteNonQuery();
            comando = new SqlCommand("INSERT INTO TRANSICION (estado, token) VALUES((SELECT COUNT(estado) FROM TRANSICION),  '" + strToken + "')", unaConexion);
            comando.ExecuteNonQuery();
            comando.Dispose();
            unaConexion.Close();
        }*/

        /*public static int OmitirDuplicados(char unCaracterNoVerificado,SqlConnection unaConexion,int intEstadoActual)
        {
            unaConexion.Close();
            unaConexion.Open();
            string consulta = "SELECT " + unCaracterNoVerificado + " FROM TRANSICION WHERE " + unCaracterNoVerificado+ " IS NOT NULL AND estado = "+ intEstadoActual;
            SqlCommand cmd = new SqlCommand(consulta, unaConexion);
            SqlDataReader rd = cmd.ExecuteReader();
            return (rd.Read() ? Convert.ToInt32(rd[0]) : -1);
        }*/

        /*public static SqlConnection ObtenerConexionAutenticadaWindows()
        {
            //LA-DIVERTIDA
            //HERNANDEZ109
            return Conectar(@"Data Source=LA-DIVERTIDA; Initial Catalog = LENGUAJE; Server=LA-DIVERTIDA\SQLEXPRESS; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
        }
        private static SqlConnection Conectar(string strCadenaConexion)
        {
            SqlConnection con = new SqlConnection(strCadenaConexion);            
            return con;
        }*/


        //Metodos para el analizador lexico

        public void ObtenerToken(string Palabra, ref List<string> tokens)
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
        public int NuevoEstado(char c, int intEstadoActual, ref bool bandera)
        {
            int Estado = 0;

    }    
}
