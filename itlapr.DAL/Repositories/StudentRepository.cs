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
        
    }
}
