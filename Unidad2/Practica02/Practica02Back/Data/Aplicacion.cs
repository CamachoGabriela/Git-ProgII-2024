using Practica02.Data;
using Practica02.Models;
using Practica02Back.Data;
using Practica02Back.Models;
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
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_ARTICULOS",null);       
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
        public Factura GetById(int id)
        {
            Factura oFactura = null;
            var helper = DataHelper.GetInstance();
            var parameter = new ParameterSql("@nro_factura", id);
            var parameters = new List<ParameterSql>();
            parameters.Add(parameter);

            var t = helper.ExecuteSPQuery("SP_RECUPERAR_FACTURA_POR_ID", parameters); 
            foreach (DataRow row in t.Rows)
            {
                if (oFactura == null)
                {
                    oFactura = new Factura();
                    oFactura.NroFactura = Convert.ToInt32(row["nro_factura"].ToString());
                    oFactura.Fecha = Convert.ToDateTime(row["fecha"].ToString());
                    oFactura.FormaPago = new FormaPago();
                    oFactura.FormaPago.Id = Convert.ToInt32(row["id_forma_pago"]);
                    oFactura.FormaPago.Name = row["nombre_fp"].ToString();
                    oFactura.Cliente = row["cliente"].ToString();
                    oFactura.AddDetail(ReadDetail(row));
                }
                else
                {
                    oFactura.AddDetail(ReadDetail(row));
                }
            }
            return oFactura;
        }
        public List<Factura> ConsultaFiltros(DateTime fecha, int fp )
        {
            var parameters = new List<ParameterSql>();
            var paramFecha = new ParameterSql("@fecha",fecha);
            parameters.Add(paramFecha);
            var paramFp = new ParameterSql("@fp", fp);       //ver nombre
            parameters.Add(paramFp);
            DataTable tabla = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_POR_FECHA_FP", parameters); 
            List<Factura> lista = new List<Factura>();

            foreach (DataRow row in tabla.Rows)
            {
                Factura factura = new Factura()
                {
                    NroFactura = Convert.ToInt32(row["NRO_FACTURA"]),
                    Fecha = (DateTime)row["FECHA"],
                    FormaPago = new FormaPago()
                    {
                        Id = (int)row["ID_FORMA_PAGO"],
                        Name = row["nombre_fp"].ToString(),
                    },
                    Cliente = (row["CLIENTE"].ToString())
                };
                lista.Add(factura);
            }
            return lista;

        }
        public bool SaveFactura(Factura oFactura)
        {
            bool result = true;
            SqlTransaction t = null;
            SqlConnection cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t); 
                cmd.CommandType = CommandType.StoredProcedure;

                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@id_forma_pago", oFactura.FormaPago.Id);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                //parámetro de salida:
                SqlParameter param = new SqlParameter("@nro_factura", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int budgetId = (int)param.Value;

                int nroDetail = 1;
                foreach (var detail in oFactura.Details())
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t); 
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@nro_factura", budgetId);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", nroDetail);
                    cmdDetail.Parameters.AddWithValue("@id_articulo", detail.Articulo.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Cantidad);
                    cmdDetail.ExecuteNonQuery();
                    nroDetail++;
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
        private Detalle ReadDetail(DataRow row)
        {
            Detalle detail = new Detalle();
            detail.Id = Convert.ToInt32(row["id_detalle"]);
            detail.Articulo = new Articulo()
            {
                Codigo = Convert.ToInt32(row["id_articulo"].ToString()),
                Nombre = row["nombre_articulo"].ToString(),
                PrecioUnitario = Convert.ToDecimal(row["precio_unitario"].ToString())
            };
            detail.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
            return detail;
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

        public List<Factura> GetFacturas()
        {
            List<Factura> lst = new List<Factura>();
            Factura oFactura = null;
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_OBTENER_FACTURA_CON_DETALLES", null);
            foreach (DataRow row in t.Rows)
            {
                //leer la primer fila y tomar datos del maestro y primer detalle
                if (oFactura == null || oFactura.NroFactura != Convert.ToUInt32(row["nro_factura"].ToString())) //para tomar los datos del maestro con los datos del primer detalle
                {

                    oFactura = new Factura();
                    oFactura.NroFactura = Convert.ToInt32(row["nro_factura"]);
                    oFactura.Fecha = Convert.ToDateTime(row["fecha"].ToString());
                    oFactura.FormaPago = new FormaPago();
                    oFactura.FormaPago.Id = Convert.ToInt32(row["id_forma_pago"]);
                    oFactura.FormaPago.Name = row["nombre_fp"].ToString();
                    oFactura.Cliente = row["cliente"].ToString();
                    oFactura.AddDetail(ReadDetail(row));
                    lst.Add(oFactura);
                }
                else
                {
                    //mientras no cambia el Id del maestro, leer datos de detalles.
                    oFactura.AddDetail(ReadDetail(row));
                }
            }
            return lst;
        }

        public bool UpdateFactura(Factura oFactura)
        {
            bool result = true;
            SqlTransaction t = null;
            SqlConnection cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_ACTUALIZAR_MAESTRO", cnn, t);  
                cmd.CommandType = CommandType.StoredProcedure;

                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@nro_factura", oFactura.NroFactura);
                cmd.Parameters.AddWithValue("@id_forma_pago", oFactura.FormaPago.Id);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);

                cmd.ExecuteNonQuery();

                int nroDetail = 0;
                foreach (var detail in oFactura.Detalles)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t); 
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@nro_factura", oFactura.NroFactura);
                    cmdDetail.Parameters.AddWithValue("@id_detalle", nroDetail);
                    cmdDetail.Parameters.AddWithValue("@id_articulo", detail.Articulo.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Cantidad);
                    cmdDetail.ExecuteNonQuery();
                    nroDetail++;
                }

                t.Commit();
            }
            catch (SqlException w)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
