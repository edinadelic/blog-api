using System;
using System.Collections.Generic;
using Blog.API.Models;

namespace Blog.API.Dtos
{
    public class BlogPostDto
    {
      public string Slug { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string Body { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
      public ICollection<String> TagList  { get; set; }
     
    }
    
}