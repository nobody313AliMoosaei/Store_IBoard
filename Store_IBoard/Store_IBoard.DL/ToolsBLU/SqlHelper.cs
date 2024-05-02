using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store_IBoard.DL.ToolsBLU
{
    public static class SqlHelper
    {

        public static async Task<List<TResult>> ExecuteStoreProcedure<TResult>(string SPName, DynamicParameters? parameters = null)
        {
            var Result = new List<TResult>();
            SqlConnection connection = new SqlConnection(SystemConsts.ConnectionString);
            try
            {
                if (parameters is null)
                    Result = (await connection.QueryAsync<TResult>(SPName, commandType: CommandType.StoredProcedure)).ToList();
                else
                    Result = (await connection.QueryAsync<TResult>(SPName, parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
            catch (Exception ex)
            { }
            finally { connection.Close(); }
            return Result;
        }
        public static async Task<List<TResult>> ExecuteQuery<TResult>(string Query)
        {
            var Result = new List<TResult>();
            SqlConnection connection = new SqlConnection(SystemConsts.ConnectionString);
            try
            {
                Result = (await connection.QueryAsync<TResult>(Query, commandType: CommandType.Text)).ToList();
            }
            catch (Exception ex)
            {
            }
            finally { connection.Close(); }
            return Result;
        }

        public static async Task<bool> ExecuteCommand(string Command)
        {
            SqlConnection Connection = new SqlConnection(SystemConsts.ConnectionString);
            try
            {
                if ((await Connection.ExecuteAsync(Command)) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            { }
            finally { Connection.Close(); }
            return false;
        }
    }
}
