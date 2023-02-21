
using System;
using System.Collections.Generic;
using System.Linq;
using itlapr.DAL.Context;
using itlapr.DAL.Entities;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Model;
using Microsoft.Extensions.Logging;

namespace itlapr.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ItlaContext _itlaContext;
        private readonly ILogger<DepartmentRepository> _logger;

        public DepartmentRepository(ItlaContext itlaContext, ILogger<DepartmentRepository> logger)
        {
            _itlaContext = itlaContext;
            _logger = logger;
        }
        public bool Exists(string Name)
        {
            return _itlaContext.Departments.Any(cd => cd.Name == Name);
        }
        public Department GetById(int id)
        {
            return _itlaContext.Departments.Find(id);
        }

        public List<DepartmentModel> GetAll()
        {

            var departments = _itlaContext.Departments.Where(cd => !cd.Deleted).Select(cd => new DepartmentModel()
            {
                Budget = cd.Budget,
                DepartmentID = cd.DepartmentID,
                Name = cd.Name,
                StartDate = cd.StartDate
            }).ToList();


            return departments;
        }

        public void Remove(Department department)
        {
            try
            {
                Department departmentToRemove = this.GetById(department.DepartmentID);

                departmentToRemove.DeletedDate = DateTime.Now;
                departmentToRemove.Deleted = true;
                departmentToRemove.UserDeleted = department.UserDeleted;

                _itlaContext.Departments.Remove(departmentToRemove);
                _itlaContext.SaveChanges();

            }
            catch (Exception ex)
            {

                _logger.LogError($"Error removiendo el dpeartamento {ex.Message}", ex.ToString());
            }
        }

        public void Save(Department department)
        {
            try
            {
                Department departmentToAdd = new Department()
                {
                    Administrator = department.Administrator,
                    CreationUser = department.CreationUser,
                    CreationDate = DateTime.Now,
                    Budget = department.Budget,
                    StartDate = department.StartDate,
                    Name = department.Name
                };


                _itlaContext.Departments.Add(departmentToAdd);
                _itlaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error guardando el dpeartamento {ex.Message}", ex.ToString());
            }
        }

        public void Update(Department  department)
        {
            try
            {
                Department departmentToUpdate = this.GetById(department.DepartmentID);

                departmentToUpdate.DepartmentID = department.DepartmentID;
                departmentToUpdate.Name = department.Name;
                departmentToUpdate.StartDate = department.StartDate;
                departmentToUpdate.Budget = department.Budget;
                departmentToUpdate.Administrator = department.Administrator;
                departmentToUpdate.ModifyDate = DateTime.Now;
                departmentToUpdate.UserMod = department.UserMod;


                _itlaContext.Departments.Update(departmentToUpdate);
                _itlaContext.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error actualizando el dpeartamento {ex.Message}", ex.ToString());
            }
        }
    }
}
