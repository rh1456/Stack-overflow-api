using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Stack_overflow_api.Models;
using Stack_overflow_api;


namespace Stack_overflow_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
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
      db.Posts.Add(entry);
      db.SaveChanges();
      return entry;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> GetAllPosts()
    {
      var Posts = db.Posts.OrderByDescending(post => post.PostCreated);
      return Posts.ToList();
    }
    [HttpGet("{id}")]
    public ActionResult GetOnePost(int id)
    {
      var post = db.Posts.FirstOrDefault(post => post.Id == id);
      if (post == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(post);
      }

    }
    [HttpGet("searchterm/{description}")]
    public async Task<ActionResult<Response>> SearchPosts(string description)
    {
      var post = await db.Posts.FindAsync(description);
      if (post == null)
      {
        return NotFound();
      }
      return Post;

    }

  }

}
