using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BankApp.Domain;
using BankApp.Data.Interfaces;

namespace BankApp.Data
{
    public class DataHelper
    {
        private static DataHelper helper;
        string cnnString = @"Data Source=172.16.10.196;Initial Catalog=BancoDb;User Id=Alumno1w2;password=alumno1w2";
        private SqlConnection cnn;
        private DataHelper()
        {
            cnn = new SqlConnection(cnnString);
        }

        public static DataHelper GetHelper()
        {
            if (helper == null)
            {
                helper = new DataHelper();
            }
            return helper;
        }

        public DataTable ExecuteSPQuery(string sp, List<Parameter>? parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cnn.Open();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;

                foreach (var parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);
                }

                dt.Load(cmd.ExecuteReader());

                cnn.Close();


            }
            catch (SqlException ex)
            {
                dt = null;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return dt;
        }

        public int InsertClientAndAccounts(Client client)
        {
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("CREAR_CLIENTE", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NOMBRE", client.Name);
                cmd.Parameters.AddWithValue("@APELLIDO", client.Name);
                cmd.Parameters.AddWithValue("@DNI", client.Name);


                SqlParameter output = new SqlParameter();
                output.ParameterName = "@ID";
                output.SqlDbType = SqlDbType.Int;
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                int idClient = (int)cmd.Parameters["@ID"].Value;

                int rows = cmd.ExecuteNonQuery();

                foreach(var account in client.Accounts)
                {
                    SqlCommand cmdAcc = new SqlCommand("CREAR_CUENTA", cnn, t);

                    cmdAcc.Parameters.AddWithValue("@CBU", account.Cbu);
                    cmdAcc.Parameters.AddWithValue("@SALDO", account.Balance);
                    cmdAcc.Parameters.AddWithValue("@TIPO_CUENTA_ID", account.TypeAccount.Id);
                    cmdAcc.Parameters.AddWithValue("@ULTIMO_MOVIMIENTO", account.LastMove);
                    cmdAcc.Parameters.AddWithValue("@CLIENTE_ID", idClient);

                    cmdAcc.ExecuteNonQuery();
                }
                cnn.Close();

                t.Commit();
                return rows;
            }
            catch(SqlException ex)
            {
                t.Rollback();
                return 0;
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            
        }

        public int SimpleInsert(string sp, List<Parameter> parameters)
        {
            int rows;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach(Parameter p in parameters)
                {
                    cmd.Parameters.AddWithValue(p.Name, p.Value);
                }
                rows = cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (SqlException ex)
            {
                rows = 0;
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return rows;
        }
    }
}