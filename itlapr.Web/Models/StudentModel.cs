using System;

namespace itlapr.Web.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string CreationDateDisplay { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(FirstName, " ", LastName);
            }
        }
    }
}
