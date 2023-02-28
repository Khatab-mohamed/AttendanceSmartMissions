using System.Security.Principal;

namespace AMS.Domain.Entities.Authentication
{
    public  class User  :IdentityUser
    {

     
        public Guid Id { get; set; }
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int IdNumber { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
