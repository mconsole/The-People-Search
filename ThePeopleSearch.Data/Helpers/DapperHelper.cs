using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using ThePeopleSearch.Data.Models;

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
            dp.Add("query", "%" + query + "%");

            return _conn.Query<T>(sql, dp).ToList();
        }

        public int InsertNewUser(Users user)
        {
            string sql = "INSERT INTO Users (firstName, lastName, age, addressId, interests, userImage, createdDtTime) VALUES (@firstName, @lastName, @age, @addressId, @interests, @userImage, @createdDtTime); SELECT CAST(SCOPE_IDENTITY() as int);";

            var x = _conn.Query<int>(sql, user).Single();

            return x;
        }

        public int InsertNewLocation(Locations location)
        {
            string sql = "INSERT INTO Locations (streetAddr, cityName, stateName, zipCode, countryName, createdDtTime) VALUES (@streetAddr, @cityName, @stateName, @zipCode, @countryName, @createdDtTime); SELECT CAST(SCOPE_IDENTITY() as int);";

            var x = _conn.Query<int>(sql, location).Single();

            return x;
        }

        public int LogNewError(Error error)
        {
            string sql = "INSERT INTO Errors (message, stackTrace, createdDtTIme) VALUES (@message, @stackTrace, @createdDtTime); SELECT CAST(SCOPE_IDENTITY() as int);";

            var x = _conn.Query<int>(sql, error).Single();

            return x;
        }
    }
}
