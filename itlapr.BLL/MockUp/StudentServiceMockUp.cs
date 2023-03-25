
using itlapr.BLL.Contract;
using itlapr.BLL.Core;
using itlapr.BLL.Dtos.Student;

namespace itlapr.BLL.MockUp
{
    public class StudentServiceMockUp  
    {
        private readonly IStudentService studentService;

        public StudentServiceMockUp(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public ServiceResult GetAll()
        {
            return this.studentService.GetAll();
        }

        public ServiceResult GetById(int Id)
        {
            return this.studentService.GetById(Id);
        }

        
    }
}
