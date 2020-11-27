using Dapper;
using Maxi.Persistencia.DataAccess;
using Maxi.Util.Log;
using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Persistencia.ProductoDAO
{
    public static class ProductoDAO
    {
        private static string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        //

        public static IEnumerable<Producto> ListarProductos()
        {
            
            IEnumerable<Producto> results =null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {

                    results = (List<Producto>)db.Query<Producto>(Resources.Resources.GetAllProductos).ToList();
                    
                }
                
            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static IEnumerable<Producto> BuscarProductoId(Producto producto)
        {

            IEnumerable<Producto> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var parametros = new
                    {
                        idproducto = producto.idProducto,

                    };

                    results = (List<Producto>)db.Query<Producto>(Resources.Resources.GetProductoById, parametros).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static Boolean InsertarProducto(Producto producto)
        {
            Boolean respuesta = false;
            IEnumerable<Producto> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (producto !=null) { 
                    
                        var parametros = new { nombreProducto = producto.nombreProducto, 
                            dimensiones = producto.dimensiones,
                            unidadEmpaque = producto.unidadEmpaque,
                            precio = producto.precio };


                        results = (List<Producto>)db.Query<Producto>(Resources.Resources.InsertProducto, parametros).ToList();
                    }
                    if (results != null) { 
                        if (results.ToList<Producto>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
        public static Boolean ActualizarProducto(Producto producto)
        {
            Boolean respuesta = false;
            IEnumerable<Producto> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (producto != null)
                    {

                        var parametros = new
                        {
                            idproducto = producto.idProducto,
                            nombreProducto = producto.nombreProducto,
                            dimensiones = producto.dimensiones,
                            unidadEmpaque = producto.unidadEmpaque,
                            precio = producto.precio
                        };


                        results = (List<Producto>)db.Query<Producto>(Resources.Resources.UpdateProducto, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Producto>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
        public static Boolean EliminarProducto(Producto producto)
        {
            Boolean respuesta = false;
            IEnumerable<Producto> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (producto != null)
                    {

                        var parametros = new
                        {
                            idproducto = producto.idProducto,
                           
                        };


                        results = (List<Producto>)db.Query<Producto>(Resources.Resources.EliminarProducto, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Producto>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProductoDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
    }
}
