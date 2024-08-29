using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStoreManager.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Discount { get; set; }

        public int Quantity { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? IsActive { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
