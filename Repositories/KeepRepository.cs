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

      Keep data = _db.QueryFirstOrDefault<Keep>(query, new { Id });
      if (data == null) throw new Exception("Nothing to return for your search!");
      return data;


    }

    public Keep Create(Keep data)
    {
      string query = @"
            INSERT INTO keeps (name, description, userId, img)
            VALUES (@Name,  @Description, @UserId, @Img);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(query, data);
      //   if (data == null) throw new Exception("Not able to create from input!");
      data.Id = id;
      return data;
    }

    public Keep Update(Keep data)
    {
      string query = @"
            UPDATE keeps 
            SET
            name = @Name,
            description = @Description,
            userId = @UserId,
            img = @Img,
            isPrivate = @IsPrivate
            WHERE id = @Id AND userId =  @UserId;
            ";

      _db.QueryFirstOrDefault<Keep>(query, data);
      return data;


      // return data;
    }
    public Keep Like(bool isLike)
    {
      data.likeValue = 0

      string query = @"
            UPDATE keeps 
            SET
            views = views + @likeValue
            WHERE id = @Id AND userId =  @UserId;
            ";

      _db.QueryFirstOrDefault<Keep>(query, data);
      return data;


      // return data;
    }

    internal string Delete(int Id, string UserId)
    {
      string query = @"
      DELETE FROM keeps WHERE id = @Id AND userId = @UserId;
      ";

      int affectedRows = _db.Execute(query, new { Id, UserId });
      if (affectedRows < 1) throw new Exception("No good things happened...");
      if (affectedRows > 1) throw new Exception("Not good things happened...");
      return "Keep Deleted";
    }
  }
}