﻿namespace AMS.Api.ResourceParameters
{
    public class ResourceParameters
    {
        const int maxPageSize = 20;
        public string? Location { get; set; }
       public int PageNumber { get; set; } = 1; 

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; } = "Name";
        public Guid UserId { get; set; }
    }
}
