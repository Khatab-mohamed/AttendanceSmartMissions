using System.Security.Principal;
using System.Text.RegularExpressions;
using AMS.Domain.Entities.Locations;

namespace AMS.Domain.Entities.Authentication
{
    public  class User: IdentityUser<Guid>
    {

        [Required]
        public string FullName { get; set; }
        
        [Required] 
        public string IDNumber { get; set; }
        
        [Required] 
        public string DeviceSerialNumber { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        public  IList<UserLocation> UserLocations { get; set; } 
    }
}
