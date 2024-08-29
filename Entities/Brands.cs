using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStoreManager.Entities
{
    [Table("Brands")]
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }

        public string? BrandName { get; set; }

        public int? IsActive { get; set; }   
    }
}
