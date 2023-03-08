using itlapr.BLL.Contract;
using itlapr.BLL.Core;
using itlapr.BLL.Dtos.Student;
using itlapr.BLL.Models;
using itlapr.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace itlapr.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ILogger<StudentService> logger;

        public StudentService(IStudentRepository studentRepository,
                              ILogger<StudentService> logger)
        {
            this.studentRepository = studentRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var students = this.studentRepository.GetEntities().Select(cd => new StudentResultModel()
                {
                    CreationDate = cd.CreationDate,
                    EnrollmentDate =  cd.EnrollmentDate.Value,
                    FirstName = cd.FirstName,
                    LastName = cd.LastName,
                    StudentId = cd.Id
                }).ToList();

                result.Data = students;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los estudiantes";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            
            try
            {
                var student = this.studentRepository.GetEntity(Id);

                StudentResultModel studentResultModel = new StudentResultModel()
                {
                    CreationDate = student.CreationDate,
                    EnrollmentDate = student.EnrollmentDate.Value,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    StudentId = student.Id
                };

                result.Data = studentResultModel;
                result.Success = true;
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrió un error obteniendo el estudiante";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveStudent(StudentRemoveDto removeDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult SaveStudent(StudentSaveDto saveDto)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult UpdateStudent(StudentUpdateDto updateDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
