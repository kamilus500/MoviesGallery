using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Movies_Gallery.Data
{
    public class AuthMovieGalleryContext : IdentityDbContext<IdentityUser>
    {
        public AuthMovieGalleryContext(DbContextOptions<AuthMovieGalleryContext> options)
            : base(options)
        {
        }
    }
}
