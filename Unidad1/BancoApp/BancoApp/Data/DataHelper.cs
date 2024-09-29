using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using BancoApp.Domain;
using System.Diagnostics.CodeAnalysis;

namespace BancoApp.Data
{
    public class DataHelper
    {
        private static DataHelper helper;

        private string cnn_string = @"Data Source=DESKTOP-VSD47N1\DATABASEGABI;Initial Catalog=bankApp_412459;Integrated Security=True;Encrypt=False";
        private SqlConnection cnn;

        private DataHelper()
        {
            cnn = new SqlConnection(cnn_string);
        }

        public static DataHelper GetInstance()
        {
            if (helper == null)
            {
                helper = new DataHelper();
            }

            return helper;
        }

        public int CreateAccount(Account a)
        {
            int affectedRows;

            if (!ValidateAccount(a.Client.Dni))
            {
                string sp = "SP_Insertar_Cuenta";
                
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", a.Client.Dni);
                cmd.Parameters.AddWithValue("@nombre", a.Client.Name);
                cmd.Parameters.AddWithValue("@apellido", a.Client.Surname);
                cmd.Parameters.AddWithValue("@cbu", a.Cbu);
                cmd.Parameters.AddWithValue("@saldo", a.Balance);
                cmd.Parameters.AddWithValue("@tipo", a.TypeAccount);
                cmd.Parameters.AddWithValue("ultimo", a.LastMove);

                cnn.Open();

                affectedRows = cmd.ExecuteNonQuery();

                cnn.Close();
            }
            else
            {
                affectedRows = 0;
                
            }
            return affectedRows;
        }
            
        private bool ValidateAccount(int id)
        {
            bool ExistentAccount = false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.CommandText = "Select * from Clientes where dni = " + id;

            cnn.Open();

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            cnn.Close();

            if(dt.Rows.Count > 0)
                ExistentAccount=true;

            return ExistentAccount;
        }
    }
}
