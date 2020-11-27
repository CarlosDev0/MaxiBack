using Dapper;
using MaxiEntregas.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Npgsql;
using Maxi.Util;
using Maxi.Util.Log;
using Maxi.Persistencia.DataAccess;
using Maxi.Util.Seguridad;

namespace Maxi.Persistencia.Login
{
    public static class LoginDAO
    {
        
        //Trae el ConnexionString desde el archivo de configuración: Web.config
        private static string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        


        public static IEnumerable<Usuario> getUsuarios()
        {
            
            #region ODBC  
            //TELERIK PROGRESS - ODBC - No conectó
            //OdbcConnection DbConnection = new OdbcConnection("DSN=postgres");
            //DbConnection.Open();
            //OdbcCommand DbCommand = DbConnection.CreateCommand();
            //DbCommand.CommandText = "SELECT * FROM [Usuarios]";
            //OdbcDataReader DbReader = DbCommand.ExecuteReader();

            //DbReader.Close();
            //DbCommand.Dispose();
            //DbConnection.Close();

            //Npgsql - PostgreSQL
            //NpgsqlConnection conn = new NpgsqlConnection();

            //try
            //{

            //conn.ConnectionString = "Host=ec2-52-5-176-53.compute-1.amazonaws.com;Username=crzqmbratkgxxw;Database=postgres://crzqmbratkgxxw:ad8d4b2a71e70c880aa7;Password=ad8d4b2a71e70c880aa702cd9f51dbe94c753de8accc202787af16b781ae54d8;";
            ////conn.ConnectionString = "Host=ec2-52-5-176-53.compute-1.amazonaws.com;Username=crzqmbratkgxxw;Database=postgres://crzqmbratkgxxw:ad8d4b2a71e70c880aa7;Password=ad8d4b2a71e70c880aa702cd9f51dbe94c753de8accc202787af16b781ae54d8;UseSslStream=true;";
            ////conn.ConnectionString = "postgres://crzqmbratkgxxw:ad8d4b2a71e70c880aa702cd9f51dbe94c753de8accc202787af16b781ae54d8@ec2-52-5-176-53.compute-1.amazonaws.com:5432/dckphlp91n7cg4";
            //var d = conn.Database;
            //var p = conn.Port;
            //var h = conn.Host;
            //var u = conn.UserName;
            //var s = conn.UseSslStream;
            //NpgsqlCommand cmd = new NpgsqlCommand();
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT * FROM [Usuarios]";

            //conn.Open();
            //cmd.ExecuteReader();

            //using (var cmd = new NpgsqlCommand("SELECT * FROM [Usuarios]", conn)) {
            //    var a = 0;
            //}
            #endregion ODBC

            try
            {
                //SQL SERVER - CONSULTA MANUAL:
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    
                    var consulta = @"SELECT * FROM [Usuarios]";

                    db.Open();

                    // Se ejecuta la consulta y se mapean los resultados:
                    var Usuarios = db.Query<Usuario>(consulta);




                    #region SP
                    //SQL SERVER - SP GENÉRICO.
                    
                    //results.ForEach(r => Console.WriteLine($"{r.OrderID} {r.Subtotal}"));


                    //var Usuarios2 = EjecutarProcedimiento<Usuario>(Cadena_);

                    //SQL SERVER- CON SP:
                    //using (IDbConnection db = new SqlConnection(Cadena_))
                    //{
                    //    using (IDbCommand cmd = db.CreateCommand()) {
                    //        cmd.CommandType = CommandType.StoredProcedure;
                    //        cmd.CommandText = "SP_ConsultarUsuarios";
                    //        //var consulta = @"SELECT * FROM [Usuarios]";
                    //        cmd.Connection = db;
                    //        db.Open();

                    //var Usuarios = (IEnumerable<Usuario>)cmd.ExecuteReader();
                    //        using (IDataReader reader = cmd.ExecuteReader())
                    //        {
                    //            while (reader.Read())
                    //            {
                    //                yield return (T)reader[0];
                    //            }
                    //        }
                    #endregion


                    return Usuarios;

                }


            }

            
            

            
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception "+ e.Message);
                return null;
            }

            

        }
        public static Boolean Autenticar(LoginRequest login) {
            Boolean respuesta = false;
            try
            {
                using (IDbConnection db = new SqlConnection(Cadena_))
                {

                    var values = new { Usuario = login.Username,
                        Password = Encrypt.GetSHA256(login.Password)
                    };
                    
                    var results = (List<Usuario>)db.Query<Usuario>(Resources.Resources.Autenticar, values).ToList();
                    if(results !=null)
                        if (results.ToList<Usuario>().Count>0)
                            respuesta = true;
                    
                }
                #region Manual
                //using (IDbConnection db = new SqlConnection(Cadena_))
                //{
                //    {
                //        var consulta = @"SELECT COUNT(*) FROM [Usuarios] WHERE nombreUsuario ='" + login.Username + "'";

                //        db.Open();
                //        var cuentaUsuarios = db.QueryFirstOrDefault(consulta);
                //        if (cuentaUsuarios != null)
                //        {
                //            foreach (var user in cuentaUsuarios)
                //            {
                //                if (int.TryParse(user.Value.ToString(), out r))
                //                    if (r > 0) respuesta = true;
                //            }
                //        }

                //    }
                //}
                #endregion
            }
            catch (SqlException e)
            {
                Nlog.logger.Error("Exception in LoginDAO" + e.Message);
                return false;
            }
            catch (InvalidCastException ce) {
                Nlog.logger.Error("Exception in LoginDAO" + ce.Message);
                return false;
            }
            catch (FormatException e)
            {
                Nlog.logger.Error("Exception in LoginDAO" + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Nlog.logger.Error("Exception in LoginDAO" + e.Message);
                return false;
            }
            return respuesta;
        }

        public static IEnumerable<T> EjecutarProcedimiento<T>(string ConexionString)
        {
            using (IDbConnection db = new SqlConnection(ConexionString))
            {
                using (IDbCommand cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_ConsultarUsuarios";
                    //var consulta = @"SELECT * FROM [Usuarios]";
                    cmd.Connection = db;
                    db.Open();

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return (T)reader[0];
                        }
                    }



                }

            }

        }
        public static Usuario getUsuario(int id)
        {
            Usuario hero;
            try
            {
                //SQL SERVER
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var consulta = @"SELECT *
                    FROM [Usuarios] WHERE idUsuario=" + id;

                    // Se ejecuta la consulta y se mapean los resultados:

                    var listHero = (List<Usuario>)db.Query<Usuario>(consulta);
                    hero = listHero.FirstOrDefault();

                    return hero;
                }

            }
            catch (Exception e) when (e is NullReferenceException || e is InvalidOperationException)
            {
                Nlog.logger.Error("Exception in LoginDAO" + e.Message);
                return null;
            }

        }
    }
}
