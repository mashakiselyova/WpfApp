using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace WpfTestApp.Repositories
{
    class AssortmentRepository
    {
        private IDbConnection _db;

        public AssortmentRepository()
        {
            _db = new SqlConnection("Server=217.21.54.206,4433;Database=SteelDB-Test;User Id=user;Password=userpwd;");
            //("Server=localhost\\SQLEXPRESS;Database=testDatabase;Trusted_Connection=True;");
        }

        public List<Item> GetAll()
        {
            using (_db)
            {
                return _db.Query<Item>("SELECT * FROM Assortment").ToList();
            }
        }

        public void Create(Item item)
        {
            var sqlQuery = @"INSERT INTO Assortment 
                (Code, Tekla, IdProfileType, Profile, IsShortA, Price, 
                DefaultLength, DefaultWidth, BigCode, Standard, Weight) 
                VALUES
                (@Code, @Tekla, @IdProfileType, @Profile, @IsSHortA, @Price, 
                @DefaultLength, @DefaultWidth, @BigCode, @Standard, @Weight)";
            _db.Execute(sqlQuery, item);
        }

        public void Update(Item item)
        {
            var sqlQuery = @"UPDATE Assortment SET 
                Code = @Code, Tekla = @Tekla, IdProfileType = @IdProfileType, Profile = @Profile, 
                IsShortA = @IsShortA, Price = @Price, DefaultLength = @DefaultLength, DefaultWidth = @DefaultWidth, 
                BigCode = @BigCode, Standard = @Standard, Weight = @Weight 
                WHERE Id = @Id";
            _db.Execute(sqlQuery, item);
        }

        public void Delete(int id)
        {
            var sqlQuery = "DELETE FROM Assortment WHERE Id = @id";
            _db.Execute(sqlQuery, new { id });
        }
    }
}
