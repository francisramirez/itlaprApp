using itlapr.DAL.Context;
using itlapr.DAL.Entities;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace itlapr.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ItlaContext itlaContext;
        private readonly ILogger<StudentRepository> logger;

        public StudentRepository(ItlaContext itlaContext,
                                 ILogger<StudentRepository> logger)
        {
            this.itlaContext = itlaContext;
            this.logger = logger;
        }

        public bool Exists(string name)
        {
            return this.itlaContext.Students.Any(st => st.FirstName == name);
        }

        public List<Student> GetAll()
        {
            return this.itlaContext.Students.ToList();
        }

        public Student GetById(int studentId)
        {
            return this.itlaContext.Students.Find(studentId);
        }
        public void Remove(Student student)
        {
            try
            {
                Student studentToRemove = this.GetById(student.Id);

                studentToRemove.Deleted = true;
                studentToRemove.DeletedDate = DateTime.Now;
                studentToRemove.UserDeleted = student.UserDeleted;

                this.itlaContext.Students.Update(studentToRemove);
                this.itlaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error removiendo el estudiante", ex.ToString());
            }
        }
        public void Save(Student student)
        {
            try
            {
                Student studentToAdd = new Student()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    CreationDate = DateTime.Now,
                    CreationUser = student.CreationUser,
                    EnrollmentDate = student.EnrollmentDate
                };

                this.itlaContext.Students.Add(studentToAdd);
                this.itlaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error removiendo el estudiante", ex.ToString());
                throw;
                throw;
            }
        }
        public void Update(Student student)
        {
            try
            {
                Student studentToUpdate = this.GetById(student.Id);

                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.EnrollmentDate = student.EnrollmentDate;
                studentToUpdate.ModifyDate = DateTime.Now;
                studentToUpdate.UserMod = student.UserMod;
                this.itlaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error removiendo el estudiante", ex.ToString());
            }
        }

        
    }
}
