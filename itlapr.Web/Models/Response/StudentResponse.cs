namespace itlapr.Web.Models.Response
{
    public class StudentResponse
    {
        public bool success { get; set; }
        public StudentModel data { get; set; }
        public string message { get; set; }
    }
}
