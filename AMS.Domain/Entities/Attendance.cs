using AMS.Domain.Entities.Helpers;

namespace AMS.Domain.Entities
{
    public  class Attendance :Base
    {
        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public AttendanceType AttendanceType { get; set; }
    }

    
}
