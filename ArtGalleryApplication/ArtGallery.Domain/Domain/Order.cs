using ArtGallery.Domain.Identity;


namespace  ArtGallery.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ArtGalleryAppUser? User { get; set; }

        public virtual ICollection<ProductInOrder>? ProductInOrders { get; set; }
    }
}
