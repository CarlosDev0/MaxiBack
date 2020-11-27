using Dapper;
using Maxi.Util.Log;
using Maxi.Util.Seguridad;
using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Persistencia.UsuarioPersistencia
{
    public static class UsuarioDAO
    {
        private static string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        public static Boolean CrearPassword(LoginRequest usuario)
        {

            IEnumerable<Usuario> results = null;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var parametros = new
                    {
                        UserName = usuario.Username,
                        Password = Encrypt.GetSHA256(usuario.Password)

                    };

                    results = (List<Usuario>)db.Query<Usuario>(Resources.Resources.CrearPassword, parametros).ToList();

                }
                
            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in ProveedoresDAO" + e.Message);
                return false;
            }
            if (results != null)
            {
                if (results.ToList<Usuario>().Count > 0)
                    return true;
                else
                    return false;
            }
            else {
                return false;
            }
        }
    }
}
