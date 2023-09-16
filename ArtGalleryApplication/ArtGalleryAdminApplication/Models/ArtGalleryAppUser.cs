using Microsoft.AspNetCore.Identity;

namespace ArtGalleryAdminApplication.Models
{
    public class ArtGalleryAppUser
    {
        public string UserName { get; set; }
        public  string NormalizedUserName { get; set; }
        public  string Email { get; set; }
        public string NormalizedEmail { get; set; }


        /*
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public virtual ShoppingCart? UserCart { get; set; }*/
    }
}
