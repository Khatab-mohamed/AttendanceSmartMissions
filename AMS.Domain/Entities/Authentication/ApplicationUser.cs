using System.Security.Principal;

namespace AMS.Domain.Entities.Authentication
{
    public  class ApplicationUser: IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required] 
        public int IDNumber { get; set; }
        public string DeviceSerialNumber { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }

    }
}
