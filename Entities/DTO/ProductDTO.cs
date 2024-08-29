namespace MobileStoreManager.Entities.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int IsActive { get; set; }

        public DateTime? AddedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
