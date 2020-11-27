using Dapper;
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

namespace Maxi.Persistencia.Proveedores
{
    public static class ProveedorDAO
    {
        private static string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        //

        public static IEnumerable<Proveedor> ListarProveedores()
        {

            IEnumerable<Proveedor> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {

                    results = (List<Proveedor>)db.Query<Proveedor>(Resources.Resources.GetAllProveedores).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static IEnumerable<Proveedor> BuscarProveedorId(Proveedor proveedor)
        {

            IEnumerable<Proveedor> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var parametros = new
                    {
                        idproducto = proveedor.idProveedor,

                    };

                    results = (List<Proveedor>)db.Query<Proveedor>(Resources.Resources.GetProveedorById, parametros).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static Boolean InsertarProveedor(Proveedor proveedor)
        {
            Boolean respuesta = false;
            IEnumerable<Proveedor> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (proveedor != null)
                    {

                        var parametros = new
                        {
                            
                            celular = proveedor.celular,
                            direccion = proveedor.direccion,
                            emailContacto = proveedor.emailContacto,
                            estado = proveedor.estado,
                            nit = proveedor.nit,
                            nombreContacto = proveedor.nombreContacto,
                            nroDocContacto = proveedor.nroDocContacto,
                            razonSocial = proveedor.razonSocial,
                            telefonoFijo = proveedor.telefonoFijo,
                            tipoDocContacto = proveedor.tipoDocContacto
                            
                        };


                        results = (List<Proveedor>)db.Query<Proveedor>(Resources.Resources.InsertProveedor, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Proveedor>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
        public static Boolean ActualizarProveedor(Proveedor proveedor)
        {
            Boolean respuesta = false;
            IEnumerable<Proveedor> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (proveedor != null)
                    {

                        var parametros = new
                        {
                            idProveedor = proveedor.idProveedor,
                            celular = proveedor.celular,
                            direccion = proveedor.direccion,
                            emailContacto = proveedor.emailContacto,
                            estado = proveedor.estado,
                            nit = proveedor.nit,
                            nombreContacto = proveedor.nombreContacto,
                            nroDocContacto = proveedor.nroDocContacto,
                            razonSocial = proveedor.razonSocial,
                            telefonoFijo = proveedor.telefonoFijo,
                            tipoDocContacto = proveedor.tipoDocContacto
                        };


                        results = (List<Proveedor>)db.Query<Proveedor>(Resources.Resources.UpdateProveedor, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Proveedor>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
        public static Boolean EliminarProveedor(Proveedor proveedor)
        {
            Boolean respuesta = false;
            IEnumerable<Proveedor> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (proveedor != null)
                    {

                        var parametros = new
                        {
                            idproducto = proveedor.idProveedor,

                        };


                        results = (List<Proveedor>)db.Query<Proveedor>(Resources.Resources.EliminarProveedor, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Proveedor>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProveedorDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
    }
}
