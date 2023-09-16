using System.Diagnostics.CodeAnalysis;
using ArtGallery.Domain.Domain;
using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Domain.Identity
{
    public class ArtGalleryAppUser :IdentityUser
    {
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Address { get; set; }
        public virtual ShoppingCart? UserCart { get; set; }
    }
}
