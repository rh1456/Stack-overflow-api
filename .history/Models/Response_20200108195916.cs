using System;
using System.Collections.Generic;

namespace Stack_overflow_api.Models
{
  public class Response
  {
    public int Id { get; set; }
    public string Response { get; set; }
    public int RespUpvote { get; set; }
    public int RespDownVote { get; set; }


  }
}