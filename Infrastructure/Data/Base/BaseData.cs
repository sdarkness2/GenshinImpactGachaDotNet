using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Infrastructe.Data.Base
{
    public class BaseData
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        public BaseData(string connectioString, IConfiguration config) 
        {
            _config = config;
            _connectionString = _config.GetConnectionString(connectioString);
        }

        public IEnumerable<T> Leitura<T>(string query, object? param)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var conn = new SqlConnection(_connectionString);

            try
            {
                conn.Open();

                var result = conn.Query<T>(query, param);

                return result;
            }
            catch(Exception) 
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public int Escrita(string query, object param)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var conn = new SqlConnection(_connectionString);

            try
            {
                conn.Open();

                var result = conn.Execute(query, param);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
