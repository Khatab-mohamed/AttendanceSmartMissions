namespace AMS.Domain.ResourceParameters.Attendances
{
    public class AttendanceResourceParameters
    {
        /* const int maxPageSize = 20;
        private int _pageSize = 10;
        public int PageSize
        {
              get => _pageSize;
              set => _pageSize = value > maxPageSize ? maxPageSize : value;
          }*/
        public string? Location { get; set; }
        public DateTime Date { get; set; }

      
       public Guid UserId { get; set; }
    }
}
