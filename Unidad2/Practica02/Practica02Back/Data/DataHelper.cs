using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.Remoting.Channels;

namespace Practica02.Data
{
    public class DataHelper
    {
        private static DataHelper instance = null;
        private SqlConnection cnn;

        public DataHelper()
        {
            cnn = new SqlConnection(@"Data Source=gab09;Initial Catalog=FACTURACION;Integrated Security=True");
        }
        public static DataHelper GetInstance()
        {
            if(instance == null)
                instance = new DataHelper();
            return instance;
        }
        public SqlConnection GetConnection()
        {
            return cnn;
        }

        public DataTable Consultar(string nombreSp, List<SqlParameter> parameters= null)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSp;

            if(parameters != null)
            {
                foreach(var param in parameters)
                    cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }
    }
}
