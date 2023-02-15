
using System;

namespace itlapr.DAL.Model
{
    public  class CourseDepartmetModel
    {
        public int CourseID { get; set; }
        public string Course { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
