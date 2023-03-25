using itlapr.BLL.Contract;
using itlapr.BLL.Core;
using itlapr.BLL.Dtos.Student;
using itlapr.BLL.Models;
using itlapr.DAL.Entities;
using itlapr.DAL.Exceptions;
using itlapr.DAL.Interfaces;
using itlapr.BLL.Extentions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Resources;
using itlapr.BLL.Logger;

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
                    EnrollmentDate = cd.EnrollmentDate.Value,
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
            ServiceResult result = new ServiceResult();

            try
            {
                Student studentToRemove = this.studentRepository.GetEntity(removeDto.StudentId);

                studentToRemove.Deleted = removeDto.Removed;
                studentToRemove.DeletedDate = removeDto.RemoveDate;
                studentToRemove.UserDeleted = removeDto.RemoveUser;

                this.studentRepository.Update(studentToRemove);

                result.Success = true;
                result.Message = "El estudiante ha sido eliminado correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error removiendo el estudiante";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveStudent(StudentSaveDto saveDto)
        {

            this.logger.LogInformation("Paso por aqui", saveDto.FirstName);
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(saveDto.FirstName))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (saveDto.FirstName.Length > 50)
            {
                result.Success = false;
                result.Message = "La logitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(saveDto.LastName))
            {
                result.Success = false;
                result.Message = "El apellido es requerido";
                return result;
            }
            if (saveDto.FirstName.Length > 50)
            {
                result.Success = false;
                result.Message = "La logintud del apellido es inválida";
                return result;
            }

            if (!saveDto.EnrollmentDate.HasValue)
            {
                result.Success = false;
                result.Message = "La fecha de inscripción es requerida.";
                return result;

            }

            try
            {
                Student student = saveDto.GetStudentEntityFromDtoSave();
                this.studentRepository.Save(student);
                result.Success = true;
                result.Message = "El estudiante ha sido agregado correctamente.";

                this.logger.LogInformation(result.Message, result);
                

            }
            catch (StudentDataException sdex) 
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, sdex.ToString());
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error agregando el estudiante";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
               
            }

            return result;
        }

        public ServiceResult UpdateStudent(StudentUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (string.IsNullOrEmpty(updateDto.FirstName))
                {
                    result.Success = false;
                    result.Message = "El nombre es requerido";
                    return result;
                }

                if (updateDto.FirstName.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logitud del nombre es inválida";
                    return result;
                }

                if (string.IsNullOrEmpty(updateDto.LastName))
                {
                    result.Success = false;
                    result.Message = "El apellido es requerido";
                    return result;
                }
                if (updateDto.FirstName.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logintud del apellido es inválida";
                    return result;
                }

                if (!updateDto.EnrollmentDate.HasValue)
                {
                    result.Success = false;
                    result.Message = "La fecha de inscripción es requerida.";
                    return result;

                }

                Student student = this.studentRepository.GetEntity(updateDto.StudentId);
                student.ModifyDate = updateDto.ModifyDate;
                student.UserMod = updateDto.ModifyUser;
                student.FirstName = updateDto.FirstName;
                student.LastName = updateDto.LastName;
                student.EnrollmentDate = updateDto.EnrollmentDate;

                this.studentRepository.Update(student);
                result.Success = true;
                result.Message = "El estudiante ha sido actualizado correctamente.";

            }
            catch (StudentDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, sdex.ToString());
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrió un error actualizando el estudiante";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}
