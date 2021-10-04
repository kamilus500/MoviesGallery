using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies_Gallery.Models.Dtos;

namespace Movies_Gallery.Entities
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) 
        { }
    }
}
