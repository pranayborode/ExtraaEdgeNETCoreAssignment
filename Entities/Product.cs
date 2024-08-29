using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStoreManager.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
     
        public int BrandId { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int IsActive {  get; set; }

        public DateTime? AddedDate { get; set; }

        public DateTime? ModifiedDate { get; set;}
    }
}
