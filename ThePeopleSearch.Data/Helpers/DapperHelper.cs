using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace ThePeopleSearch.Data.Helpers
{
    public class DapperHelper<T> where T:class
    {
        private string _connString;
        private SqlConnection _conn;

        public DapperHelper(string connString)
        {
            _connString = connString;
            _conn = new SqlConnection(_connString);
        }

        public List<T> GetAll()
        {
            string sql = "SELECT * FROM " + typeof(T).Name;

            return _conn.Query<T>(sql).ToList();
        }

        public List<T>  GetAllUsersByTerm(string query)
        {
            string sql = "SELECT * FROM " + typeof(T).Name + " WHERE lastName LIKE @query OR firstName LIKE @query";

            DynamicParameters dp = new DynamicParameters();
            dp.Add("query", query);

            return _conn.Query<T>(sql, dp).ToList();
        }
    }
}
