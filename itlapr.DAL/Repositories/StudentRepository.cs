using itlapr.DAL.Context;
using itlapr.DAL.Entities;
using itlapr.DAL.Exceptions;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace itlapr.DAL.Repositories
{
    public class StudentRepository : Core.RepositoryBase<Student>, IStudentRepository
    {
        private readonly ItlaContext itlaContext;
        private readonly ILogger<StudentRepository> logger;
        public StudentRepository(ItlaContext itlaContext,
                                 ILogger<StudentRepository> logger) : base(itlaContext)
        {
            this.itlaContext = itlaContext;
            this.logger = logger;
        }

        public override void Save(Student entity)
        {
            // x logica //

            if (string.IsNullOrEmpty(entity.FirstName))
            {
                throw new StudentDataException("El nombre es requerido");
            }

            base.Save(entity);
            base.SaveChanges();
        }
        public override void Update(Student entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Remove(Student entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }

        public override List<Student> GetEntities()
        {
            return this.itlaContext.Students.Where(cd => !cd.Deleted).ToList();
        }
        public override Student GetEntity(int id)
        {
            return this.itlaContext.Students.FirstOrDefault(cd => cd.Id == id && !cd.Deleted);
        }


    }
}
