using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stack_overflow_api.Models;

namespace Stack_overflow_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ResponseController : ControllerBase
  {
    private DatabaseContext db;

    public ResponseController(DatabaseContext context)
    {
      db = context;
    }

    [HttpPost]
    public ActionResult<Response> CreateResponse([FromBody]Response entry)
    {
      db.Responses.Add(entry);
      db.SaveChanges();
      return entry;
    }
    [HttpGet]
    public ActionResult<Response> GetAllResponses()
    {
      var response = db.Responses.OrderByDescending(response => response.Id);
      return response.ToList();
    }
  }
}