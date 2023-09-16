namespace ArtGalleryAdminApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ArtGalleryAppUser? User { get; set; }

        public ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
