using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Stack_overflow_api.Models;
using Stack_overflow_api;


namespace Stack_overflow_api.Controllers
{
  [Route("api/[controller]")]

  public class PostController : ControllerBase
  {
    private DatabaseContext db;

    public PostController(DatabaseContext context)
    {
      db = context;
    }
    [HttpPost]
    public ActionResult<Post> CreatePost([FromBody]Post entry)
    {
      db.Questions.Add(entry);
      db.SaveChanges();
      return entry;
    }


  }


}