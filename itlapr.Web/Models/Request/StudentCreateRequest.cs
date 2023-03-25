using System;


namespace itlapr.Web.Models.Request
{
    public class StudentCreateRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime enrollmentDate { get; set; }
        public DateTime creationDate { get; set; }
        public int creationUser { get; set; }

    }
}
