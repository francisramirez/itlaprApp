using System;

namespace itlapr.BLL.Dtos.Student
{
    public class StudentRemoveDto
    {
        public int StudentId { get; set; }
        public bool Removed { get; set; }
        public DateTime RemoveDate { get; set; }
        public int RemoveUser { get; set; }

    }
}
