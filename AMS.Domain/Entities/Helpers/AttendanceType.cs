using System.ComponentModel;

namespace AMS.Domain.Entities.Helpers;
public enum AttendanceType
{
    [Description("Check In")]
    CheckIn =1,

    [Description("Check Out")]
    CheckOut = 0,
}
