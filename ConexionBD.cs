using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Problema1_3_Banco_Nico_V1
{
    internal class ConexionBD
    {
        SqlConnection cnn;

        public ConexionBD()
        {
            cnn = new SqlConnection(@"Data Source=localhost;Initial Catalog=PII_Problema1_3_Banco;Integrated Security=True");
        
        }

        internal DataTable ConsultaBD(string nombreSP)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand (nombreSP, cnn);

            cmd.CommandType = CommandType.StoredProcedure;
           


            cnn.Open ();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close ();   


            return tabla;
        }
    }
}
