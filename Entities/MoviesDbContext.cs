using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Movies_Gallery.Entities
{
    public class MoviesDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<User> UsersXD { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) 
        { }
    }
}