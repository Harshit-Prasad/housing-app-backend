﻿namespace server.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
