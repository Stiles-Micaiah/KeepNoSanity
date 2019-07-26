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
  [Route("api/test")]
  [ApiController]
  public class TestController : ControllerBase
  {

    // private readonly VaultRepository _Repo;

    // public TestController(VaultRepository Repo)
    // {
    //   _Repo = Repo;
    // }
    // GET api/values
    // [Authorize]
    [HttpGet("whoami")]
    public string Get()
    {
      try
      {
        // var userId = HttpContext.User.FindFirstValue("Id");

        if (HttpContext.User.FindFirstValue("Id") != null)
        {
          return HttpContext.User.FindFirstValue("Id");
        }
        return "yeet";
      }
      catch (Exception e)
      {
        return e.Message;
      }
    }

  }
}