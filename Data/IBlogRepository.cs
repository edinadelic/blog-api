using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.API.Models;

namespace Blog.API.Data
{
    public interface IBlogRepository
    {
        void Add (BlogPost blogPost);
        void Delete(string slug);
        BlogPost Update(string slug, BlogPost blogPost);
        Task<bool> SaveAll();
        Task<IEnumerable<BlogPost>> GetBlogPosts();
        Task<BlogPost> GetBlogPost(string slug);
        List<string> GetTags();
        
    }
}