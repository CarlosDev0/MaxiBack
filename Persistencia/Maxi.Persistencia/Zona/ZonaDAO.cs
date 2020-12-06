using Dapper;
using Maxi.Util.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MaxiEntregas.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maxi.Persistencia.ZonaDAO
{
    public static class ZonaDAO
    {
        private static string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        public static IEnumerable<Zona> ListarZonas()
        {

            IEnumerable<Zona> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {

                    results = (List<Zona>)db.Query<Zona>(Resources.Resources.GetAllZonas).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static IEnumerable<Zona> BuscarZonaId(Zona zona)
        {

            IEnumerable<Zona> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var parametros = new
                    {
                        idZona = zona.idZona,

                    };

                    results = (List<Zona>)db.Query<Zona>(Resources.Resources.GetZonaById, parametros).ToList();

                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return null;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + ce.Message);
                return null;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return null;
            }
            return results;
        }
        public static Boolean InsertarZona(Zona zona)
        {
            Boolean respuesta = false;
            IEnumerable<Zona> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (zona != null)
                    {

                        var parametros = new
                        {

                            nombreZona = zona.nombreZona,
                            municipio = zona.municipio,
                            estado = zona.estado,
                            valorCobro = zona.valorCobro,
                            

                        };


                        results = (List<Zona>)db.Query<Zona>(Resources.Resources.InsertZona, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Zona>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            return respuesta;
        }

        public static Boolean ActualizarZona(Zona zona)
        {
            Boolean respuesta = false;
            IEnumerable<Zona> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (zona != null)
                    {

                        var parametros = new
                        {
                            idZona = zona.idZona,
                            nombreZona = zona.nombreZona,
                            municipio = zona.municipio,
                            estado = zona.estado,
                            valorCobro = zona.valorCobro,
                            
                        };


                        results = (List<Zona>)db.Query<Zona>(Resources.Resources.UpdateZona, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Zona>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            return respuesta;
        }

        public static Boolean EliminarZona(Zona zona)
        {
            Boolean respuesta = false;
            IEnumerable<Zona> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    if (zona != null)
                    {

                        var parametros = new
                        {
                            idZona = zona.idZona,

                        };


                        results = (List<Zona>)db.Query<Zona>(Resources.Resources.EliminarZona, parametros).ToList();
                    }
                    if (results != null)
                    {
                        if (results.ToList<Zona>().Count > 0)
                            respuesta = true;
                    }
                }

            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ZonaDAO" + e.Message);
                return false;
            }
            return respuesta;
        }
    }
}
