using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace NOT.Repository
{
    public class BaseRepository
    {
        protected static string GetSqlFromFile(string nomeFile)
        {
            //https://stackoverflow.com/questions/6041332/best-way-to-get-application-folder-path
            return GetSqlFromPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Repository", "Sql", nomeFile));
        }
        protected static string GetSqlFromPath(string path)
        {
            string script = File.ReadAllText(path); //@"E:\Project Docs\MX462-PD\MX756_ModMappings1.sql");
            return script;
        }

        protected static T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.QueryFirstOrDefault<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected static List<T> Query<T>(string sql, object parameters = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<T>(sql, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TReturn>(sql, types, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TFirst, TSecond, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TFirst, TSecond, TThird, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TFirst, TSecond, TThird, TFourth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static List<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static int Execute(string sql, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return connection.Execute(sql, parameters, transaction, commandTimeout, commandType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Other Helpers...

        private static IDbConnection CreateConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            var connection = new SqlConnection(constr);
            // Properly initialize your connection here.
            return connection;
        }
    }
}
