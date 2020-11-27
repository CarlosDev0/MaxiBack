using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Persistencia.DataAccess
{
    public static class AccesoDatos
    {
        
        public static string prepararSP(string procedimiento) {
            return "exec " + procedimiento;
        }
        static AccesoDatos(){
            string Cadena_ = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
        }
        //private static void EstablecerParametros(List<Parameter> listParametros, DbCommand cmd)
        //{
        //    if (listParametros != null)
        //    {
        //        DbParameter param;
        //        for (int index = 0; index < listParametros.Count; index++)
        //        {
        //            param = cmd.CreateParameter();
        //            Parameter itemParam = listParametros[index];
        //            param.ParameterName = itemParam.Nombre;
        //            param.Value = itemParam.Valor;
        //            if (itemParam.Direccion == ParameterDirection.Output || itemParam.Direccion == ParameterDirection.InputOutput)
        //            {
        //                param.Direction = itemParam.Direccion;
        //                param.Size = itemParam.Tamano;
        //            }
        //            cmd.Parameters.Add(param);
        //        }
        //    }
        //}
    }
}
