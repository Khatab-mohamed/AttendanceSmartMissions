using System.Security.Principal;

namespace AMS.Domain.Entities.Authentication
{
    public abstract class User : Identity
    {

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public int IdNumber { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; }


        public abstract UserType Type { get; }

        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
        public string IdentityId { get; set; }
        public Identity Identity { get; set; }
    }
}
