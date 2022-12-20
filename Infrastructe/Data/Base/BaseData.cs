using Dapper;
using Domain.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructe.Data.Base
{
    public class BaseData
    {
        private IConfiguration _config;
        private readonly string _connectionString;
        public BaseData(string connectioString, IConfiguration config) 
        {
            _config = config;
            _connectionString = _config.GetConnectionString(connectioString);
        }

        public IEnumerable<T> Read<T>(object param, string query)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var conn = new SqlConnection(_connectionString);

            try
            {
                conn.Open();

                var result = conn.Query<T>(query, param);

                return result;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public int Write(object param, string query)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            var conn = new SqlConnection(_connectionString);

            try
            {
                conn.Open();

                var result = conn.Execute(query, param);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
