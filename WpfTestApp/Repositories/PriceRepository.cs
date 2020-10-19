using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp.Repositories
{
    class PriceRepository
    {

        private IDbConnection _db;

        public PriceRepository()
        {
            _db = new SqlConnection("Server=217.21.54.206,4433;Database=SteelDB-Test;User Id=user;Password=userpwd;");
            //("Server=localhost\\SQLEXPRESS;Database=testDatabase;Trusted_Connection=True;");
        }

        public int AddOne(int id)
        {
            var currentPrice = _db.Query<int>("SELECT Price FROM Assortment WHERE Id = @id", new { id }).FirstOrDefault();
            var newPrice = ++currentPrice;
            var sqlQuery = "UPDATE Assortment SET Price = @Price WHERE Id = @Id";
            _db.Execute(sqlQuery, new { Price = newPrice, Id = id});
            return newPrice;
        }

        public int SubtractOne(int id)
        {
            var currentPrice = _db.Query<int>("SELECT Price FROM Assortment WHERE Id = @id", new { id }).FirstOrDefault();
            var newPrice = --currentPrice;
            var sqlQuery = "UPDATE Assortment SET Price = @Price WHERE Id = @Id";
            _db.Execute(sqlQuery, new { Price = newPrice, Id = id });
            return newPrice;
        }
    }
}
