using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.API.Helpers;
using Blog.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Blog.API.Data
{
    public class BlogRepository : IBlogRepository

    {
        private readonly DataContext _context;
        public BlogRepository(DataContext context)
        {
            _context = context;

        }
        public void Add(BlogPost blogPost)
        {   
             _context.Add(blogPost);
             _context.SaveChanges();
        }
        public BlogPost Update(string slug, BlogPost blogPost)
        { 
         var blogPostToUpdate =  _context.BlogPosts.FirstOrDefault(x => x.Slug == slug);
         blogPostToUpdate.Title = blogPost.Title;
         blogPostToUpdate.Body = blogPost.Body;
         blogPostToUpdate.Description = blogPost.Description;
         blogPostToUpdate.Slug = StringHelper.UrlFriendly(blogPostToUpdate.Title.ToString());
         blogPostToUpdate.Tags = blogPost.Tags;

         _context.Update(blogPostToUpdate);
         _context.SaveChanges();

         return blogPostToUpdate;
        }
        public async Task<BlogPost> GetBlogPost(string slug)
        {
            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(x => x.Slug == slug);
            return blogPost;
        }
         public async Task<IEnumerable<BlogPost>> GetBlogPosts()
        {
            var blogPosts = await _context.BlogPosts.ToListAsync();
            
            return blogPosts;
        }
        public void Delete(string slug)
        {
            _context.Remove(slug);
            _context.SaveChanges();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public List<string> GetTags()
        {
            var tagGroups = _context.BlogPosts.Select(x => x.Tags).Distinct().ToList();
            
            StringBuilder sb = new StringBuilder();
            
            foreach (var tagGroup in tagGroups)
            {
                sb.Append(tagGroup);
            }
            var tagsToReturn = sb.ToString().Trim().Split(new char[] { ',' }).ToList();
        
            return tagsToReturn;
   
        }
    }
}