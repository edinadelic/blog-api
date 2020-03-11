using Blog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){ }
        
    public DbSet<BlogPost> BlogPosts { get; set; }

    }
}