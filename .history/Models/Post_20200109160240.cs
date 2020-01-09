
using System;
using System.Collections.Generic;

namespace Stack_overflow_api.Models
{

  public class Post
  {
    public int Id { get; set; }
    public string PostTitle { get; set; }
    public string PostContent { get; set; }
    public int PostUpVote { get; set; }
    public int PostDownVote { get; set; }
    public DateTime PostCreated { get; set; } = DateTime.Now;

    public List<Post> Posts { get; set; } = new List<Post>();
  }
}