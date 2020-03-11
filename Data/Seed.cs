using System.Collections.Generic;
using System.Linq;
using Blog.API.Helpers;
using Blog.API.Models;
using Newtonsoft.Json;

namespace Blog.API.Data
{
    public class Seed
    {
        public static void SeedBlogPosts(DataContext context)
        {
            if(!context.BlogPosts.Any())
            {
                var blogPostData = System.IO.File.ReadAllText("Data/BlogPostSeedData.json");
                var blogPosts = JsonConvert.DeserializeObject<List<BlogPost>>(blogPostData);

                foreach (var blogPost in blogPosts)
                {
                    string toSlug = blogPost.Title.ToString();
                    blogPost.Slug = StringHelper.UrlFriendly(toSlug);
                    context.BlogPosts.Add(blogPost);
                }
                context.SaveChanges();
            }

        }
    }
}