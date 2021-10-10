using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies_Gallery.Models.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Movies_Gallery.Entities
{
    public class MoviesDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) 
        { }
    }
}