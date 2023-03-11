using itlapr.BLL.Dtos.Student;
using itlapr.DAL.Entities;

namespace itlapr.BLL.Extentions
{
    public static class StudentExtention
    {
        public static Student GetStudentEntityFromDtoSave(this StudentSaveDto saveDto)
        {
            Student student = new Student()
            {
                FirstName = saveDto.FirstName,
                CreationDate = saveDto.CreationDate,
                CreationUser = saveDto.CreationUser,
                LastName = saveDto.LastName, 
                EnrollmentDate = saveDto.EnrollmentDate
            };

            return student;
        }
    }
}
