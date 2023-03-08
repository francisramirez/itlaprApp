using System;

namespace itlapr.BLL.Models
{
    public class StudentResultModel
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }

        public string CreationDateDisplay 
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); } 
        }
    }
}
