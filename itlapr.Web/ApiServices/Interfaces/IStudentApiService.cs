
using itlapr.Web.Models;
using itlapr.Web.Models.Request;
using itlapr.Web.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace itlapr.Web.ApiServices.Interfaces
{
    public interface IStudentApiService
    {
        Task<StudentListResponse> GetStudents();
        Task<StudentResponse> GetStudent(int Id);
        Task<BaseResponse> Update(StudentUpdateRequest studentModel);
        Task<BaseResponse> Save(StudentCreateRequest studentModel);

    }
}
