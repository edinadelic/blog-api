using System.Collections.Generic;

namespace Blog.API.Dtos
{
    public class BlogPostsDto
    {
        public ICollection<BlogPostDto> BlogPosts { get; set; }
        public int PostCount { get; set; }
    }
}