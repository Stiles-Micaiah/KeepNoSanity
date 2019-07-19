using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using keepr.Repositories;


namespace keepr.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;
        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");

        }

        public Keep GetById(int Id)
        {
            string query = @"
            SELECT * FROM keeps WHERE id = @Id
            ";

            Keep data = _db.QueryFirstOrDefault(query, new { Id });
            if (data == null) throw new Exception("Nothing to return for your search!");
            return data;


        }

        public Keep Create(Keep data)
        {
            string query = @"
            INSERT INTO keeps (name, description, userId, img)
            VALUES @Name, @Description, @UserId, @Image
            WHERE id = @Id;
            SELECT LAST_INSERT_ID();
            ";
            data = _db.ExecuteScalar<Keep>(query, data);
            if (data == null) throw new Exception("Not able to create from input!");
            return data;
        }

        public Keep Update(Keep data)
        {
            string query = @"
            UPDATE keeps 
            SET
            isPrivate = 1
            WHERE id = @Id;
            SELECT LAST_UPDATE();
            ";
            int affectedRows =  _db.Execute(query, data);
            if(affectedRows != 1 ) throw new Exception("Not good things happened...");
            return data;
        }

       

        
    }
}