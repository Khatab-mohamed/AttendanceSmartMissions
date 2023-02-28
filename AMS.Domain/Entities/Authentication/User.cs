using System.Security.Principal;

namespace AMS.Domain.Entities.Authentication
{
    public  class User  :IdentityUser
    {

        [Required]
        public string FullName { get; set; }
        [Required] 
        public int IDNumber { get; set; }

        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
