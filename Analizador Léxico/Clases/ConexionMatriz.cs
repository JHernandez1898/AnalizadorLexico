﻿using System;
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
            SqlConnection con = new SqlConnection(@"Data Source=localhost; Initial Catalog = LENGUAJE; Integrated Security = SSPI; Trusted_Connection=True; MultipleActiveResultSets=True");
            con.Open();
            return (con);
        }
    }
}
