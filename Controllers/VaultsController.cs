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
  [Route("api/[controller]")]
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
    [HttpGet("{user}")]
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
    [HttpPost("{user}")]
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
    [HttpGet("{user}/vault")]
    public ActionResult<Vault> Get([FromBody] VaultKeep data)
    {
      try
      {
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
    [HttpPost("{user}/vault")]
    public ActionResult<Vault> Post(int id, [FromBody] VaultKeep data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_Repo.AddToVault(data));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // PUT api/values/5
    [Authorize]
    [HttpDelete("{user}/vault/{id}")]
    public string Put(int id)
    {
      try
      {
        return _Repo.RemoveFromVault(id);

      }
      catch (Exception e)
      {

        return $"Error Message{e.Message}";
      }
    }

    // DELETE api/values/5
    [Authorize]
    [HttpDelete("{user}/{id}")]
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