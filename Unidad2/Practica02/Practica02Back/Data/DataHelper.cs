using Practica02Back.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        public DataTable ExecuteSPQuery(string sp, List<ParameterSql> parametros)
        {
            DataTable t = new DataTable();
            try
            {
                cnn.Open();
                var cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                t.Load(cmd.ExecuteReader());
                cnn.Close();
            }
            catch (SqlException)
            {
                t = null;
            }

            return t;
        }


        public int ExecuteSPDML(string sp, List<ParameterSql> parametros)
        {
            int rows;
            try
            {
                cnn.Open();
                var cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var param in parametros)
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                }

                rows = cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (SqlException)
            {
                rows = 0;
            }

            return rows;
        }
    }
}
