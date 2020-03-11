using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.API.Data;
using Blog.API.Dtos;
using Blog.API.Helpers;
using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Blog.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBlogRepository _repo;
        private readonly IMapper _mapper;

        public PostsController(IBlogRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        // GET api/posts
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
            var blogPosts = await _repo.GetBlogPosts();
            var postCount = blogPosts.Count();

            BlogPostsDto blogPostsDto = new BlogPostsDto();
            blogPostsDto.BlogPosts = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts).ToList();
            blogPostsDto.PostCount = postCount;

            return Ok(blogPostsDto);
            
        }

        // GET api/posts/:slug
        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBlogPost(string slug)
        {
            var blogPost = await _repo.GetBlogPost(slug);
            OnePostDto postToReturn = new OnePostDto();
            postToReturn.BlogPost = _mapper.Map<BlogPostDto>(blogPost);

            return Ok(postToReturn);
        }

        // POST api/posts
        [Consumes("application/json")]
        [HttpPost]
        public void Post([FromBody] BlogPostDto blogPostDto)
        {
           string toSlug = blogPostDto.Title.ToString();
           blogPostDto.Slug = StringHelper.UrlFriendly(toSlug);
           
           string tags ="";
           foreach (var tag in blogPostDto.TagList)
           {
               tags += tag + ",";
           }
           tags = tags.Remove(tags.LastIndexOf(","));

           BlogPost blogPostToInsert = new BlogPost();
           blogPostToInsert.Slug = blogPostDto.Slug;
           blogPostToInsert.Body = blogPostDto.Body;
           blogPostToInsert.Description = blogPostDto.Description;
           blogPostToInsert.Title = blogPostDto.Title;
           blogPostToInsert.CreatedAt = blogPostDto.CreatedAt;
           blogPostToInsert.UpdatedAt = blogPostDto.UpdatedAt;
           blogPostToInsert.Tags= tags;
 
           _repo.Add(blogPostToInsert);
        }

        // PUT api/post/slug
        [HttpPut("{slug}")]
        public BlogPost Update(string slug, [FromBody] BlogPostDto blogPostDto)
        {
           string tags ="";
           foreach (var tag in blogPostDto.TagList)
           {
               tags += tag + ",";
           }
           tags = tags.Remove(tags.LastIndexOf(","));

           BlogPost blogPost = new BlogPost();
           blogPost.Slug = blogPostDto.Slug;
           blogPost.Body = blogPostDto.Body;
           blogPost.Description = blogPostDto.Description;
           blogPost.Title = blogPostDto.Title;
           blogPost.CreatedAt = blogPostDto.CreatedAt;
           blogPost.UpdatedAt = blogPostDto.UpdatedAt;
           blogPost.Tags= tags;
           
           return _repo.Update(slug, blogPost);
        }
        
        // DELETE api/posts/slug
        [HttpDelete("{slug}")]
        public void Delete(string slug)
        {
            _repo.Delete(slug);
        }
    }
}