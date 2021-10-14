using Microsoft.AspNetCore.Identity;

namespace Movies_Gallery.Entities
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
    }
}
