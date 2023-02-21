using System.Collections.Generic;
using itlapr.DAL.Entities;
using itlapr.DAL.Model;


namespace itlapr.DAL.Interfaces
{
    public interface  IDepartmentRepository
    {

        List<DepartmentModel> GetAll();

        void Save(Department  department);

        void Update(Department  department);

        void Remove(Department  department);

        Department GetById(int id);

        bool Exists(string Name);
    }
}
