using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStoreManager.Entities
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId {get; set;}

        public string? UserName { get; set;}

        public string? EmailId { get; set;}

        public string? Password { get; set;}

        public int RoleId { get; set; }

        public int IsActive { get; set; }

    }
}
