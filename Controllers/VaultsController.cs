using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace keepr.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class VaultsController : ControllerBase
  {

    private readonly VaultRepository _Repo;

    public VaultsController(VaultRepository Repo)
    {
      _Repo = Repo;
    }
    // GET api/values
    [Authorize]
    [HttpGet("vaults")]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_Repo.GetVaults(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [Authorize]
    [HttpPost("vaults")]
    public ActionResult<Vault> Post([FromBody] Vault data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_Repo.CreateVault(data));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [Authorize]
    [HttpGet("vaults/{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        VaultKeep data = new VaultKeep();
        data.VaultId = id;
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_Repo.OpenVault(data));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // PUT api/values/5
    [Authorize]
    [HttpPost("vaults/vk/{id}")]
    public ActionResult<Vault> Post(int id, [FromBody] VaultKeep data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        data.VaultId = id;
        return Ok(_Repo.AddToVault(data));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // PUT api/values/5
    [Authorize]
    [HttpDelete("vaults/vk/{id}")]
    public string Put(int id, intId)
    {
      try
      {
        DataModel data = new DataModel();
        data.IntIdAlt = id; //vault
        // data.UserId = HttpContext.User.FindFirstValue("Id");
        data.IntId = intId; //keep
        return _Repo.RemoveFromVault(data);

      }
      catch (Exception e)
      {

        return $"Error Message{e.Message}";
      }
    }

    // DELETE api/values/5
    [Authorize]
    [HttpDelete("vaults/{id}")]
    public string Delete(int id)
    {
      try
      {
        return _Repo.DeleteVault(id);

      }
      catch (Exception e)
      {

        return $"Error Message{e.Message}";
      }

    }
  }
}