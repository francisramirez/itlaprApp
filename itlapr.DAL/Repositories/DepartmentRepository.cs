
using itlapr.DAL.Context;
using itlapr.DAL.Entities;
using itlapr.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace itlapr.DAL.Repositories
{
    public class DepartmentRepository : Core.RepositoryBase<Department>,  IDepartmentRepository
    {
        private readonly ItlaContext _itlaContext;
        private readonly ILogger<DepartmentRepository> _logger;
        public DepartmentRepository(ItlaContext itlaContext, ILogger<DepartmentRepository> logger): base(itlaContext)
        {
            _itlaContext = itlaContext;
            _logger = logger;
        }
        public override List<Department> GetEntities()
        {
            var departments = this._itlaContext.Departments.Where(dep => !dep.Deleted).ToList();
            
            
            return departments;
            
        }
        public bool Exists(string name)
        {
            return this._itlaContext.Departments.Count(cd => cd.Name == name) > 1;
        }

    }
}
