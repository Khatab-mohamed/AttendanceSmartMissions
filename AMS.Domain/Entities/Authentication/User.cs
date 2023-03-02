using System.Security.Principal;

namespace AMS.Domain.Entities.Authentication
{
    public  class User: IdentityUser
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required] 
        public int IDNumber { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }

    }
}
