using itlapr.DAL.Core;
using System;

namespace itlapr.DAL.Entities
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
