namespace MobileStoreManager.Entities.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Discount { get; set; }

        public int Quantity { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? IsActive { get; set; }


        //Brand-->
        public string? BrandName { get; set; }

        //Product-->
        public string? Model { get; set; }

        public decimal Price { get; set; }


        
    }
}
