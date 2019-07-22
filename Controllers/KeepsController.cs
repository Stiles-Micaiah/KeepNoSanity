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
  public class KeepsController : ControllerBase
  {

    private readonly KeepRepository _Repo;

    public KeepsController(KeepRepository Repo)
    {
      _Repo = Repo;
    }
    // GET api/values
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_Repo.GetAll());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_Repo.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_Repo.Create(data));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // PUT api/values/5
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep data)
    {
      try
      {
        data.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_Repo.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [Authorize]
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return _Repo.Delete(id, userId);

      }
      catch (Exception e)
      {

        return $"Error Message{e.Message}";
      }

    }
  }
}