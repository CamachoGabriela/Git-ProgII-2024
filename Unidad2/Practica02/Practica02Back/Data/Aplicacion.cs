using Practica02.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Practica02.Data
{
    public class Aplicacion : IAplicacion
    {
        public List<Articulo> ConsultarArticulo()
        {
            DataTable tabla = DataHelper.GetInstance().Consultar("SP_OBTENER_ARTICULOS");       
            List<Articulo> lista = new List<Articulo>();

            foreach(DataRow row in tabla.Rows)
            {
                Articulo articulo = new Articulo()
                {
                    Codigo = Convert.ToInt32(row["ID_ARTICULO"]),
                    Nombre = row["NOMBRE_ARTICULO"].ToString(),                                
                    PrecioUnitario = Convert.ToDecimal(row["PRECIO_UNITARIO"])
                };
                lista.Add(articulo);
            }
            return lista;
        }

        public bool RegistrarBajaArticulo(int id)
        {
            bool aux = true;
            SqlConnection conexion = DataHelper.GetInstance().GetConnection();
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_CANCELAR_ARTICULO", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID_ARTICULO",id);

                aux = cmd.ExecuteNonQuery() == 1;
                conexion.Close();
            }
            catch (SqlException)
            {
                aux = false;
            }
            return aux;
        }

        public bool SaveArticulo(Articulo a)
        {
            bool aux = true;
            SqlConnection cnn = DataHelper.GetInstance().GetConnection();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SP_SAVE_ARTICULOS", cnn); 
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter idParam = new SqlParameter("ID_ARTICULO", SqlDbType.Int);
                if (a.Codigo == 0 || a.Codigo == null)
                    idParam.Value = DBNull.Value;  // Para indicar un nuevo artículo
                else
                    idParam.Value = a.Codigo;  // Para actualizar un artículo existente
                cmd.Parameters.Add(idParam);
                cmd.Parameters.AddWithValue("NOMBRE_ARTICULO",a.Nombre);
                cmd.Parameters.AddWithValue("PRECIO_UNITARIO", a.PrecioUnitario);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                aux = false;
            }
            finally
            {
                if(cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return aux;
        }

        public bool Validar(Articulo a)
        {
            bool result = true;
            string error = "";
            
            if(string.IsNullOrEmpty(a.Nombre)|| !Regex.IsMatch(a.Nombre, @"^[a-zA-Z\s]+$"))
            {
                result = false;
                error = " nombre ";
            }
            if(a.PrecioUnitario <=0)
            {
                result = false;
                error = " precio ";
            }
            if(!result)
                Console.WriteLine("Debe ingresar un valor válido en el "+error);

            return result;
        }
    }
}
