using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.API.Data;
using Blog.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly IBlogRepository _repo;
        public TagsController(IBlogRepository repo)
        {
           _repo = repo;
        }

        [HttpGet]
        public ActionResult GetTags()
        {
          var tags = _repo.GetTags();
          TagListDto tagList = new TagListDto();
          tagList.TagList = tags;
          return Ok(tagList);
        }

    }
}