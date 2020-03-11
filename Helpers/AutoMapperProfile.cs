using AutoMapper;
using Blog.API.Dtos;
using Blog.API.Models;

namespace Blog.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogPost, BlogPostDto>().
            ForMember(d => d.TagList, s => s.MapFrom(s=> s.Tags.Replace(" ","").Split(new char[] {','})));
		
        }
    }
}