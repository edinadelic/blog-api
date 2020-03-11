using System.Collections.Generic;

namespace Blog.API.Dtos
{
    public class TagListDto
    {
        public ICollection<string> TagList { get; set; }
    }
}