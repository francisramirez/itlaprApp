using System.Collections.Generic;

namespace itlapr.Web.Models.Response
{
    public class StudentListResponse 
    {
        public bool success { get; set; }
        public List<StudentModel> data { get; set; }
        public string message { get; set; }

    }


}
