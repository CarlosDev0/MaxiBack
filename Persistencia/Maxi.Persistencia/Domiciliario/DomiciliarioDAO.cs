using Dapper;
using Maxi.Util.Log;
using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Persistencia.DomiciliarioDAO
{
    public static class DomiciliarioDAO
    {
        private static string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        //

        public static IEnumerable<Domiciliario> ListarDomiciliarios()
        {

            IEnumerable<Domiciliario> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {

                    results = (List<Domiciliario>)db.Query<Domiciliario>(Resources.Resources.GetAllDomiciliarios).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static IEnumerable<Domiciliario> BuscarDomiciliarioId(Domiciliario domiciliario)
        {

            IEnumerable<Domiciliario> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var parametros = new
                    {
                        idDomiciliario = domiciliario.idDomiciliario,

                    };

                    results = (List<Domiciliario>)db.Query<Domiciliario>(Resources.Resources.GetDomiciliarioById, parametros).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static Boolean InsertarDomiciliario(Domiciliario domiciliario)
        {
            Boolean respuesta = false;
            IEnumerable<Domiciliario> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (domiciliario != null)
                    {
                        var parametros = new DynamicParameters();
                        parametros.Add("@celular", domiciliario.celular, DbType.String, ParameterDirection.Input, domiciliario.celular.Length);
                        parametros.Add("@telefono", domiciliario.telefono, DbType.String, ParameterDirection.Input, domiciliario.telefono.Length);
                        parametros.Add("@nombres", domiciliario.nombres, DbType.String, ParameterDirection.Input, domiciliario.nombres.Length);
                        parametros.Add("@apellidos", domiciliario.apellidos, DbType.String, ParameterDirection.Input, domiciliario.apellidos.Length);
                        parametros.Add("@tipoDoc", domiciliario.tipoDoc, DbType.String, ParameterDirection.Input, domiciliario.tipoDoc.Length);
                        
                        parametros.Add("@direccion", domiciliario.direccion, DbType.String, ParameterDirection.Input, domiciliario.direccion.Length);
                        parametros.Add("@estado", domiciliario.estado, DbType.Boolean, ParameterDirection.Input);
                        parametros.Add("@nroDoc", domiciliario.nroDoc, DbType.Int32, ParameterDirection.Input);

                        results = (List<Domiciliario>)db.Query<Domiciliario>(Resources.Resources.InsertDomiciliario, parametros).ToList();
                        


                        
                    }
                    if (results != null)
                    {
                        if (results.ToList<Domiciliario>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
        public static Boolean ActualizarDomiciliario(Domiciliario domiciliario)
        {
            Boolean respuesta = false;
            IEnumerable<Domiciliario> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (domiciliario != null)
                    {

                        var parametros = new DynamicParameters();
                        //parametros.Add("@idDomiciliario", short.Parse(domiciliario.idDomiciliario.ToString(new CultureInfo("es-es")), new CultureInfo("es-es")), DbType.Int16, ParameterDirection.Input);
                        parametros.Add("@idDomiciliario", short.Parse(domiciliario.idDomiciliario.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture), DbType.Int16, ParameterDirection.Input);
                        
                        parametros.Add("@celular", domiciliario.celular, DbType.String, ParameterDirection.Input, domiciliario.celular.Length);
                        parametros.Add("@telefono", domiciliario.telefono, DbType.String, ParameterDirection.Input, domiciliario.telefono.Length);
                        parametros.Add("@estado", domiciliario.estado, DbType.Boolean, ParameterDirection.Input);
                        parametros.Add("@nombres", domiciliario.nombres, DbType.String, ParameterDirection.Input, domiciliario.nombres.Length);
                        parametros.Add("@apellidos", domiciliario.apellidos, DbType.String, ParameterDirection.Input, domiciliario.apellidos.Length);
                        parametros.Add("@tipoDoc", domiciliario.tipoDoc, DbType.String, ParameterDirection.Input, domiciliario.tipoDoc.Length);
                        
                        parametros.Add("@direccion", domiciliario.direccion, DbType.String, ParameterDirection.Input, domiciliario.direccion.Length);
                        
                        parametros.Add("@nroDoc", domiciliario.nroDoc, DbType.Int32, ParameterDirection.Input);



                        results = (List<Domiciliario>)db.Query<Domiciliario>(Resources.Resources.UpdateDomiciliario, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Domiciliario>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
        public static Boolean EliminarDomiciliario(Domiciliario producto)
        {
            Boolean respuesta = false;
            IEnumerable<Domiciliario> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (producto != null)
                    {

                        var parametros = new
                        {
                            idDomiciliario = producto.idDomiciliario,

                        };


                        results = (List<Domiciliario>)db.Query<Domiciliario>(Resources.Resources.EliminarDomiciliario, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Domiciliario>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in DomiciliarioDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
    }
}
