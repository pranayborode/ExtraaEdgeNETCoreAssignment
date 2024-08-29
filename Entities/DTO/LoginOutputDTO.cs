namespace MobileStoreManager.Entities.DTO
{
    public class LoginOutputDTO
    {
        public int UserId { get; set; }

        public int? RoleId { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public int? IsActive { get; set; }

        public string? Token { get; set; }
    }
}
