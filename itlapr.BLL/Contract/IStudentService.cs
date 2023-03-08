using itlapr.BLL.Core;
using itlapr.BLL.Dtos.Student;

namespace itlapr.BLL.Contract
{
    public interface IStudentService : IBaseService
    {
        ServiceResult SaveStudent(StudentSaveDto saveDto);
        ServiceResult UpdateStudent(StudentUpdateDto updateDto);
        ServiceResult RemoveStudent(StudentRemoveDto removeDto);
    }
}
