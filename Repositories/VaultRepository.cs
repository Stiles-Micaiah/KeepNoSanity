using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    public Vault CreateVault(Vault data)
    {
      string query = @"
      INSERT INTO vaults (name, description, userId)
      VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();
      ";

      int dii = _db.ExecuteScalar<int>(query, data);
      data.Id = dii;
      return data;
    }
    public IEnumerable<Vault> GetVaults(string UserId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId", new { UserId });
    }

    public IEnumerable<Keep> OpenVault(VaultKeep data)
    {
      string query = @"
       SELECT * FROM vaultkeeps vk
       INNER JOIN keeps k ON k.id = vk.keepId
       WHERE (vaultId = @VaultId AND vk.userId = @UserId)
      ";

      return _db.Query<Keep>(query, data);
    }

    public VaultKeep AddToVault(VaultKeep data)
    {
      string query = @"
      INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES(@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();
      ";
      int dii = _db.ExecuteScalar<int>(query, data);
      data.Id = dii;
      return data;
    }

    public string RemoveFromVault(VaultKeep data)
    {
      string query = @"
      DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @VaultId;
      ";
      int affectedRows = _db.Execute(query, data);
      if (affectedRows < 1) throw new Exception("No good things happened...");
      if (affectedRows > 1) throw new Exception("Not good things happened...");
      return "vaultkeep Deleted";
    }

    public string DeleteVault(int Id,string userId)
    {

      string query = @"
      DELETE FROM vaults WHERE id = @Id AND userID = @UserId;
      ";
      int affectedRows = _db.Execute(query, new { Id, userId });
      if (affectedRows < 1) throw new Exception("No good things happened...");
      if (affectedRows > 1) throw new Exception("Not good things happened...");
      return "vault Deleted";
    }

    // public string RemoveFromVault(int id)
    // {
    //   throw new NotImplementedException();
    // }
  }
}