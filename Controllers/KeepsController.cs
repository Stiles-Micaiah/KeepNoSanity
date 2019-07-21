using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using keepr.Repositories;

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
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep data)
    {
      try
      {
        return Ok(_Repo.Create(data));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep data)
    {
      try
      {
        return Ok(_Repo.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      try
      {
        return _Repo.Delete(id);

      }
      catch (Exception e)
      {

        return $"Error Message{e.Message}";
      }

    }
  }
}