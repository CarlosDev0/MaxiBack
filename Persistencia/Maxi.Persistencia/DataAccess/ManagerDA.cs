using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Maxi.Persistencia.DataAccess
{
    public class ManagerDA
    {
        
        public ManagerDA()
        {
            string stringConnexion = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
            //nomeCadenaBancoDoDados = "strConnectionCambiosDev";
            baseDatos = new DatabaseProviderFactory().Create(stringConnexion);
        }
        private static Database baseDatos;
        private static IDbCommand PrepararComando(string procedimiento)
        {
            string stringConnexion = ConfigurationManager.ConnectionStrings["ConexionString"].ConnectionString;
            //nomeCadenaBancoDoDados = "strConnectionCambiosDev";
            baseDatos = new DatabaseProviderFactory().Create(stringConnexion);
            DbCommand comando = baseDatos.GetStoredProcCommand(procedimiento);
            //comando.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["TimeoutBD"].ToString());
            return comando;
        }
        public static DataSet EjecutarDataSet(string procedimiento, List<Parameter> listParametros)
        {
            DbCommand comando = PrepararComando(procedimiento) as DbCommand;
            EstablecerParametros(listParametros, comando);
            DataSet datos = baseDatos.ExecuteDataSet(comando);
            ObtenerParametros(listParametros, comando);
            return datos;
        }
        private static void EstablecerParametros(List<Parameter> listParametros, DbCommand cmd)
        {
            if (listParametros != null)
            {
                DbParameter param;
                for (int index = 0; index < listParametros.Count; index++)
                {
                    param = cmd.CreateParameter();
                    Parameter itemParam = listParametros[index];
                    param.ParameterName = itemParam.Nombre;
                    param.Value = itemParam.Valor;
                    if (itemParam.Direccion == ParameterDirection.Output || itemParam.Direccion == ParameterDirection.InputOutput)
                    {
                        param.Direction = itemParam.Direccion;
                        param.Size = itemParam.Tamano;
                    }
                    cmd.Parameters.Add(param);
                }
            }
        }
        public static void ObtenerParametros(List<Parameter> listParametros, DbCommand cmd)
        {
            if (listParametros != null)
            {
                for (int index = 0; index < listParametros.Count; index++)
                {
                    Parameter itemParam = listParametros[index];
                    if (itemParam.Direccion == ParameterDirection.Output || itemParam.Direccion == ParameterDirection.InputOutput)
                    {
                        itemParam.Valor = cmd.Parameters[index].Value;
                    }
                }
            }
        }
    }
}
